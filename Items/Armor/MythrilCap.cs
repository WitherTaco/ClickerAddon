using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class MythrilCap : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return ClickerCompat.ClickerClass != null;
		}
		
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			DisplayName.SetDefault("Mythril Capsuit");
			Tooltip.SetDefault("Increases click damage by 6%"
							+ "\nIncreases your base click radius by 25%");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 400;
			item.rare = 4;
			item.defense = 9;
		}

		public override void UpdateEquip(Player player)
		{
			/*player.GetModPlayer<ClickerPlayer>().clickerDamage += 0.06f;
			player.GetModPlayer<ClickerPlayer>().clickerRadius += 0.5f;*/
			ClickerCompat.SetDamageAdd(player, 0.06f);
			ClickerCompat.SetClickerRadiusAdd(player, 0.5f);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 379 && legs.type == 380;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases click damage by 15%";
			/*player.GetModPlayer<ClickerPlayer>().clickerDamage += 0.15f;*/
			ClickerCompat.SetDamageAdd(player, 0.15f);
			ClickerCompat.EnableClickEffect(player, "ClickerClass:Embrittle");
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowSubtle = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MythrilBar, 10);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}