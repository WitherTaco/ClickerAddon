using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ClickerAddon.Items.Accessories
{
	public class GamerBoots : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}
		
		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			Tooltip.SetDefault("The wearer can run super fast"
				+ "\nGain up to move speed based on your amount of clicks within a second.");
		}

		public override void SetDefaults() 
		{
			item.width = 32;
			item.height = 32;
			item.value = 50000;
			item.rare = ItemRarityID.Orange;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) 
		{
			player.accRunSpeed = 6.75f;
			player.GetModPlayer<ClickerAddonPlayer>().bandOfClicking = true;
			//player.moveSpeed += (float)(ClickerCompat.GetClickerPerSecond(player) * 0.2f);
		}

		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(ItemID.HermesBoots);
			recipe.AddIngredient(mod.ItemType("BandOfClicking"));

			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();


			recipe = new ModRecipe(mod);

			recipe.AddIngredient(ItemID.FlurryBoots);
			recipe.AddIngredient(mod.ItemType("BandOfClicking"));

			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();


			recipe = new ModRecipe(mod);

			recipe.AddIngredient(ItemID.SailfishBoots);
			recipe.AddIngredient(mod.ItemType("BandOfClicking"));

			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
