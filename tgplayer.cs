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
        public int playerQuirk = QuirkID.quirkless;
        public int playerRace = RaceID.human;
        public int extraFishingLines = 0;
        public bool multicultured = false;

        public override void ResetEffects()
        {
            multicultured = false;
            extraFishingLines = 0;
        }

        public override TagCompound Save()
        {
            return new TagCompound
            {
                {"class", playerClass },
                {"quirk", playerQuirk },
                {"race", playerRace }
            };
        }

        public override void Load(TagCompound tag)
        {
            playerClass = tag.GetInt("class");
            playerQuirk = tag.GetInt("quirk");
            playerRace = tag.GetInt("race");
        }

        public override void PostUpdateEquips()
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

            // quirks are dealt with here 
            if (multicultured)
            {
                return;
            }

            if (playerQuirk == QuirkID.vampire)
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
            if (playerQuirk == QuirkID.aquaphobia)
            {
                player.breathMax = 10;
                if (player.wet)
                {
                    player.lifeRegen = -5;
                }
                if (player.ZoneRain && player.ZoneOverworldHeight)
                {
                    if (!player.buffImmune[BuffID.Chilled])
                    {
                        player.AddBuff(BuffID.Chilled, 5);
                    }
                }
            }
            if (playerQuirk == QuirkID.hermit)
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
            if (playerQuirk == QuirkID.claustrophobia)
            {
                if (player.behindBackWall)
                {
                    if (!player.buffImmune[BuffID.Horrified]) player.AddBuff(BuffID.Horrified, 5);
                    if (!player.buffImmune[BuffID.Weak]) player.AddBuff(BuffID.Weak, 5);
                }
            }


            if (playerRace == RaceID.dwarf && !player.ZoneDungeon)
            {
                if (player.ZoneOverworldHeight)
                {
                    if (!player.buffImmune[BuffID.Weak]) player.AddBuff(BuffID.Weak, 5);
                    if (!player.buffImmune[BuffID.Confused]) player.AddBuff(BuffID.Confused, 5);
                    if (!player.buffImmune[BuffID.Slow]) player.AddBuff(BuffID.Slow, 5);
                    if (!player.buffImmune[BuffID.Bleeding]) player.AddBuff(BuffID.Bleeding, 5);
                }
                if (player.ZoneSkyHeight)
                {
                    if (!player.buffImmune[BuffID.Suffocation]) player.AddBuff(BuffID.Suffocation, 5);
                    if (!player.buffImmune[BuffID.Slow]) player.AddBuff(BuffID.Slow, 5);
                }
            }
            if (playerRace == RaceID.elf && !player.ZoneJungle && !player.ZoneDungeon)
            {
                if (player.ZoneDirtLayerHeight)
                {
                    if (!player.buffImmune[BuffID.Darkness]) player.AddBuff(BuffID.Darkness, 5);
                    if (!player.buffImmune[BuffID.Weak]) player.AddBuff(BuffID.Weak, 5);
                }
                else if (player.ZoneRockLayerHeight)
                {
                    if (!player.buffImmune[BuffID.Blackout]) player.AddBuff(BuffID.Blackout, 5);
                    if (!player.buffImmune[BuffID.Bleeding]) player.AddBuff(BuffID.Bleeding, 5);
                    if (!player.buffImmune[BuffID.Weak]) player.AddBuff(BuffID.Weak, 5);
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

    class QuirkID
    {
        public const short quirkless = 0;
        public const short vampire = 1;
        public const short aquaphobia = 2;
        public const short hermit = 3;
        public const short claustrophobia = 4;
        public const short quirkMaxValue = 4;

        public static string GetQuirkName(int playerQuirk)
        {
            switch (playerQuirk)
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

    class RaceID
    {
        public const short human = 0;
        public const short elf = 1;
        public const short dwarf = 2;
        public const short raceMaxValue = 2;
        
        public static string GetRaceName(int playerRace)
        {
            switch (playerRace)
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
