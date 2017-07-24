using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace tgmod.NPCs
{
    class AnglerShop : GlobalNPC
    {
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.Angler)
            {
                shop.item[nextSlot].SetDefaults(ItemID.ApprenticeBait);
                nextSlot++;
            }
            base.SetupShop(type, shop, ref nextSlot);
        }

    }
}
 