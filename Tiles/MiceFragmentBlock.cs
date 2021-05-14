using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ClickerAddon.Tiles
{
	public class MiceFragmentBlock : ModTile
	{
		public override void SetDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			drop = mod.ItemType("MiceFragmentBlock");
			AddMapEntry(WitherTacoLib.MiceColor);
		}
		/*public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}*/
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.345f;
			g = 0.36f;
			b = 0.87f;
		}
	}
}