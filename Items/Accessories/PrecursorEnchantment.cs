using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace ClickerAddon.Items.Accessories
{
	public class PrecursorEnchantment : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return ClickerCompat.ClickerClass != null;
		}
		
		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			Tooltip.SetDefault("Clicking causes an additional delayed fiery click at 25% the damage."
								+"\n'Coming Soon'");
		}

		public override void SetDefaults() 
		{
			item.width = 35;
			item.height = 35;
			item.value = 100000;
			item.rare = 10;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) 
		{
			ClickerCompat.SetArmorSet(player, "Precursor");
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
