using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.Armor.Gel
{
	[AutoloadEquip(EquipType.Legs)]
	public class RainbowGelLeggins : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}
		
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			//DisplayName.SetDefault("Pinky`s Leggins");
			Tooltip.SetDefault("Increases click damage by 4%");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 29;
			item.rare = ItemRarityID.LightRed;
			item.defense = 7;
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB));
		}

		public override void UpdateEquip(Player player)
		{
			ClickerCompat.SetDamageAdd(player, 0.04f);
			//ClickerCompat.EnableClickEffect(player, "ClickerClass:TrueStrike");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("PinkyLeggins"), 1);
			recipe.AddIngredient(mod.ItemType("RainbowGel"), 20);
			recipe.SetResult(this);
			recipe.AddTile(TileID.WorkBenches);
			recipe.AddRecipe();
		}
	}
}