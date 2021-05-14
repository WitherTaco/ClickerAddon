using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Walls
{
	public class MiceBrickWall : ModWall
	{
		/*Main.wallHouse[Type] = true;
        drop = mod.ItemType("MiceBrickWall");*/
		public override void SetDefaults()
		{
			Main.wallHouse[Type] = true;
			drop = mod.ItemType("MiceBrickWall");
			AddMapEntry(new Color(56, 52, 158));
		}
	}
}
