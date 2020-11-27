using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ClickerAddon.Items.Accessories
{
	//Sample code for a clicker related item
	public class BigRedButton : ModItem
	{
		//Optional, if you want this item to exist only when Clicker Class is enabled
		public override bool Autoload(ref string name)
		{
			return ClickerCompat.ClickerClass != null;
		}

		public override void SetStaticDefaults()
		{
			//You NEED to call this in SetStaticDefaults to make it count as a clicker related item
			ClickerCompat.RegisterClickerItem(this);

			DisplayName.SetDefault("Big Red Button");
			Tooltip.SetDefault("Reduces the amount of clicks required for a click effect by 1" 
				+ "\nGain up to 15% clicker damage based on your amount of clicks within a second"
				+ "\nMakes the radius pulsate up to 50% of the default radius");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 20;
			item.value = 100000;
			item.rare = ItemRarityID.LightRed;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ClickerCompat.SetClickerBonusAdd(player, 1);
			ClickerCompat.SetAccessory(player, "GlassOfMilk");

			float fluct = 1f + (float)Math.Sin(2 * Math.PI * (Main.GameUpdateCount % 60) / 60f);
			ClickerCompat.SetClickerRadiusAdd(player, fluct / 2);
		}
		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(clickerClass.ItemType("Milk"));
			recipe.AddIngredient(clickerClass.ItemType("Soda"));
			recipe.AddIngredient(529, 1);
			
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
