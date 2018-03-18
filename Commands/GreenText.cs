using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ID;

namespace tgmod.Commands
{
    class GreenText : ModCommand
    {
        public override string Command
        {
            get
            {
                return ">";
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
                return "";
            }
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(">" + input.Substring(3), new Color(0, 255, 0));
            }
            else if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                var netMessage = mod.GetPacket();
                netMessage.Write((byte)tgmodMessageType.GreenText);
                netMessage.Write(caller.Player.name);
                netMessage.Write(">" + input.Substring(3));
                netMessage.Send();
            }
        }

    }
}
