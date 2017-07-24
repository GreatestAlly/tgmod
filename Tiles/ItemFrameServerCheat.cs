using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tgmod.Tiles
{
    class ItemFrameServerCheat : GlobalTile
    {
        public override bool CanPlace(int i, int j, int type)
        {
            if (type == TileID.ItemFrame) {
                for (int k = -1; k <= 2; k++)
                {
                    for (int l = 0; l <= 1; l++)
                    {
                        int temp = Main.tile[i + k, j + l].type;
                        if (temp == TileID.ClosedDoor)
                        {
                            return false;
                        }
                        if (temp == TileID.OpenDoor)
                        {
                            return false;
                        }
                    }
                }
                for (int m = 0; m <= 1; m++)
                {
                    int temp2 = Main.tile[i + m, j + 2].type;
                    if (temp2 == TileID.TrapdoorClosed)
                    {
                        return false;
                    }
                    if (temp2 == TileID.TrapdoorOpen)
                    {
                        return false;
                    }
                }
            }
            return base.CanPlace(i, j, type);
        }
        
    }
}
