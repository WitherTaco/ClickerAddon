using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ClickerAddon.Other;

namespace ClickerAddon.Items.CrossContent.SoA.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class LunarGelPlate : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("SacredTools");
		}
		
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			//DisplayName.SetDefault("Pinky`s Plate");
			Tooltip.SetDefault("Increases click damage by 7%"
							+ "\nIncreases click critical strike chance by 3%"
							+ "\nIncreases your base click radius by 20%");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 25;
			item.rare = ItemRarityID.Red;
			item.defense = 9;
		}

		public override void UpdateEquip(Player player)
		{
			ClickerCompat.SetDamageAdd(player, 0.07f);
			ClickerCompat.SetClickerCritAdd(player, 3);
			ClickerCompat.SetClickerRadiusAdd(player, 0.4f);
			//ClickerCompat.EnableClickEffect(player, "ClickerClass:TrueStrike");
		}
		public override Color? GetAlpha(Color lightColor)
		{
			ClickerAddonPlayer player = Main.LocalPlayer.GetModPlayer<ClickerAddonPlayer>();
			return new Color?(player.lunarColor);
		}

		public override void AddRecipes()
		{
			Mod SoA = ModLoader.GetMod("SacredTools");
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(mod.ItemType("RainbowGelPlate"));
			recipe.AddIngredient(SoA.ItemType("JellySolar"), 5);
			recipe.AddIngredient(SoA.ItemType("JellyVortex"), 5);
			recipe.AddIngredient(SoA.ItemType("JellyNebula"), 5);
			recipe.AddIngredient(SoA.ItemType("JellyStardust"), 5);
			recipe.AddIngredient(SoA.ItemType("JellyQuasar"), 5);

			recipe.SetResult(this);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.AddRecipe();
		}
	}
}