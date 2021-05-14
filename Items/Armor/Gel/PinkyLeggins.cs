using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.Armor.Gel
{
	[AutoloadEquip(EquipType.Legs)]
	public class PinkyLeggins : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}
		
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			DisplayName.SetDefault("Pinky`s Leggins");
			Tooltip.SetDefault("Increases click damage by 3%");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 29;
			item.rare = ItemRarityID.White;
			item.defense = 2;
		}

		public override void UpdateEquip(Player player)
		{
			ClickerCompat.SetDamageAdd(player, 0.03f);
			//ClickerCompat.EnableClickEffect(player, "ClickerClass:TrueStrike");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GelLeggins"), 1);
			recipe.AddIngredient(ItemID.PinkGel, 3);
			recipe.SetResult(this);
			recipe.AddTile(TileID.WorkBenches);
			recipe.AddRecipe();
		}
	}
}