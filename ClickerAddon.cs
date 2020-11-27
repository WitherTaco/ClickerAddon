using Terraria.ModLoader;

namespace ClickerAddon
{
	//TODO for developers:
	//Add some projectile example
	public class ClickerAddon : Mod
	{
		public override void Load()
		{
			ClickerCompat.Load();
		}

		public override void Unload()
		{
			ClickerCompat.Unload();
		}
	}
}
