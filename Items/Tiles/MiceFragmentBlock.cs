using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.Tiles
{
	public class MiceFragmentBlock : ModItem
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

			item.createTile = mod.TileType("MiceFragmentBlock");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod clickerClass = ModLoader.GetMod("ClickerClass");

			recipe.AddIngredient(ItemID.StoneBlock, 5);
			recipe.AddIngredient(clickerClass.ItemType("MiceFragment"));

			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 5);
			recipe.AddRecipe();
		}
	}
}
