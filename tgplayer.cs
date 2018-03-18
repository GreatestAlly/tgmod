using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace tgmod
{
    class tgplayer : ModPlayer
    {
        public static float damageLoss = 0.5f;
        public static float damageBoost = 0.55f;
        public int playerClass = ClassID.classless;
        public int playerGimmick = GimmickID.gimmickless;
        public int playerFaction = FactionID.human;
        public int extraFishingLines = 0;
        public bool multicultured = false;
        public bool inNeutralZone = false;
        public bool elvenBlessing = false;

        public override void ResetEffects()
        {
            multicultured = false;
            inNeutralZone = false;
            elvenBlessing = false;
            extraFishingLines = 0;
        }

        public override TagCompound Save()
        {
            return new TagCompound
            {
                {"class", playerClass },
                {"quirk", playerGimmick }, // still using old names because it would break saves
                {"race", playerFaction }
            };
        }

        public override void Load(TagCompound tag)
        {
            playerClass = tag.GetInt("class");
            playerGimmick = tag.GetInt("quirk");
            playerFaction = tag.GetInt("race");
        }

        public override void PostUpdateEquips()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                if (!Config.netSynced)
                {
                    var netMessage = mod.GetPacket();
                    netMessage.Write((byte)tgmodMessageType.ConfigSyncRequest);
                    netMessage.Send();
                }
            }
            if (Config.forceRolling)
            {
                if (Main.myPlayer == player.whoAmI && (playerClass == ClassID.classless || playerFaction == FactionID.human || playerGimmick == GimmickID.gimmickless))
                {
                    player.AddBuff(BuffID.Frozen, 5);
                }
            }
            ZoneUpdates();
            ClassDamageModifications();
            GimmickUpdates();
            FactionUpdates();
        }

        private void ZoneUpdates()
        {
            if (player.position.Y > Main.spawnTileY * 16 - 50 * 16 && Math.Abs(player.position.X - Main.spawnTileX * 16) < 80 * 16)
            {
                inNeutralZone = true;
            }
            if (player.FindBuffIndex(mod.BuffType<Buffs.FactionNeutral>()) > 0)
            {
                inNeutralZone = true;
            }
            if (player.ZoneDungeon)
            {
                inNeutralZone = true;
            }
        }

        private void FactionUpdates()
        {
            if (multicultured || inNeutralZone)
            {
                return;
            }

            if (playerFaction == FactionID.dwarf)
            {
                if (player.ZoneOverworldHeight)
                {
                    if (!player.buffImmune[BuffID.Weak]) player.AddBuff(BuffID.Weak, 5);
                    if (!player.buffImmune[BuffID.Confused]) player.AddBuff(BuffID.Confused, 5);
                    if (!player.buffImmune[BuffID.Slow]) player.AddBuff(BuffID.Slow, 5);
                    if (!player.buffImmune[BuffID.Bleeding]) player.AddBuff(BuffID.Bleeding, 5);
                    if (!player.buffImmune[BuffID.Poisoned]) player.AddBuff(BuffID.Poisoned, 5);
                }
                if (player.ZoneSkyHeight)
                {
                    if (!player.buffImmune[BuffID.Suffocation]) player.AddBuff(BuffID.Suffocation, 5);
                    if (!player.buffImmune[BuffID.Slow]) player.AddBuff(BuffID.Slow, 5);
                    if (!player.buffImmune[BuffID.Bleeding]) player.AddBuff(BuffID.Bleeding, 5);
                    if (!player.buffImmune[BuffID.Poisoned]) player.AddBuff(BuffID.Poisoned, 5);
                }
            }
            if (playerFaction == FactionID.elf && !elvenBlessing)
            {
                if (player.ZoneDirtLayerHeight)
                {
                    if (!player.buffImmune[BuffID.Darkness]) player.AddBuff(BuffID.Darkness, 5);
                    if (!player.buffImmune[BuffID.Weak]) player.AddBuff(BuffID.Weak, 5);
                    if (!player.buffImmune[BuffID.Poisoned]) player.AddBuff(BuffID.Poisoned, 5);
                }
                else if (player.ZoneRockLayerHeight)
                {
                    if (!player.buffImmune[BuffID.Blackout]) player.AddBuff(BuffID.Blackout, 5);
                    if (!player.buffImmune[BuffID.Bleeding]) player.AddBuff(BuffID.Bleeding, 5);
                    if (!player.buffImmune[BuffID.Weak]) player.AddBuff(BuffID.Weak, 5);
                    if (!player.buffImmune[BuffID.Poisoned]) player.AddBuff(BuffID.Poisoned, 5);
                }
                else if (player.ZoneUnderworldHeight)
                {
                    if (!player.buffImmune[BuffID.Horrified]) player.AddBuff(BuffID.Horrified, 5);
                    if (!player.buffImmune[BuffID.Bleeding]) player.AddBuff(BuffID.Bleeding, 5);
                    if (!player.fireWalk)
                    {
                        player.AddBuff(BuffID.Burning, 5);
                    }
                }
            }
        }

        private void ClassDamageModifications()
        {

            // first deal with classes and the damage buffs/debuffs that come with them
            if (playerClass != ClassID.classless)
            {
                player.meleeDamage -= damageLoss;
                player.rangedDamage -= damageLoss;
                player.magicDamage -= damageLoss;
                player.minionDamage -= damageLoss;
                player.thrownDamage -= damageLoss;
            }
            if (playerClass == ClassID.swordsman || playerClass == ClassID.yoyoman)
            {
                player.meleeDamage += damageBoost;
            }
            if (playerClass == ClassID.mage)
            {
                player.magicDamage += damageBoost;
            }
            if (playerClass == ClassID.summoner)
            {
                player.minionDamage += damageBoost;
            }
            if (playerClass == ClassID.archer)
            {
                // allowing ranged classes to use ranged weapons that aren't arrow, bullet or rocket based
                player.rangedDamage += damageLoss;
                player.arrowDamage -= damageLoss;
                player.bulletDamage -= damageLoss;
                player.rocketDamage -= damageLoss;

                player.arrowDamage += damageBoost;
            }
            if (playerClass == ClassID.gunner)
            {
                // allowing ranged classes to use ranged weapons that aren't arrow, bullet or rocket based  
                player.rangedDamage += damageLoss;
                player.arrowDamage -= damageLoss;
                player.bulletDamage -= damageLoss;
                player.rocketDamage -= damageLoss;

                player.bulletDamage += damageBoost;
                player.rocketDamage += damageBoost;
            }
            if (playerClass == ClassID.thrower)
            {
                player.thrownDamage += damageBoost;
            }
            if (tgmod.instance.thoriumLoaded)
            {
                ThoriumClassDamageModifications();
            }
        }

        private void ThoriumClassDamageModifications()
        {
            if (playerClass != ClassID.classless)
            {
                player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).radiantBoost -= damageLoss;
                player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).symphonicDamage -= damageLoss;
            }
            if (playerClass == ClassID.bard)
            {
                player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).symphonicDamage += damageBoost;
            }
            if (playerClass == ClassID.healer)
            {
                // possible problems with there is -50% from class and -50% from armor for -100% magic damage, since healer items 
                // have the item.magic field set to true
                player.magicDamage += damageLoss; 
                player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).radiantBoost += damageBoost;
            }
        }

        private void GimmickUpdates()
        {
            if (!multicultured)
            {
                switch (playerGimmick)
                {
                    case GimmickID.vampire:
                        if (!player.behindBackWall && Main.dayTime && player.ZoneOverworldHeight && !player.ZoneRain && !Main.eclipse)
                        {
                            if (!player.buffImmune[BuffID.OnFire])
                            {
                                player.AddBuff(BuffID.OnFire, 5);
                            }
                        }
                        break;
                    case GimmickID.aquaphobia:
                        player.breathMax = 10;
                        if (player.ZoneRain && player.ZoneOverworldHeight)
                        {
                            if (!player.buffImmune[BuffID.Chilled])
                            {
                                player.AddBuff(BuffID.Chilled, 5);
                            }
                        }
                        break;
                    case GimmickID.hermit:
                        int nearbyPlayerCount = 0;
                        foreach (Player p in Main.player)
                        {
                            if (p.active)
                            {
                                float distance = (p.position - player.position).LengthSquared();
                                if (distance < 500 * 500)
                                {
                                    nearbyPlayerCount++;
                                }
                            }
                        }
                        if (nearbyPlayerCount > 1)
                        {
                            if (!player.buffImmune[BuffID.Weak]) player.AddBuff(BuffID.Weak, 5);
                            if (!player.buffImmune[BuffID.Slow]) player.AddBuff(BuffID.Slow, 5);
                            if (!player.buffImmune[BuffID.Wet]) player.AddBuff(BuffID.Wet, 5);
                        }
                        break;
                    case GimmickID.claustrophobia:
                        if (player.behindBackWall)
                        {
                            if (!player.buffImmune[BuffID.Horrified]) player.AddBuff(BuffID.Horrified, 5);
                            if (!player.buffImmune[BuffID.Weak]) player.AddBuff(BuffID.Weak, 5);
                        }
                        break;
                    case GimmickID.acrophobia:
                        break;
                    default:
                        break;

                }
            }
        }

        public override void UpdateBadLifeRegen()
        {
            if (multicultured)
            {
                return;
            }
            if (playerGimmick == GimmickID.aquaphobia && player.wet)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 5;
            }
            if (playerGimmick == GimmickID.acrophobia && Math.Abs(player.velocity.Y) > 5)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 5;
            }
        }
    }

    class ClassID
    {
        public const short classless = 0;
        public const short swordsman = 1;
        public const short mage = 2;
        public const short archer = 3;
        public const short summoner = 4;
        public const short gunner = 5;
        public const short yoyoman = 6;
        public const short thrower = 7;
        public const short healer = 8;
        public const short bard = 9;
        public const short classMaxValue = 7;
        public const short classMaxValueThorium = 9;

        public static string GetClassName(int playerClass)
        {
            switch (playerClass)
            {
                case 0:
                    return "classless";
                case 1:
                    return "Swordsman";
                case 2:
                    return "Mage";
                case 3:
                    return "Archer";
                case 4:
                    return "Summoner";
                case 5:
                    return "Gunner";
                case 6:
                    return "Yoyo-man";
                case 7:
                    return "Thrower";
                case 8:
                    return "Healer";
                case 9:
                    return "Bard";
                default:
                    return "Class display values need an update";
            }
        }
    }

    class GimmickID
    {
        public const short gimmickless = 0;
        public const short vampire = 1;
        public const short aquaphobia = 2;
        public const short hermit = 3;
        public const short claustrophobia = 4;
        public const short acrophobia = 5;
        public const short gimmickMaxValue = 5;

        public static string GetGimmickName(int playerGimmick)
        {
            switch (playerGimmick)
            {
                case 0:
                    return "have no gimmick";
                case 1:
                    return "are a vampire";
                case 2:
                    return "have aquaphobia";
                case 3:
                    return "are a hermit";
                case 4:
                    return "have claustrophobia";
                case 5:
                    return "have acrophobia";
                default:
                    return "Gimmick display values need an update";
            }
        }
    }

    class FactionID
    {
        public const short human = 0;
        public const short elf = 1;
        public const short dwarf = 2;
        public const short factionMaxValue = 2;
        
        public static string GetFactionName(int playerFaction)
        {
            switch (playerFaction)
            {
                case 0:
                    return "human";
                case 1:
                    return "elf";
                case 2:
                    return "dwarf";
                default:
                    return "Faction display values need an update";
            }
        }
    }
}
