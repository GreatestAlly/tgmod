using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace tgmod.Items
{
    class DwarfFactionHelper : GlobalItem
    {
        public override bool CanEquipAccessory(Item item, Player player, int slot)
        {
            if (player.GetModPlayer<tgplayer>().playerFaction == FactionID.dwarf)
            {
                if (item.wingSlot > 0)
                {
                    if (item.type != ItemID.Jetpack && item.type != ItemID.WingsVortex && item.type != ItemID.Hoverboard && item.type != ItemID.SteampunkWings)
                    {
                        return false;
                    }
                }
            }
            return base.CanEquipAccessory(item, player, slot);
        }
    }
}
