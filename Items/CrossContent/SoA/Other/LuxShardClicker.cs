using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.CrossContent.SoA.Other
{
	public class LuxShardClicker : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("SacredTools");
		}
		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			DisplayName.SetDefault("Lux Enhancement Shard");
			Tooltip.SetDefault("Don`t Effect");
		}

		public override void SetDefaults() 
		{
			item.width = 16;
			item.height = 22;
			item.value = Item.sellPrice(gold: 10);
			item.rare = ItemRarityID.Purple;
			item.maxStack = 1;
		}
		public override Color? GetAlpha(Color lightColor) => new Color?(Color.White);

		public override void AddRecipes()
		{
			Mod SoA = ModLoader.GetMod("SacredTools");
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(mod.ItemType("LuxDustClicker"), 5);

			recipe.SetResult(this);
			recipe.AddTile(SoA.TileType("LunarAltar"));
			recipe.AddRecipe();
		}
	}
}
