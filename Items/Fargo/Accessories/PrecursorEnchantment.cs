using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace ClickerAddon.Items.Fargo.Accessories
{
	public class PrecursorEnchantment : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return ((ClickerCompat.ClickerClass != null) && (Terraria.ModLoader.ModLoader.GetMod("Fargowiltas") != null));
		}
		
		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			Tooltip.SetDefault("Clicking causes an additional delayed fiery click at 25% the damage.");
		}

		public override void SetDefaults() 
		{
			item.width = 42;
			item.height = 42;
			item.value = 100000;
			item.rare = 8;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) 
		{
			player.GetModPlayer<ClickerAddonPlayer>().clonePrecursor = true;
		}
		
		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(clickerClass.ItemType("PrecursorHelmet"));
			recipe.AddIngredient(clickerClass.ItemType("PrecursorBreastplate"));
			recipe.AddIngredient(clickerClass.ItemType("PrecursorGreaves"));
			
			recipe.AddIngredient(clickerClass.ItemType("LihzahrdClicker"));
			recipe.AddIngredient(clickerClass.ItemType("CandleClicker"));
			recipe.AddIngredient(clickerClass.ItemType("ShroomiteClicker"));
			recipe.AddIngredient(clickerClass.ItemType("EclipticClicker"));
			
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
