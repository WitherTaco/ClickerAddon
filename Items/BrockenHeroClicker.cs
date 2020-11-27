using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items
{
	public class BrockenHeroClicker : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return ClickerCompat.ClickerClass != null;
		}
		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			/*Tooltip.SetDefault("15% increased clicker damage");*/
		}

		public override void SetDefaults() 
		{
			item.width = 16;
			item.height = 22;
			item.value = 75000;
			item.rare = 8;
			item.maxStack = 999;
		}
	}
}
