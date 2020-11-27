using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ClickerAddon.Items.Accessories
{
	public class MiceEnchantment : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return ClickerCompat.ClickerClass != null;
		}
		
		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			Tooltip.SetDefault("Right clicking a position within your clicker radius will teleport you to it."
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
			/*player.GetModPlayer<ClickerPlayer>().clickerMiceSet = true;
			player.GetModPlayer<ClickerPlayer>().clickerMiceSetAllowed = false;*/
			ClickerCompat.SetArmorSet(player, "Mice");
		}
		
		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(clickerClass.ItemType("MiceMask"));
			recipe.AddIngredient(clickerClass.ItemType("MiceSuit"));
			recipe.AddIngredient(clickerClass.ItemType("MiceBoots"));
			
			recipe.AddIngredient(clickerClass.ItemType("MiceClicker"));
			recipe.AddIngredient(clickerClass.ItemType("AstralClicker"));
			recipe.AddIngredient(clickerClass.ItemType("SpaceClicker"));
			recipe.AddIngredient(clickerClass.ItemType("HighTechClicker"));
			
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
