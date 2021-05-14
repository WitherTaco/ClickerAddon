using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace ClickerAddon.Items.CrossContent.ElementUnslech.Accessories
{
	public class ClickerSeal : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("Bluemagic");
		}

		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			//DisplayName.SetDefault("Gamepad Essence");
			Tooltip.SetDefault("30% increased clicker damage");
		}

		public override void SetDefaults() 
		{
			item.width = 24;
			item.height = 24;
			item.value = Item.sellPrice(gold: 25);
			item.rare = ItemRarityID.Purple;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) 
		{
			ClickerCompat.SetDamageAdd(player, 0.3f);
		}
		
		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			Mod bluemagic = ModLoader.GetMod("Bluemagic");
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(clickerClass.ItemType("ClickerEmblem"));
			recipe.AddIngredient(bluemagic.ItemType("InfinityCrystal"));

			recipe.AddTile(bluemagic.TileType("PuriumAnvil"));
			recipe.SetResult(this);
			recipe.AddRecipe();


			recipe = new ModRecipe(mod);

			recipe.AddIngredient(ItemID.AvengerEmblem);
			recipe.AddIngredient(bluemagic.ItemType("InfinityCrystal"));

			recipe.AddTile(bluemagic.TileType("PuriumAnvil"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
