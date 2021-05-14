using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace ClickerAddon.Items.CrossContent.Redemption.Accessories
{
	public class MutagenClicker : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("Redemption");
		}

		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			DisplayName.SetDefault("Clicker`s Mutagen");
			Tooltip.SetDefault("15% increased clicker damage"
						+ "\n10% increased clicker crit");
		}

		public override void SetDefaults() 
		{
			item.width = 24;
			item.height = 24;
			item.value = Item.sellPrice(silver: 40, gold: 2);
			item.rare = ItemRarityID.Purple;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) 
		{
			ClickerCompat.SetDamageAdd(player, 0.15f);
			ClickerCompat.SetClickerCritAdd(player, 10);
		}
		
		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			Mod redemption = ModLoader.GetMod("Redemption");
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(redemption.ItemType("EmptyMutagen"));
			recipe.AddIngredient(ItemID.DestroyerEmblem);
			recipe.AddIngredient(clickerClass.ItemType("MiceFragment"), 10);

			recipe.AddTile(redemption.TileType("XenoTank1"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
