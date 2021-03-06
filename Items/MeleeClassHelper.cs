﻿using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace tgmod.Items
{
    class MeleeClassHelper : GlobalItem
    {
        public override void GetWeaponDamage(Item item, Player player, ref int damage)
        {
            // damage reduction for swords / swordless items for the opposite classes. 
            if (item.melee)
            {
                if (item.noMelee)
                {
                    if (player.GetModPlayer<tgplayer>().playerClass == ClassID.swordsman)
                    {
                        damage = (int)(damage * (player.meleeDamage - tgplayer.damageBoost) / player.meleeDamage);
                    }
                }
                else
                {
                    if (player.GetModPlayer<tgplayer>().playerClass == ClassID.yoyoman)
                    {
                        damage = (int)(damage * (player.meleeDamage - tgplayer.damageBoost) / player.meleeDamage);
                    }
                }
            }

            // for debug purposes
            /*
            if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
            {
                if (item.magic)
                {
                    Main.NewText("Found Item: " + item.Name);
                    Main.NewText("Item Width: " + item.width);
                }
            }
            */

            base.GetWeaponDamage(item, player, ref damage);
        }
    }
}
