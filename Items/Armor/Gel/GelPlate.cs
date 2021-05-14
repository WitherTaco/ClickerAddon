using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.Armor.Gel
{
	[AutoloadEquip(EquipType.Body)]
	public class GelPlate : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slimy Plate");
			ClickerCompat.RegisterClickerItem(this);
			//DisplayName.SetDefault("Adamantite Capsuit");
			Tooltip.SetDefault("Increases click damage by 2%"
							+ "\nIncreases click critical strike chance by 1%");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 25;
			item.rare = 0;
			item.defense = 2;
		}

		public override void UpdateEquip(Player player)
		{
			ClickerCompat.SetDamageAdd(player, 0.02f);
			ClickerCompat.SetClickerCritAdd(player, 1);
			//ClickerCompat.EnableClickEffect(player, "ClickerClass:TrueStrike");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gel, 25);
			recipe.SetResult(this);
			recipe.AddTile(TileID.WorkBenches);
			recipe.AddRecipe();
		}
	}
}