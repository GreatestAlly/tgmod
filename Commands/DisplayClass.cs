using System;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using tgmod;

namespace tgmod.Commands
{
    class DisplayClass : ModCommand
    {
        public override string Command
        {
            get
            {
                return "class";
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
                return "Check your class.";
            }
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            tgplayer newPlayer = caller.Player.GetModPlayer<tgplayer>();
            caller.Reply("Your class is " + ClassID.GetClassName(newPlayer.playerClass) + ".");
        }
    }
}
