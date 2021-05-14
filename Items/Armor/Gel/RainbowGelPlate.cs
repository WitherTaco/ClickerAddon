using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.Armor.Gel
{
	[AutoloadEquip(EquipType.Body)]
	public class RainbowGelPlate : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}
		
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			//DisplayName.SetDefault("Pinky`s Plate");
			Tooltip.SetDefault("Increases click damage by 4%"
							+ "\nIncreases click critical strike chance by 2%");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 25;
			item.rare = ItemRarityID.LightRed;
			item.defense = 9;
		}

		public override void UpdateEquip(Player player)
		{
			ClickerCompat.SetDamageAdd(player, 0.04f);
			ClickerCompat.SetClickerCritAdd(player, 2);
			//ClickerCompat.EnableClickEffect(player, "ClickerClass:TrueStrike");
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB));
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("PinkyPlate"), 1);
			recipe.AddIngredient(mod.ItemType("RainbowGel"), 25);
			recipe.SetResult(this);
			recipe.AddTile(TileID.WorkBenches);
			recipe.AddRecipe();
		}
	}
}