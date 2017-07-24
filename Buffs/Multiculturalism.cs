using System;
using Terraria;
using Terraria.ModLoader;

namespace tgmod.Buffs
{
    class Multiculturalism : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Multiculturalism");
            Description.SetDefault("Do you feel cultured now?");
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<tgplayer>().multicultured = true;
        }
    }
}
