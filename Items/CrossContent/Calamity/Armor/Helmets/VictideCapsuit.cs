using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ClickerAddon.Other;

namespace ClickerAddon.Items.CrossContent.Calamity.Armor.Helmets
{
	[AutoloadEquip(EquipType.Head)]
	public class VictideCapsuit : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("CalamityMod");
		}

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			//DisplayName.SetDefault("Capsuit of Fallen");
			Tooltip.SetDefault("5% increased clicker damage"
							+ "\n10% increased clicker radius");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = Item.buyPrice(gold: 1, silver: 50);
			item.rare = ItemRarityID.Green;
			item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			/*player.GetModPlayer<ClickerPlayer>().clickerDamage += 0.06f;
			player.GetModPlayer<ClickerPlayer>().clickerRadius += 0.4f;*/
			ClickerCompat.SetDamageAdd(player, 0.05f);
			//ClickerCompat.SetClickerCritAdd(player, 6);
			ClickerCompat.SetClickerRadiusAdd(player, WitherTacoLib.Math.Radius(0.1f));
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			Mod calamity = ModLoader.GetMod("CalamityMod");
			return body.type == calamity.ItemType("VictideBreastplate") && legs.type == calamity.ItemType("VictideLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increased life regen and clicker damage while submerged in liquid\nWhen using any weapon you have a 10% chance to throw a returning seashell projectile\nThis seashell does true damage and does not benefit from any damage class\nProvides increased underwater mobility and slightly reduces breath loss in the abyss";
			Mod calamity = ModLoader.GetMod("CalamityMod");

			player.ignoreWater = true;
			CalamityCompat.CalamityArmorSetBonus(player, "victide");
			if (!Collision.DrownCollision((Vector2)player.position, player.width, player.height, player.gravDir))
				return;
			ClickerCompat.SetDamageAdd(player, 0.1f);
			player.lifeRegen += 3; 
		}

		/*public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}*/
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawAltHair = true; 
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod calamity = ModLoader.GetMod("CalamityMod");

			recipe.AddIngredient(calamity.ItemType("VictideBar"), 3);
			
			recipe.SetResult(this);
			recipe.AddTile(TileID.Anvils);
			recipe.AddRecipe();
		}
	}
}