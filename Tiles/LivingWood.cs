using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace tgmod.Tiles
{
    class LivingWood : GlobalTile
    {
        public override bool Drop(int i, int j, int type)
        {
            if (type == TileID.LeafBlock)
            {
                Item.NewItem(i * 16, j * 16, 0, 0, mod.ItemType<Items.Placeable.LivingLeafBlock>());
                return base.Drop(i, j, type);
            }
            return base.Drop(i, j, type);
        }
    }
}
