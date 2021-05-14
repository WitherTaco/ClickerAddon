using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.Armor.Helmets
{
	[AutoloadEquip(EquipType.Head)]
	public class ChlorophyteCap : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}
		
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			DisplayName.SetDefault("Chlorophyte Capsuit");
			Tooltip.SetDefault("Increases click damage by 15%"
							+ "\nIncreases your base click radius by 35%");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 60000;
			item.rare = 7;
			item.defense = 11;
		}

		public override void UpdateEquip(Player player)
		{
			/*player.GetModPlayer<ClickerPlayer>().clickerDamage += 0.15f;
			player.GetModPlayer<ClickerPlayer>().clickerRadius += 0.7f;*/
			ClickerCompat.SetDamageAdd(player, 0.15f);
			ClickerCompat.SetClickerRadiusAdd(player, 0.7f);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 1004 && legs.type == 1005;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Summons a powerful leaf crystal to shoot at nearby enemies.";
			player.AddBuff(60, 2);
			//ClickerCompat.EnableClickEffect(player, "ClickerClass:ToxicRelease");
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}