using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace tgmod.Commands
{
    class NewName : ModCommand
    {
        public override string Command
        {
            get
            {
                return "newname";
            }
        }

        public override CommandType Type
        {
            get
            {
                return CommandType.Chat;
            }
        }

        public override string Usage
        {
            get
            {
                return "/newname [name]";
            }
        }

        public override string Description
        {
            get
            {
                return "Change your name.";
            }
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            string newName = input.Substring("/newname ".Length);
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(caller.Player.name + " has changed their name to " + newName);
            }
            else if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                var netMessage = mod.GetPacket();
                netMessage.Write((byte)tgmodMessageType.NameChange);
                netMessage.Write(caller.Player.name);
                netMessage.Write(newName);
                netMessage.Send();
                //NetworkText text = NetworkText.FromLiteral(caller.Player.name + " has changed their name to " + newName + ".");
                //NetMessage.BroadcastChatMessage(text, new Color(255, 25, 25));
            }
            caller.Player.name = newName;
        }
    }
}
