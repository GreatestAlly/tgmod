using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using System.IO;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace tgmod
{
	class tgmod : Mod
	{
        internal bool thoriumLoaded;

        static internal tgmod instance;

		public tgmod()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}

        public override void Load()
        {
            Config.Load();
            instance = this;
        }

        public override void PostSetupContent()
        {
            thoriumLoaded = ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void PreSaveAndQuit()
        {
            Config.netSynced = false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Bone, 1);
            recipe.AddTile(TileID.BoneWelder);
            recipe.SetResult(ItemID.BoneBlock, 1);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Cloud, 1);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(ItemID.Cobweb, 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Leather, 2);
            recipe.AddIngredient(ItemID.FancyGreyWallpaper, 5);
            recipe.SetResult(ItemID.Book);
            recipe.AddRecipe();
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            tgmodMessageType msgType = (tgmodMessageType)reader.ReadByte();
            switch (msgType)
            {
                case tgmodMessageType.NameChange:
                    if (Main.netMode == NetmodeID.Server)
                    {
                        string oldName = reader.ReadString();
                        string newName = reader.ReadString();
                        NetworkText text = NetworkText.FromLiteral(oldName + " has changed their name to " + newName + ".");
                        NetMessage.BroadcastChatMessage(text, new Color(255, 25, 25));
                    }
                    break;
                case tgmodMessageType.ConfigSyncRequest:
                    if (Main.netMode == NetmodeID.Server)
                    {
                        // clients check for whether the config is synced. Just send out the values here. 
                        var netMessage = GetPacket();
                        netMessage.Write((byte)tgmodMessageType.ConfigValues);
                        netMessage.Write(Config.forceRolling);
                        netMessage.Write(Config.sellSummons);
                        netMessage.Write(Config.chooseClass);
                        netMessage.Send();
                    }
                    break;
                case tgmodMessageType.ConfigValues:
                    if (Main.netMode == NetmodeID.MultiplayerClient && !Config.netSynced)
                    {
                        Config.forceRolling = reader.ReadBoolean();
                        Config.sellSummons = reader.ReadBoolean();
                        Config.chooseClass = reader.ReadBoolean();
                        Config.netSynced = true;
                    }
                    break;
                case tgmodMessageType.GreenText:
                    if (Main.netMode == NetmodeID.Server)
                    {
                        string name = reader.ReadString();
                        string text = reader.ReadString();
                        
                        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral(text), new Color(0, 255, 0), -1);
                    }
                    break;
                default:
                    ErrorLogger.Log("tgmod: Unknown Message Type: " + msgType);
                    break;
            }
        }
    }
}

enum tgmodMessageType : byte
{
    NameChange,
    ConfigSyncRequest,
    ConfigValues,
    GreenText
}
