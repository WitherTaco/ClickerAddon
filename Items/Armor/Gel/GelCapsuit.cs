using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.Armor.Gel
{
	[AutoloadEquip(EquipType.Head)]
	public class GelCapsuit : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slimy Capsuit");
			ClickerCompat.RegisterClickerItem(this);
			//DisplayName.SetDefault("Adamantite Capsuit");
			Tooltip.SetDefault("Increases click damage by 2%");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 15;
			item.rare = 0;
			item.defense = 1;
		}

		public override void UpdateEquip(Player player)
		{
			ClickerCompat.SetDamageAdd(player, 0.02f);
			//ClickerCompat.EnableClickEffect(player, "ClickerClass:TrueStrike");
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("GelPlate") && legs.type == mod.ItemType("GelLeggins");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases your base click radius by 20%";
			/*player.GetModPlayer<ClickerPlayer>().clickerCrit += 4;*/
			ClickerCompat.SetClickerRadiusAdd(player, 0.4f);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gel, 15);
			recipe.SetResult(this);
			recipe.AddTile(TileID.WorkBenches);
			recipe.AddRecipe();
		}
	}
}