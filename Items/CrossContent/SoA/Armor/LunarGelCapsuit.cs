using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ClickerAddon.Other;

namespace ClickerAddon.Items.CrossContent.SoA.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class LunarGelCapsuit : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("SacredTools");
		}
		
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			//DisplayName.SetDefault("Pinky`s Capsuit");
			Tooltip.SetDefault("Increases click damage by 7%"
							+ "\nIncreases click critical strike chance by 2%");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 24;
			item.rare = ItemRarityID.Red;
			item.defense = 19;
		}
		public override Color? GetAlpha(Color lightColor)
		{
			ClickerAddonPlayer player = Main.LocalPlayer.GetModPlayer<ClickerAddonPlayer>();
			return new Color?(player.lunarColor);
		}

		public override void UpdateEquip(Player player)
		{
			ClickerCompat.SetDamageAdd(player, 0.07f);
			ClickerCompat.SetClickerRadiusAdd(player, 2);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("LunarGelPlate") && legs.type == mod.ItemType("LunarGelLeggins");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases click damage and critical strike chance by 10%";
			ClickerCompat.SetDamageAdd(player, 0.1f);
			ClickerCompat.SetClickerCritAdd(player, 10);
			player.GetModPlayer<GraphicPlayer>().lunarGelArmor = true;
		}

		public override void AddRecipes()
		{
			Mod SoA = ModLoader.GetMod("SacredTools");
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(mod.ItemType("RainbowGelCapsuit"));
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