using System;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using tgmod;

namespace tgmod.Commands
{
    class Rerolling : ModCommand
    {
        public override string Command
        {
            get
            {
                return "rerolling";
            }
        }

        public override CommandType Type
        {
            get
            {
                return CommandType.Chat;
            }
        }

        public override string Description
        {
            get
            {
                return "reroll your character :^)";
            }
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            //caller.Player.KillMeForGood();
            caller.Player.KillMe(Terraria.DataStructures.PlayerDeathReason.ByCustomReason(caller.Player.name + " rerolled :^)"), 9999, 0);
            
            /*
            tgplayer newPlayer = caller.Player.GetModPlayer<tgplayer>();
            if (newPlayer.playerRace != RaceID.human)
            {
                caller.Reply("You already have a faction.");
                return;
            }
            if (newPlayer.playerClass == ClassID.classless || newPlayer.playerQuirk == QuirkID.quirkless)
            {
                caller.Reply("Use the normal roll function.");
                return;
            }
            newPlayer.playerRace = Main.rand.Next(1, RaceID.raceMaxValue + 1);
            newPlayer.playerQuirk = Main.rand.Next(1, QuirkID.quirkMaxValue + 1);
            caller.Reply("You are now a(n) " + RaceID.GetRaceName(newPlayer.playerRace) + " and you " + QuirkID.GetQuirkName(newPlayer.playerQuirk) + ".");
            */
            /*
            tgplayer newPlayer = caller.Player.GetModPlayer<tgplayer>();
            if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
            {
                newPlayer.playerClass = Main.rand.Next(1, ClassID.classMaxValueThorium + 1);
            }
            else
            {
                newPlayer.playerClass = Main.rand.Next(1, ClassID.classMaxValue + 1);
            }
            newPlayer.playerRace = Main.rand.Next(1, RaceID.raceMaxValue + 1);
            newPlayer.playerQuirk = Main.rand.Next(1, QuirkID.quirkMaxValue + 1);
            caller.Reply("Your class is now " + ClassID.GetClassName(newPlayer.playerClass) + ".");
            caller.Reply("You are a(n) " + RaceID.GetRaceName(newPlayer.playerRace) + ".");
            caller.Reply("You " + QuirkID.GetQuirkName(newPlayer.playerQuirk) + ".");
            */
        }
    }
}
