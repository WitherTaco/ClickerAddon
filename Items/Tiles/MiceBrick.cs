using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.Tiles
{
	public class MiceBrick : ModItem
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
			item.maxStack = 999;

			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;

			item.createTile = mod.TileType("MiceBrick");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod clickerClass = ModLoader.GetMod("ClickerClass");

			recipe.AddIngredient(ItemID.StoneBlock, 10);
			recipe.AddIngredient(clickerClass.ItemType("MiceFragment"));

			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 10);
			recipe.AddRecipe();


			recipe = new ModRecipe(mod);

			recipe.AddIngredient(mod.ItemType("MicePlatform"), 2);

			//recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();


			recipe = new ModRecipe(mod);

			recipe.AddIngredient(mod.ItemType("MiceBrickWall"), 4);

			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
