using System;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using tgmod;

namespace tgmod.Commands
{
    class DisplayFaction : ModCommand
    {
        public override string Command
        {
            get
            {
                return "faction";
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
                return "Check your faction.";
            }
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            tgplayer newPlayer = caller.Player.GetModPlayer<tgplayer>();
            caller.Reply("You are a(n) " + FactionID.GetFactionName(newPlayer.playerFaction) + ".");
        }
    }
}
