using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ObjectData;

namespace ClickerAddon.Items.CheatItem
{
	public class InfinityClicker : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerWeapon(this);
			//DisplayName.SetDefault("Old One`s Clicker");
			Tooltip.SetDefault("[c/FF0000:CHEAT ONLY]");
		}

		public override void SetDefaults()
		{
			ClickerCompat.SetClickerWeaponDefaults(item);
			ClickerCompat.SetRadius(item, 6f);
			ClickerCompat.SetColor(item, new Color(190, 60, 70, 0));
			ClickerCompat.SetDust(item, 87);
			//ClickerCompat.SetEffectW(item, "Holy Nova", 9);
			ClickerCompat.AddEffect(item, ClickerCompat.GetAllEffectNames());
			
			item.damage = 1;
			item.width = 30;
			item.height = 30;
			item.knockBack = 1f;
			item.value = 0;
			item.rare = ItemRarityID.Expert;
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB));
		}
	}
}
