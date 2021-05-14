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
			return WitherTacoLib.IfMod();
		}

		public override void SetStaticDefaults()
		{
			//You NEED to call this in SetStaticDefaults to make it count as a clicker related item
			ClickerCompat.RegisterClickerItem(this);

			DisplayName.SetDefault("Big Red Button");
			Tooltip.SetDefault("Makes the radius pulsate up to 50% of the default radius");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 20;
			item.value = 10000 * 5;
			item.rare = ItemRarityID.Blue;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<ClickerAddonPlayer>().bigRedButton = true;
		}
		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(ItemID.RedPressurePlate, 1);
			recipe.AddRecipeGroup("ClickerAddon:AnyGoldBar", 8);

			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
