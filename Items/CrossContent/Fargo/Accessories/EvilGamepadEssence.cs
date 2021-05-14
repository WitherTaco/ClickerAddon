using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace ClickerAddon.Items.CrossContent.Fargo.Accessories
{
	public class EvilGamepadEssence : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("FargowiltasSouls");
		}

		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			DisplayName.SetDefault("Gamepad Essence");
			Tooltip.SetDefault("18% increased clicker damage"
				+ "\n5% increased clicker crit"
				+ "\n20% increased clicker radius");
		}

		public override void SetDefaults() 
		{
			item.width = 42;
			item.height = 42;
			item.value = 100000;
			item.rare = ItemRarityID.Red;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) 
		{
			ClickerCompat.SetDamageAdd(player, 0.18f);
			ClickerCompat.SetClickerCritAdd(player, 5);
			ClickerCompat.SetClickerRadiusAdd(player, 0.2f);
		}
		
		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(clickerClass.ItemType("ClickerEmblem"));
			recipe.AddIngredient(clickerClass.ItemType("WoodenClicker"));
			recipe.AddRecipeGroup("ClickerAddon:AnyGoldClicker");
			recipe.AddIngredient(clickerClass.ItemType("HoneyGlazedClicker"));
			recipe.AddIngredient(clickerClass.ItemType("HemoClicker"));
			recipe.AddIngredient(clickerClass.ItemType("UmbralClicker"));
			recipe.AddIngredient(ItemID.HallowedBar, 5);
			
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
