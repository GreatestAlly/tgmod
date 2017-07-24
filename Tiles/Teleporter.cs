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
    class Teleporter : GlobalTile
    {

        public override void AnimateTile()
        {
            Main.tileLighted[TileID.Teleporter] = false;
        }

    }
}
