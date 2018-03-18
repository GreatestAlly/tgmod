using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace tgmod.NPCs
{
    class PartyGirl : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            if (npc.type == NPCID.PartyGirl)
            {
                if (!npc.GivenName.EndsWith(")"))
                {
                    npc.GivenName = npc.GivenName + " (male)";
                }
            }
        }

        public override bool PreAI(NPC npc)
        {
            if (npc.type == NPCID.PartyGirl)
            {
                if (!npc.GivenName.EndsWith(")"))
                {
                    npc.GivenName = npc.GivenName + " (male)";
                }
                while (npc.GivenName.EndsWith(" (male) (male)"))
                {
                    int l = npc.GivenName.Length;
                    npc.GivenName = npc.GivenName.Remove(l - 7);
                }
            }
            return base.PreAI(npc);
        }

        public override void GetChat(NPC npc, ref string chat)
        {
            if (Main.rand.Next(10) == 0)
            {
                chat = "Something something horsecock.";
            }
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.PartyGirl)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Armor.penetrator>());
                nextSlot++;
            }
        }
    }
}
