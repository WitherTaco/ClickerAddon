using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using ClickerAddon.Other;

namespace ClickerAddon.Items.CrossContent.Fargo.Accessories
{
	public class OverclockEnchantment : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("FargowiltasSouls");
		}

		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			Tooltip.SetDefault("Every 100 clicks briefly grants you 'Overclock', making every click trigger its effect."
							+ "\nWhile in combat, automatically clicks your current clicker every half-second");
		}

		public override void SetDefaults() 
		{
			item.width = 42;
			item.height = 42;
			item.value = 100000;
			item.rare = ItemRarityID.Pink;
			item.accessory = true;

			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) 
		{
			player.GetModPlayer<ClickerSoulPlayer>().OverclockEnch(false);
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

			recipe.AddIngredient(clickerClass.ItemType("RegalClickingGlove"));

			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
