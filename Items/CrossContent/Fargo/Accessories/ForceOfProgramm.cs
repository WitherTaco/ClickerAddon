using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

using ClickerAddon.Other;

namespace ClickerAddon.Items.CrossContent.Fargo.Accessories
{
	public class ForceOfProgramm : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("FargowiltasSouls");
		}

		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			Tooltip.SetDefault("Right clicking a position within your clicker radius will teleport you to it."
			+ "\nClicking causes an additional delayed fiery click at 25% the damage."
			+ "\nEvery 100 clicks briefly grants you 'Overclock', making every click trigger its effect."
			+ "\nRight click to place a radius extending sensor."

			+ "\nWhile in combat, automatically clicks your current clicker every half-second"
			+ "\nEvery 10 clicks sticks damaging slime on to your screen");
		}

		public override void SetDefaults() 
		{
			item.width = 30;
			item.height = 34;
			item.value = 100000;
			item.rare = ItemRarityID.Purple;
			item.accessory = true;

			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) 
		{
			player.GetModPlayer<ClickerSoulPlayer>().ForceOfProgram();
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod fargo = ModLoader.GetMod("Fargowiltas");
			
			recipe.AddIngredient(null, "MotherboardEnchantment");
			recipe.AddIngredient(null, "OverclockEnchantment");
			recipe.AddIngredient(null, "PrecursorEnchantment");
			recipe.AddIngredient(null, "MiceEnchantment");
			
			recipe.AddTile(fargo.TileType("CrucibleCosmosSheet"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
