using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ClickerAddon.Items.Accessories
{
	public class ChocolateCookie : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);

			//DisplayName.SetDefault("Big Red Button");
			Tooltip.SetDefault("While equipped, cookies will periodically spawn within your clicker radius"
							+ "\nClick the cookie to gain bonus clicker damage, radius, and life regeneration"
							+ "\nEvery 15 clicks releases a burst of damaging chocolate");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 20;
			item.value = (4000 + 10000) * 5;
			item.rare = ItemRarityID.LightRed;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ClickerCompat.SetAccessory(player, "Cookie2");
			ClickerCompat.EnableClickEffect(player, "ClickerClass:ChocolateChip");
		}
		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(clickerClass.ItemType("Cookie"));
			recipe.AddIngredient(clickerClass.ItemType("ChocolateChip"));
			
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			
			recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(this);
			recipe.AddIngredient(clickerClass.ItemType("Milk"));
			
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(clickerClass.ItemType("ChocolateMilkCookies"));
			recipe.AddRecipe();
			
			
			recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(clickerClass.ItemType("Cookie"));
			recipe.AddIngredient(clickerClass.ItemType("ChocolateChip"));
			recipe.AddIngredient(clickerClass.ItemType("Milk"));
			
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(clickerClass.ItemType("ChocolateMilkCookies"));
			recipe.AddRecipe();
		}
	}
}
