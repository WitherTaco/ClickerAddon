using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Redemption;
//using Redemption.Items.Armor.PostML;
//using Redemption.Items;
//using Redemption.Buffs;

namespace ClickerAddon.Items.CrossContent.Redemption.Armor.Helmets
{
	[AutoloadEquip(EquipType.Head)]
	public class XeniumCapsuit : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("Redemption");
		}
		
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			DisplayName.SetDefault("Xenium Capsuit");
			Tooltip.SetDefault("Increases click damage and crit by 25%"
							+ "\nIncreases your base click radius by 100%");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 400;
			item.rare = 11;
			item.defense = 14;
		}

		public override void UpdateEquip(Player player)
		{
			/*player.GetModPlayer<ClickerPlayer>().clickerDamage += 0.06f;
			player.GetModPlayer<ClickerPlayer>().clickerRadius += 0.4f;*/
			ClickerCompat.SetDamageAdd(player, 0.25f);
			ClickerCompat.SetClickerCritAdd(player, 25);
			ClickerCompat.SetClickerRadiusAdd(player, WitherTacoLib.Math.Radius(1f));
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			Mod redemption = ModLoader.GetMod("Redemption");
			return body.type == redemption.ItemType("XeniumBody") && legs.type == redemption.ItemType("XeniumLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Grants immunity to the Infection, Radioactive Fallout, and infected waters";
			Mod redemption = ModLoader.GetMod("Redemption");
			RedePlayer modPlayer = player.GetModPlayer<RedePlayer>();
			
			player.buffImmune[redemption.BuffType("XenomiteDebuff")] = true;
			player.buffImmune[redemption.BuffType("XenomiteDebuff2")] = true;
			player.buffImmune[redemption.BuffType("RadioactiveFalloutDebuff")] = true;
			player.buffImmune[redemption.BuffType("HeavyRadiationDebuff")] = true;
			modPlayer.labWaterImmune = true;
			
			//ClickerCompat.EnableClickEffect(player, "ClickerAddon:XenoEffect");
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
			player.armorEffectDrawOutlines = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod redemption = ModLoader.GetMod("Redemption");
			
			recipe.AddIngredient(redemption.ItemType("XeniumBar"), 12);
			recipe.AddIngredient(redemption.ItemType("ArtificalMuscle"), 2);
			
			recipe.SetResult(this);
			recipe.AddTile(redemption.TileType("XenoTank1"));
			recipe.AddRecipe();
		}
	}
}