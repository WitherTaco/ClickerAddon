using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace ClickerAddon.Items.Accessories
{
	public class ComputerSoul : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return ClickerCompat.ClickerClass != null;
		}
		
		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			Tooltip.SetDefault("30% increased clicker damage"
				+ "\n15% increased clicker crit"
				+ "\n75% increased clicker radius"
				+ "\n25% reduces the amount of clicks required for a click effect"
				+ "\nPressing the 'Clicker Accessory' key will toggle auto click on all Clickers"
				+ "\nWhile auto click is enabled, click rates are decreased"
				
				+ "\nYour clicks produce a burst of mechanical light, while accessory is visible"
				+ "\nWhile equipped, cookies will periodically spawn within your clicker radius"
				+ "\nGain up to 15% clicker damage based on your amount of clicks within a second"
				+ "\nEvery 10 clicks sticks damaging slime on to your screen"
				+ "\nWhile in combat, automatically clicks your current clicker every half-second"
				
				+ "\nMice, Overclock, Precursor and Motherboard armors set effect");
		}

		public override void SetDefaults() 
		{
			item.width = 64;
			item.height = 64;
			item.value = 250000;
			item.rare = 10;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) 
		{
			//Stats
			ClickerCompat.SetDamageAdd(player, 0.3f);
			ClickerCompat.SetClickerCritAdd(player, 15);
			ClickerCompat.SetClickerRadiusAdd(player, 1.5f);
			ClickerCompat.SetClickerBonusPercentAdd(player, 0.25f);
			ClickerCompat.SetAccessory(player, "HandCream");
			
			//Acc Effect
			ClickerCompat.SetAccessory(player, "Cookie2");
			ClickerCompat.SetAccessory(player, "GlassOfMilk");
			ClickerCompat.SetAccessory(player, "StickyKeychain");
			ClickerCompat.SetAccessory(player, "ChocolateChip");
			ClickerCompat.SetAccessory(player, "RegalClickingGlove");
			if (ClickerAddonConfigClient.Instance.ShowEnchLED || !hideVisual)
			{
				ClickerCompat.SetAccessory(player, "EnchantedLED");
				ClickerCompat.SetAccessory(player, "EnchantedLED2");
			}
			ClickerCompat.SetAccessory(player, "GlassOfMilk");
			
			//Armor Set Effect
			ClickerCompat.SetArmorSet(player, "Motherboard");
			ClickerCompat.SetArmorSet(player, "Overclock");
			ClickerCompat.SetArmorSet(player, "Precursor");
			ClickerCompat.SetArmorSet(player, "Mice");
		}
		
		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(null, "EvilGamepadEssence");
			recipe.AddIngredient(null, "ForceOfProgramm");
			recipe.AddIngredient(clickerClass.ItemType("GamerCrate"));
			recipe.AddIngredient(clickerClass.ItemType("StickyKeychain"));
			recipe.AddIngredient(clickerClass.ItemType("ChocolateMilkCookies"));
			
			recipe.AddIngredient(clickerClass.ItemType("RegalClickingGlove"));
			/*recipe.AddIngredient(null, "Clicker");*/
			recipe.AddIngredient(clickerClass.ItemType("CaptainsClicker"));
			recipe.AddIngredient(clickerClass.ItemType("SpectreClicker"));
			recipe.AddIngredient(clickerClass.ItemType("WitchClicker"));
			recipe.AddIngredient(clickerClass.ItemType("LordsClicker"));
			recipe.AddIngredient(clickerClass.ItemType("TheClicker"));
			
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
