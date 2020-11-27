using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace ClickerAddon.Items.Accessories
{
	public class ForceOfProgramm : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return ClickerCompat.ClickerClass != null;
		}
		
		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			Tooltip.SetDefault("Right clicking a position within your clicker radius will teleport you to it."
			+ "\nClicking causes an additional delayed fiery click at 25% the damage."
			+ "\nEvery 100 clicks briefly grants you 'Overclock', making every click trigger its effect."
			+ "\nRight click to place a radius extending sensor."
			+"\n'Coming Soon'");
		}

		public override void SetDefaults() 
		{
			item.width = 30;
			item.height = 34;
			item.value = 100000;
			item.rare = 10;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) 
		{
			ClickerCompat.SetArmorSet(player, "Motherboard");
			ClickerCompat.SetArmorSet(player, "Overclock");
			ClickerCompat.SetArmorSet(player, "Precursor");
			ClickerCompat.SetArmorSet(player, "Mice");
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(null, "MotherboardEnchantment");
			recipe.AddIngredient(null, "OverclockEnchantment");
			recipe.AddIngredient(null, "PrecursorEnchantment");
			recipe.AddIngredient(null, "MiceEnchantment");
			
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
