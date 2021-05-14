using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using ClickerAddon.Other;

namespace ClickerAddon.Items.Armor.Gel
{
	[AutoloadEquip(EquipType.Head)]
	public class RainbowGelCapsuit : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}
		
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			//DisplayName.SetDefault("Pinky`s Capsuit");
			Tooltip.SetDefault("Increases click damage by 4%");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 24;
			item.rare = ItemRarityID.LightRed;
			item.defense = 6;
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB));
		}

		public override void UpdateEquip(Player player)
		{
			ClickerCompat.SetDamageAdd(player, 0.04f);
			//player.GetModPlayer<ClickerAddonPlayer>().rainbowEffect[1] = true;
			//ClickerCompat.EnableClickEffect(player, "ClickerClass:TrueStrike");
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("RainbowGelPlate") && legs.type == mod.ItemType("RainbowGelLeggins");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases your base click radius by 30% and crit by 2%";
			ClickerCompat.SetClickerRadiusAdd(player, WitherTacoLib.Math.Radius(0.3f));
			ClickerCompat.SetClickerCritAdd(player, 2);
			player.GetModPlayer<GraphicPlayer>().rainbowGelArmor = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("PinkyCapsuit"), 1);
			recipe.AddIngredient(mod.ItemType("RainbowGel"), 15);
			recipe.SetResult(this);
			recipe.AddTile(TileID.WorkBenches);
			recipe.AddRecipe();
		}
	}
}