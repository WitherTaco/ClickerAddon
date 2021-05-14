using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace ClickerAddon.Tiles
{
	public class MiceCandle : ModTile
	{
		public override void SetDefaults() {
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleWrapLimit = 36;
			TileObjectData.addTile(Type);
			//dustType = 7;
			Main.tileLighted[Type] = true;
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
			AddMapEntry(WitherTacoLib.MiceColor);
		}
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.345f;
			g = 0.36f;
			b = 0.87f;
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			/*if (Main.tile[i, j].frameX == 0 && Main.tile[i, j].frameY == 0)
			{
				Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("MiceCandle"));
			}*/
			Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("MiceCandle"));
		}
	}
}