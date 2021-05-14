using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ClickerAddon.Other;

namespace ClickerAddon.Items.CrossContent.Calamity.Armor.Helmets
{
	[AutoloadEquip(EquipType.Head)]
	public class StatigelCapsuit : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("CalamityMod");
		}

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			//DisplayName.SetDefault("Capsuit of Fallen");
			Tooltip.SetDefault("10% increased clicker damage"
				+ "\n7% increased clicker crit"
				+ "\n25% increased clicker radius");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = Item.buyPrice(gold: 5);
			item.rare = ItemRarityID.Pink;
			item.defense = 5;
		}

		public override void UpdateEquip(Player player)
		{
			ClickerCompat.SetDamageAdd(player, 0.1f);
			ClickerCompat.SetClickerCritAdd(player, 7);
			ClickerCompat.SetClickerRadiusAdd(player, WitherTacoLib.Math.Radius(0.25f));
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			Mod calamity = ModLoader.GetMod("CalamityMod");
			return body.type == calamity.ItemType("StatigelArmor") && legs.type == calamity.ItemType("StatigelGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "When you take over 100 damage in one hit you become immune to damage for an extended period of time\nGrants an extra jump and increased jump height\n30% increased jump speed";
			Mod calamity = ModLoader.GetMod("CalamityMod");

			CalamityCompat.CalamityArmorSetBonus(player, "statigel");
			player.doubleJumpSail = true;
			player.jumpSpeedBoost += 1.5f;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawAltHair = drawHair = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod calamity = ModLoader.GetMod("CalamityMod");

			recipe.AddIngredient(calamity.ItemType("PurifiedGel"), 5);
			recipe.AddIngredient(ItemID.HellstoneBar, 9);
			
			recipe.SetResult(this);
			recipe.AddTile(calamity.TileType("StaticRefiner"));
			recipe.AddRecipe();
		}
	}
}