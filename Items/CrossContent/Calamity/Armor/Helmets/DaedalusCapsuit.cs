using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ClickerAddon.Other;

namespace ClickerAddon.Items.CrossContent.Calamity.Armor.Helmets
{
	[AutoloadEquip(EquipType.Head)]
	public class DaedalusCapsuit : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("CalamityMod");
		}

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			//DisplayName.SetDefault("Capsuit of Fallen");
			Tooltip.SetDefault("13% increased clicker damage"
							+ "\n7% increased clicker crit"
							+ "\n25% increased clicker radius");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = Item.buyPrice(gold: 25);
			item.rare = ItemRarityID.Pink;
			item.defense = 15;
		}

		public override void UpdateEquip(Player player)
		{
			ClickerCompat.SetDamageAdd(player, 0.08f);
			ClickerCompat.SetClickerCritAdd(player, 7);
			ClickerCompat.SetClickerRadiusAdd(player, WitherTacoLib.Math.Radius(0.25f));
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			Mod calamity = ModLoader.GetMod("CalamityMod");
			return body.type == calamity.ItemType("DaedalusBreastplate") && legs.type == calamity.ItemType("DaedalusLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "10% increased clicker damage\nWhen clicking have chance to shoot 4 crystal shards";
			Mod calamity = ModLoader.GetMod("CalamityMod");

			ClickerCompat.SetDamageAdd(player, 0.1f);
			player.GetModPlayer<ClickerAddonPlayer>().daedalusCapsuit = true;
			/*CalamityCompat.CalamityArmorSetBonus(player, "daedalus_summon");
			if (player.whoAmI == Main.myPlayer)
			{
				if (player.FindBuffIndex(CalamityCompat.Calamity.BuffType("DaedalusCrystal")) == -1)
				{
					player.AddBuff(CalamityCompat.Calamity.BuffType("DaedalusCrystal"), 3600, true);
				}
				if (player.ownedProjectileCounts[CalamityCompat.Calamity.ProjectileType("DaedalusCrystal")] < 1)
				{
					int CryonicCrystal = (int)(95 * player.minionDamage);
					Projectile.NewProjectile(player.Center.X, player.Center.Y, 0.0f, -1f, CalamityCompat.Calamity.ProjectileType("DaedalusCrystal"), CryonicCrystal, 0.0f, Main.myPlayer, 50f, 0.0f);
				}
			}*/
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowSubtle = true;
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

			recipe.AddIngredient(calamity.ItemType("VerstaltiteBar"), 8);
			recipe.AddIngredient(ItemID.CrystalShard, 6);
			recipe.AddIngredient(calamity.ItemType("EssenceofEleum"), 1);
			
			recipe.SetResult(this);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddRecipe();
		}
	}
}