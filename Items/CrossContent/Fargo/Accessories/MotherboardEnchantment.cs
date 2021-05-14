using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ClickerAddon.Other;

namespace ClickerAddon.Items.CrossContent.Fargo.Accessories
{
	public class MotherboardEnchantment : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("FargowiltasSouls");
		}

		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			Tooltip.SetDefault("Right click to place a radius extending sensor."
				+ "\nEvery 10 clicks sticks damaging slime on to your screen");
		}

		public override void SetDefaults() 
		{
			item.width = 35;
			item.height = 35;
			item.value = 100000;
			item.rare = ItemRarityID.Orange;
			item.accessory = true;

			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) 
		{
			player.GetModPlayer<ClickerSoulPlayer>().MotherboardEnch(false);
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

			recipe.AddIngredient(clickerClass.ItemType("StickyKeychain"));

			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
