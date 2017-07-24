using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace tgmod.Items
{
    class PirateMapStacking : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            base.SetDefaults(item);
            if (item.type == ItemID.PirateMap)
            {
                if (item.maxStack < 99)
                {
                    item.maxStack = 99;
                }
            }
        }
    }
}
