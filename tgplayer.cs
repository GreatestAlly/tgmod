using System;
using System.IO;
using System.Linq;
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
                player.arrowDamage -= damageLoss;
                player.bulletDamage -= damageLoss;
                player.rocketDamage -= damageLoss;
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
                player.arrowDamage += damageBoost;
            }
            if (playerClass == ClassID.gunner)
            {
                player.bulletDamage += damageBoost;
                player.rocketDamage += damageBoost;
            }
            if (playerClass == ClassID.thrower)
            {
                player.thrownDamage += damageBoost;
            }
            if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
            {
                if (playerClass == ClassID.bard)
                {
                    player.magicDamage += damageLoss;
                }
                if (playerClass == ClassID.healer)
                {
                    player.magicDamage += damageLoss;
                }
            }
        }

        private void GimmickUpdates()
        {
            if (!multicultured)
            {
                if (playerGimmick == GimmickID.vampire)
                {
                    /*
                    Main.NewText("player zoneunderworldheight " + player.ZoneUnderworldHeight);
                    Main.NewText("player zonerocklayerheight " + player.ZoneRockLayerHeight);
                    Main.NewText("player zonedirtlayerheight " + player.ZoneDirtLayerHeight);
                    Main.NewText("player zoneoverworldheight " + player.ZoneOverworldHeight);
                    Main.NewText("player zoneskylayerheight" + player.ZoneSkyHeight);
                    */
                    if (!player.behindBackWall && Main.dayTime && player.ZoneOverworldHeight && !player.ZoneRain && !Main.eclipse)
                    {
                        if (!player.buffImmune[BuffID.OnFire])
                        {
                            player.AddBuff(BuffID.OnFire, 5);
                        }
                    }
                }
                if (playerGimmick == GimmickID.aquaphobia)
                {
                    player.breathMax = 10;
                    if (player.ZoneRain && player.ZoneOverworldHeight)
                    {
                        if (!player.buffImmune[BuffID.Chilled])
                        {
                            player.AddBuff(BuffID.Chilled, 5);
                        }
                    }
                }
                if (playerGimmick == GimmickID.hermit)
                {
                    int nearbyPlayerCount = 0;
                    foreach (Player p in Main.player)
                    {
                        float distance = (p.position - player.position).LengthSquared();
                        if (distance < 1000000)
                        {
                            nearbyPlayerCount++;
                        }
                    }
                    if (nearbyPlayerCount > 1)
                    {
                        if (!player.buffImmune[BuffID.Weak]) player.AddBuff(BuffID.Weak, 5);
                        if (!player.buffImmune[BuffID.Slow]) player.AddBuff(BuffID.Slow, 5);
                        if (!player.buffImmune[BuffID.Wet]) player.AddBuff(BuffID.Wet, 5);
                    }
                }
                if (playerGimmick == GimmickID.claustrophobia)
                {
                    if (player.behindBackWall)
                    {
                        if (!player.buffImmune[BuffID.Horrified]) player.AddBuff(BuffID.Horrified, 5);
                        if (!player.buffImmune[BuffID.Weak]) player.AddBuff(BuffID.Weak, 5);
                    }
                }
            }
        }

        public override void UpdateBadLifeRegen()
        {
            base.UpdateBadLifeRegen();
            if (playerGimmick == GimmickID.aquaphobia && player.wet)
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
                    return "classless";
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
        public const short gimmickMaxValue = 4;

        public static string GetGimmickName(int playerGimmick)
        {
            switch (playerGimmick)
            {
                case 1:
                    return "are a vampire";
                case 2:
                    return "have aquaphobia";
                case 3:
                    return "are a hermit";
                case 4:
                    return "have claustrophobia";
                default:
                    return "have no gimmick";
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
                case 1:
                    return "elf";
                case 2:
                    return "dwarf";
                default:
                    return "human";
            }
        }
    }
}
