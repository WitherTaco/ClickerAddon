using Terraria;
using Terraria.Graphics.Shaders;
using ClickerAddon;
using Terraria.ModLoader;

namespace ClickerAddon.NPCs.Bosses
{
	public class MiceData : ScreenShaderData
	{
		int NovaTowerIndex;

		public MiceData(string passName) : base(passName) { }

		void UpdatePuritySpiritIndex()
		{
			int NovaTowerType = ModLoader.GetMod("ClickerAddon").NPCType("MicePillar");
			if (NovaTowerIndex >= 0 && Main.npc[NovaTowerIndex].active && Main.npc[NovaTowerIndex].type == NovaTowerType)
			{
				return;
			}
			NovaTowerIndex = -1;
			for (int i = 0; i < Main.npc.Length; i++)
			{
				if (Main.npc[i].active && Main.npc[i].type == NovaTowerType)
				{
					NovaTowerIndex = i;
					break;
				}
			}
		}

		public override void Apply()
		{
			UpdatePuritySpiritIndex();
			if (NovaTowerIndex != -1)
			{
				UseTargetPosition(Main.npc[NovaTowerIndex].Center);
			}
			base.Apply();
		}
	}
}
