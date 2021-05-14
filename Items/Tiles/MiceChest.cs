using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.Tiles
{
	public class MiceChest : ModItem
	{
		public override void SetStaticDefaults() 
		{
			/*Tooltip.SetDefault("15% increased clicker damage");*/
		}

		public override void SetDefaults() 
		{
			item.width = 16;
			item.height = 16;
			item.value = 0;
			item.rare = ItemRarityID.White;
			item.maxStack = 99;

			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;

			item.createTile = mod.TileType("MiceChest");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod clickerClass = ModLoader.GetMod("ClickerClass");

			recipe.AddIngredient(mod.ItemType("MiceBrick"), 8);
			recipe.AddIngredient(ItemID.IronBar, 2);

			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();


			recipe = new ModRecipe(mod);

			recipe.AddIngredient(mod.ItemType("MiceBrick"), 8);
			recipe.AddIngredient(ItemID.LeadBar, 2);

			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
