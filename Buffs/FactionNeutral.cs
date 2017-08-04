using Terraria;
using Terraria.ModLoader;

namespace tgmod.Buffs
{
    class FactionNeutral : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Neutral Zone");
            Description.SetDefault("Created by a statue");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<tgplayer>().inNeutralZone = true;
            base.Update(player, ref buffIndex);
        }
    }
}
