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
    class Candle : GlobalTile
    {
        public override bool CanPlace(int i, int j, int type)
        {
            return base.CanPlace(i, j, type);
        }
    }
}
