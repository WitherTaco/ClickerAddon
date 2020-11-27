using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace ClickerAddon.Items.Accessories
{
	public class OverclockEnchantment : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return ClickerCompat.ClickerClass != null;
		}
		
		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			Tooltip.SetDefault("Every 100 clicks briefly grants you 'Overclock', making every click trigger its effect."
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
			ClickerCompat.SetArmorSet(player, "Overclock");
		}
		
		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(clickerClass.ItemType("OverclockHelmet"));
			recipe.AddIngredient(clickerClass.ItemType("OverclockSuit"));
			recipe.AddIngredient(clickerClass.ItemType("OverclockBoots"));
			
			recipe.AddIngredient(clickerClass.ItemType("ArthursClicker"));
			recipe.AddIngredient(clickerClass.ItemType("ChlorophyteClicker"));
			recipe.AddIngredient(clickerClass.ItemType("FrozenClicker"));
			recipe.AddIngredient(clickerClass.ItemType("BoneClicker"));
			
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
