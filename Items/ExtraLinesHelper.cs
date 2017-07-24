using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace tgmod.Items
{
    class ExtraLinesHelper : GlobalItem
    {
        public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (item.fishingPole > 1)
            {
                int extraLines = player.GetModPlayer<tgplayer>().extraFishingLines;
                double perturbAngle = Math.PI / 16f;
                for (int i = 0; i < extraLines; i++)
                {
                    Projectile.NewProjectile(position, new Vector2(speedX, speedY).RotatedByRandom(perturbAngle), type, damage, knockBack, player.whoAmI);
                }
            }
            return base.Shoot(item, player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
    }
}
