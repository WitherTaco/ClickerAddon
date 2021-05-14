using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class SteveHead : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}
		
		public override void SetStaticDefaults()
		{
			//ClickerCompat.RegisterClickerItem(this);
			//DisplayName.SetDefault("Titanium Capsuit");
			Tooltip.SetDefault("[Secret Item]");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 400;
			item.rare = 0;
			//item.defense = 3;
			item.vanity = true;
		}

		/*public override void UpdateEquip(Player player)
		{
			ClickerCompat.SetDamageAdd(player, 0.1f);
		}*/
		
		public override bool DrawHead() {
			return false;
		}
		
        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = drawAltHair = false;
        }
	}
}