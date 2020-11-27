using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ClickerAddon.Items.Accessories
{
	public class MotherboardEnchantment : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return ClickerCompat.ClickerClass != null;
		}
		
		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			Tooltip.SetDefault("Right click to place a radius extending sensor."
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
			ClickerCompat.SetArmorSet(player, "Motherboard");
		}
		
		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(clickerClass.ItemType("MotherboardHelmet"));
			recipe.AddIngredient(clickerClass.ItemType("MotherboardSuit"));
			recipe.AddIngredient(clickerClass.ItemType("MotherboardBoots"));
			
			recipe.AddIngredient(clickerClass.ItemType("SilverClicker"));
			recipe.AddIngredient(clickerClass.ItemType("TungstenClicker"));
			recipe.AddIngredient(clickerClass.ItemType("IronClicker"));
			recipe.AddIngredient(clickerClass.ItemType("LeadClicker"));
			
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
