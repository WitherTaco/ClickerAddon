using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace ClickerAddon.Items.Accessories
{
	public class EvilGamepadEssence : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return ClickerCompat.ClickerClass != null;
		}
		
		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			Tooltip.SetDefault("18% increased clicker damage"
				+ "\n5% increased clicker crit");
		}

		public override void SetDefaults() 
		{
			item.width = 42;
			item.height = 42;
			item.value = 100000;
			item.rare = 10;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) 
		{
			/*player.GetModPlayer<ClickerPlayer>().clickerDamage += 0.18f;
			player.GetModPlayer<ClickerPlayer>().clickerCrit += 5;*/
			ClickerCompat.SetDamageAdd(player, 0.18f);
			ClickerCompat.SetClickerCritAdd(player, 5);
		}
		
		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(clickerClass.ItemType("ClickerEmblem"));
			recipe.AddIngredient(clickerClass.ItemType("WoodenClicker"));
			recipe.AddIngredient(clickerClass.ItemType("GoldClicker"));
			recipe.AddIngredient(clickerClass.ItemType("HoneyGlazedClicker"));
			recipe.AddIngredient(clickerClass.ItemType("HemoClicker"));
			recipe.AddIngredient(clickerClass.ItemType("UmbralClicker"));
			
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(clickerClass.ItemType("ClickerEmblem"));
			recipe.AddIngredient(clickerClass.ItemType("WoodenClicker"));
			recipe.AddIngredient(clickerClass.ItemType("PlatinumClicker"));
			recipe.AddIngredient(clickerClass.ItemType("HoneyGlazedClicker"));
			recipe.AddIngredient(clickerClass.ItemType("HemoClicker"));
			recipe.AddIngredient(clickerClass.ItemType("UmbralClicker"));
			
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
