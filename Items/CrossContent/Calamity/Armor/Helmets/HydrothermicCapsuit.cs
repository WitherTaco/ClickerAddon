using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ClickerAddon.Other;
using CalamityMod.CalPlayer;

namespace ClickerAddon.Items.CrossContent.Calamity.Armor.Helmets
{
	[AutoloadEquip(EquipType.Head)]
	public class HydrothermicCapsuit : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("CalamityMod");
		}

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			//DisplayName.SetDefault("Capsuit of Fallen");
			Tooltip.SetDefault("12% increased clicker damage"
							+ "\n10% increased clicker crit"
							+ "\n55% increased clicker radius"
							+ "\nClicker attacks inflict on fire"
							+ "\nTemporary immunity to lava and immunity to fire damage");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = Item.buyPrice(gold: 30);
			item.rare = ItemRarityID.Yellow;
			item.defense = 27;
		}

		public override void UpdateEquip(Player player)
		{
			ClickerCompat.SetDamageAdd(player, 0.12f);
			ClickerCompat.SetClickerCritAdd(player, 10);
			ClickerCompat.SetClickerRadiusAdd(player, WitherTacoLib.Math.Radius(0.55f));
			player.GetModPlayer<ClickerAddonPlayer>().magmaChair = true;
			player.lavaMax += 240;
			player.buffImmune[24] = true;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			Mod calamity = ModLoader.GetMod("CalamityMod");
			return body.type == calamity.ItemType("AtaxiaArmor") && legs.type == calamity.ItemType("AtaxiaSubligar");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "5% increased clicker damage\nInferno effect when below 50% life\nYou have a 20% chance to emit a blazing explosion when you are hit\nClicker attacks summon damaging and healing flare orbs on hit";
			Mod calamity = ModLoader.GetMod("CalamityMod");
			ClickerAddonPlayer modPlayer = player.GetModPlayer<ClickerAddonPlayer>();

			CalamityCompat.CalamityArmorSetBonus(player, "ataxia");
			ClickerCompat.SetDamageAdd(player, 0.05f);
			modPlayer.ataxiaCapsuit = true;
		}

		public override void ArmorSetShadows(Player player)
		{
			CalamityPlayer modPlayer = player.GetModPlayer<CalamityPlayer>();
			modPlayer.hydrothermalSmoke = true;
			player.armorEffectDrawOutlines = true;
		}
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawAltHair = true; 
		}
		public override bool DrawHead()
		{
			return false;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod calamity = ModLoader.GetMod("CalamityMod");

			recipe.AddIngredient(calamity.ItemType("CruptixBar"), 7);
			recipe.AddIngredient(ItemID.HellstoneBar, 4);
			recipe.AddIngredient(calamity.ItemType("CoreofChaos"), 1);
			
			recipe.SetResult(this);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddRecipe();
		}
	}
}