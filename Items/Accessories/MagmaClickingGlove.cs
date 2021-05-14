using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.Accessories
{
	[AutoloadEquip(EquipType.HandsOn)]
	public class MagmaClickingGlove : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}
		
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			Tooltip.SetDefault("While in combat, automatically clicks your current clicker every half-second"
							+ "\nClicker attacks inflict fire damage");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			item.value = 45000 * 5;
			item.rare = ItemRarityID.LightPurple;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ClickerCompat.SetAccessory(player, "RegalClickingGlove");
			player.GetModPlayer<ClickerAddonPlayer>().magmaChair = true;
		}

		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(clickerClass.ItemType("RegalClickingGlove"));
			recipe.AddIngredient(mod.ItemType("MagmaChair"));
			
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
