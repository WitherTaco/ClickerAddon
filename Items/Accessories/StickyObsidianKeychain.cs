using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.Accessories
{
	public class StickyObsidianKeychain : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}
		
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			Tooltip.SetDefault("Every 10 clicks sticks damaging slime on to your screen"
							+ "\nGrants immunity to fire blocks"
							+ "\nIncreases armor penetration by 5");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			item.value = 20000 * 5;
			item.rare = ItemRarityID.Green;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ClickerCompat.EnableClickEffect(player, "ClickerClass:StickyKeychain");
			player.fireWalk = true;
			player.armorPenetration += 5;
		}
		
		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(clickerClass.ItemType("StickyKeychain"));
			recipe.AddIngredient(ItemID.ObsidianSkull);
			recipe.AddIngredient(ItemID.SharkToothNecklace);
			
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
