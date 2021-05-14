using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.Materials
{
	public class RainbowGel : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}
		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			/*Tooltip.SetDefault("15% increased clicker damage");*/
		}

		public override void SetDefaults() 
		{
			item.width = 16;
			item.height = 22;
			item.value = 0;
			item.rare = ItemRarityID.LightRed;
			item.maxStack = 999;
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB));
		}

		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddRecipeGroup("Wood", 1);
			recipe.AddIngredient(this, 1);

			//recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(ItemID.RainbowTorch, 3);
			recipe.AddRecipe();


			recipe = new ModRecipe(mod);

			recipe.AddIngredient(ItemID.StoneBlock, 1);
			recipe.AddIngredient(this, 1);

			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(ItemID.RainbowBrick, 1);
			recipe.AddRecipe();


			recipe = new ModRecipe(mod);

			recipe.AddIngredient(ItemID.GelDye, 1);
			recipe.AddIngredient(this, 1);

			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(ItemID.LivingRainbowDye);
			recipe.AddRecipe();


			recipe = new ModRecipe(mod);

			recipe.AddIngredient(ItemID.GelDye, 1);
			recipe.AddIngredient(this, 1);

			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(ItemID.RainbowDye);
			recipe.AddRecipe();
		}
	}
}
