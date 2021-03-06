﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.CrossContent.SoA.Other
{
	public class LuxDustClicker : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("SacredTools");
		}
		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			DisplayName.SetDefault("Lux Shard Dust");
			//Tooltip.SetDefault("Don`t Effect");
		}

		public override void SetDefaults() 
		{
			item.width = 16;
			item.height = 22;
			item.value = Item.sellPrice(gold: 2);
			item.rare = ItemRarityID.Purple;
			item.maxStack = 1;
		}
		public override Color? GetAlpha(Color lightColor) => new Color?(Color.White);
	}
}
