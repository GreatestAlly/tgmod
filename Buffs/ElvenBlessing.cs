using Terraria;
using Terraria.ModLoader;

namespace tgmod.Buffs
{
    class ElvenBlessing : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Elven Blessing");
            Description.SetDefault("Blessed by nature");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<tgplayer>().elvenBlessing = true;
            base.Update(player, ref buffIndex);
        }
    }
}
