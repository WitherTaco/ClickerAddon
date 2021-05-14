using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI;

namespace ClickerAddon.Items.CrossContent.SoA
{
	public class LunarCoinClone : CustomCurrencySingleCoin
	{
		public Color GemCurrencyColor = Color.Gray;

		public LunarCoinClone(int coinItemID, long currencyCap) : base(coinItemID, currencyCap)
		{

		}
		public override void GetPriceText(string[] lines, ref int currentLine, int price)
		{
			//Color color = GemCurrencyColor * (Main.mouseTextColor / byte.MaxValue);
			Color color = GemCurrencyColor;
			lines[currentLine++] = string.Format("[c/{0:X2}{1:X2}{2:X2}:{3} {4} {5}]", color.R, color.G, color.B, Lang.tip[50], price, "Lunidium Coins");
		}
	}
}