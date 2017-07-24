using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace tgmod
{
	class tgmod : Mod
	{
		public tgmod()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Bone, 1);
            recipe.SetResult(ItemID.BoneBlock, 1);
            recipe.AddRecipe();
        }
	}
}
