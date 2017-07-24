using System;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using tgmod;

namespace tgmod.Commands
{
    class RollingCommand : ModCommand
    {
        public override string Command
        {
            get
            {
                return "rolling";
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
                return "Roll for your class and gimmick.";
            }
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            tgplayer newPlayer = caller.Player.GetModPlayer<tgplayer>();
            if (newPlayer.playerClass != ClassID.classless || newPlayer.playerGimmick != GimmickID.gimmickless)
            {
                caller.Reply("You already have a class or a gimmick!");
                return;
            }
            if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
            {
                newPlayer.playerClass = Main.rand.Next(1, ClassID.classMaxValueThorium + 1);
            } else
            {
                newPlayer.playerClass = Main.rand.Next(1, ClassID.classMaxValue + 1);
            }

            if (args[0] == "elf")
            {
                newPlayer.playerFaction = FactionID.elf;
            }
            else if (args[0] == "dwarf")
            {
                newPlayer.playerFaction = FactionID.dwarf;
            }
            else
            {
                newPlayer.playerFaction = Main.rand.Next(1, FactionID.factionMaxValue + 1);
            }
            newPlayer.playerGimmick = Main.rand.Next(1, GimmickID.gimmickMaxValue + 1);
            caller.Reply("Your class is now " + ClassID.GetClassName(newPlayer.playerClass) + ".");
            caller.Reply("You are a(n) " + FactionID.GetFactionName(newPlayer.playerFaction) + ".");
            caller.Reply("You " + GimmickID.GetGimmickName(newPlayer.playerGimmick) + ".");
        }
    }
}
