using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace ClickerAddon.Items.CrossContent.SoA.Accessories
{
	public class MiceSigil : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("SacredTools");
		}

		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			//DisplayName.SetDefault("Gamepad Essence");
			Tooltip.SetDefault("25% increased clicker damage"
				+ "\n10% increased clicker crit");
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
			ClickerCompat.SetDamageAdd(player, 0.25f);
			ClickerCompat.SetClickerCritAdd(player, 10);
		}
		
		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			Mod SoA = ModLoader.GetMod("SacredTools");
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(clickerClass.ItemType("ClickerEmblem"));
			recipe.AddIngredient(SoA.ItemType("MoonstoneBar"), 10);
			recipe.AddIngredient(clickerClass.ItemType("MiceFragment"), 20);
			recipe.AddIngredient(SoA.ItemType("SoulOfLuminite"));
			recipe.AddIngredient(SoA.ItemType("LunaticEssence"), 15);

			recipe.AddTile(SoA.TileType("LunarAltar"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
