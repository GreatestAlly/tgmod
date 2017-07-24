using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace tgmod.Tiles
{
    class LivingMahogany : GlobalTile
    {
        public override bool Drop(int i, int j, int type)
        {
            if (type == TileID.LivingMahoganyLeaves)
            {
                Item.NewItem(i * 16, j * 16, 0, 0, mod.ItemType<Items.Placeable.LivingMahoganyLeafBlock>());
                return base.Drop(i, j, type);
            }
            return base.Drop(i, j, type);
        }
    }
}
