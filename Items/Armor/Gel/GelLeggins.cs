using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.Armor.Gel
{
	[AutoloadEquip(EquipType.Legs)]
	public class GelLeggins : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slimy Leggins");
			ClickerCompat.RegisterClickerItem(this);
			//DisplayName.SetDefault("Adamantite Capsuit");
			Tooltip.SetDefault("Increases click damage by 2%");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 20;
			item.rare = 0;
			item.defense = 1;
		}

		public override void UpdateEquip(Player player)
		{
			ClickerCompat.SetDamageAdd(player, 0.02f);
			//ClickerCompat.EnableClickEffect(player, "ClickerClass:TrueStrike");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gel, 20);
			recipe.SetResult(this);
			recipe.AddTile(TileID.WorkBenches);
			recipe.AddRecipe();
		}
	}
}