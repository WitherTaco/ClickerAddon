using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ObjectData;

namespace ClickerAddon.Items.Weapons.Melee
{
	public class CursorBlade : ModItem
	{
		public override bool Autoload(ref string name)
		{
			//return ClickerCompat.ClickerClass != null;
			return false;
		}
		
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Fishron`s Clicker");
			Tooltip.SetDefault("Coming Soon");
		}
		
		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.value = 0;

			item.damage = 1;
			item.melee = true;
			item.knockBack = 1f;
			item.rare = ItemRarityID.White;

			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.autoReuse = false;
			item.UseSound = SoundID.Item1;
		}
	}
}
