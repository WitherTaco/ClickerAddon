using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.Tiles
{
	public class MiceMonolith : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Don`t worked");
		}

		public override void SetDefaults() 
		{
			item.width = 16;
			item.height = 16;
			item.value = 0;
			item.rare = ItemRarityID.Cyan;
			item.maxStack = 99;

			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;

			item.createTile = mod.TileType("MiceMonolith");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod clickerClass = ModLoader.GetMod("ClickerClass");

			recipe.AddIngredient(clickerClass.ItemType("MiceFragment"), 15);

			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
