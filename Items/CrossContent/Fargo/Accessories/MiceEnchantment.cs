using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ClickerAddon.Other;

namespace ClickerAddon.Items.CrossContent.Fargo.Accessories
{
	public class MiceEnchantment : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("FargowiltasSouls");
		}

		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			Tooltip.SetDefault("Right clicking a position within your clicker radius will teleport you to it.");
		}

		public override void SetDefaults() 
		{
			item.width = 35;
			item.height = 35;
			item.value = 100000;
			item.rare = ItemRarityID.Red;
			item.accessory = true;

			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) 
		{
			player.GetModPlayer<ClickerSoulPlayer>().MiceEnch(false);
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
