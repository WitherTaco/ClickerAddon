using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.Armor.Gel
{
	[AutoloadEquip(EquipType.Head)]
	public class PinkyCapsuit : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}
		
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			DisplayName.SetDefault("Pinky`s Capsuit");
			Tooltip.SetDefault("Increases click damage by 3%");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 24;
			item.rare = ItemRarityID.White;
			item.defense = 2;
		}

		public override void UpdateEquip(Player player)
		{
			ClickerCompat.SetDamageAdd(player, 0.03f);
			//ClickerCompat.EnableClickEffect(player, "ClickerClass:TrueStrike");
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("PinkyPlate") && legs.type == mod.ItemType("PinkyLeggins");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases your base click radius by 25%";
			/*player.GetModPlayer<ClickerPlayer>().clickerCrit += 4;*/
			ClickerCompat.SetClickerRadiusAdd(player, WitherTacoLib.Math.Radius(0.25f));
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GelCapsuit"), 1);
			recipe.AddIngredient(ItemID.PinkGel, 3);
			recipe.SetResult(this);
			recipe.AddTile(TileID.WorkBenches);
			recipe.AddRecipe();
		}
	}
}