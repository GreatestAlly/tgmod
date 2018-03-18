using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace tgmod.Tiles
{
    class FishGrinderHelper : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.questItem)
            {
                item.useStyle = 1;
                item.useAnimation = 15;
                item.useTime = 10;
                item.consumable = true;
                item.useTurn = true;
                item.autoReuse = true;
                item.maxStack = 99;
            }
        }

        public override bool CanUseItem(Item item, Player player)
        {
            if (item.questItem)
            {
                if (Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.tile[Player.tileTargetX, Player.tileTargetY].type == mod.TileType<FishGrinderTile>())
                {
                    if (Math.Abs((player.position.X + player.width / 2.0) / 16.0 - Player.tileTargetX) < Player.tileRangeX &&
                        Math.Abs((player.position.Y + player.height / 2.0) / 16.0 - Player.tileTargetY) < Player.tileRangeY)
                    {
                        return true;
                    }
                }
            }
            return base.CanUseItem(item, player);
        }

        public override bool UseItem(Item item, Player player)
        {
            // essentially replicating the extractinator use code
            // Might have server/client side runtime issues
            // should not have any single player issues. 
            if (item.questItem)
            {
                if (Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.tile[Player.tileTargetX, Player.tileTargetY].type == mod.TileType<FishGrinderTile>())
                {
                    if (Math.Abs((player.position.X + player.width / 2.0) / 16.0 - Player.tileTargetX) < Player.tileRangeX &&
                        Math.Abs((player.position.Y + player.height / 2.0) / 16.0 - Player.tileTargetY) < Player.tileRangeY)
                    {
                        /*
                        int Type = ItemID.DirtBlock;
                        int Stack = 1;

                        

                        Vector2 vector2 = Vector2.Add(Main.ReverseGravitySupport(Main.MouseScreen), Main.screenPosition);
                        int number = Item.NewItem((int)vector2.X, (int)vector2.Y, 1, 1, Type, Stack, false, -1, false, false);
                        if (Main.netMode == 1)
                        {
                            NetMessage.SendData(21, -1, -1, (NetworkText)null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
                        }
                        */
                        player.GetAnglerReward();
                        if (player.anglerQuestsFinished < 150)
                        {
                            player.anglerQuestsFinished++;
                        } else if (player.anglerQuestsFinished > 150)
                        {
                            player.anglerQuestsFinished = 150;
                        }
                        return true;
                    }
                }
            }
            return base.UseItem(item, player);
        }
    }
}
