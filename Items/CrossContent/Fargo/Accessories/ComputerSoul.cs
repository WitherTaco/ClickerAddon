using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

using ClickerAddon.Other;

namespace ClickerAddon.Items.CrossContent.Fargo.Accessories
{
	public class ComputerSoul : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("FargowiltasSouls");
		}

		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			ClickerCompat.SetDisplayTotalClicks(item);
			//ClickerCompat.SetDisplayTotalClicks(this);
			Tooltip.SetDefault("30% increased clicker damage"
				+ "\n15% increased clicker crit"
				+ "\n75% increased clicker radius"
				+ "\n25% reduces the amount of clicks required for a click effect"
				/*+ "\nPressing the 'Clicker Accessory' key will toggle auto click on all Clickers"
				+ "\nWhile auto click is enabled, click rates are decreased"
				
				+ "\nYour clicks produce a burst of mechanical light, while accessory is visible"
				+ "\nWhile equipped, cookies will periodically spawn within your clicker radius"
				+ "\nGain up to 15% clicker damage based on your amount of clicks within a second"
				+ "\nEvery 10 clicks sticks damaging slime on to your screen"
				+ "\nEvery 15 clicks releases a burst of damaging chocolate."
				+ "\nWhile in combat, automatically clicks your current clicker every half-second"
				
				+ "\nAdd a every clicker class armor effects"*/
				+ "\nEffects of Gamer Crate, Chocolate Milk n' Cookies"
				+ "\nEffects of Motherboard, Overclock, Precursor and Mice Enchantment"
				);
		}

		public override void SetDefaults() 
		{
			item.width = 64;
			item.height = 64;
			item.value = 250000;
			item.rare = ItemRarityID.Red;
			item.accessory = true;

			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) 
		{
			//Stats
			ClickerCompat.SetDamageAdd(player, 0.3f);
			ClickerCompat.SetClickerCritAdd(player, 15);
			ClickerCompat.SetClickerRadiusAdd(player, WitherTacoLib.Math.Radius(0.75f));
			ClickerCompat.SetClickerBonusPercentAdd(player, -0.25f);

			player.GetModPlayer<ClickerSoulPlayer>().AllClickerAcc(hideVisual);
			player.GetModPlayer<ClickerSoulPlayer>().ForceOfProgram();
		}
		
		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			Mod fargo = ModLoader.GetMod("Fargowiltas");
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(null, "EvilGamepadEssence");
			recipe.AddIngredient(null, "ForceOfProgramm");
			recipe.AddIngredient(clickerClass.ItemType("GamerCrate"));
			recipe.AddIngredient(clickerClass.ItemType("ChocolateMilkCookies"));
			
			recipe.AddIngredient(clickerClass.ItemType("CaptainsClicker"));
			recipe.AddIngredient(clickerClass.ItemType("SpectreClicker"));
			recipe.AddIngredient(clickerClass.ItemType("WitchClicker"));
			//recipe.AddIngredient(clickerClass.ItemType("LordsClicker"));
			recipe.AddIngredient(clickerClass.ItemType("TheClicker"));
			
			recipe.AddTile(fargo.TileType("CrucibleCosmosSheet"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
