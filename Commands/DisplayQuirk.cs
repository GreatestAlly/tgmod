using System;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using tgmod;

namespace tgmod.Commands
{
    class DisplayQuirk : ModCommand
    {
        public override string Command
        {
            get
            {
                return "gimmick";
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
                return "Check your gimmick.";
            }
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            tgplayer newPlayer = caller.Player.GetModPlayer<tgplayer>();
            caller.Reply("Your gimmick is that you " + QuirkID.GetQuirkName(newPlayer.playerQuirk) + ".");
        }
    }
}
