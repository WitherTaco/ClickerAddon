using Terraria;
using Terraria.ModLoader;

namespace ClickerAddon.Buffs
{
    public class CarbonatedBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Carbonated Happy");
            Description.SetDefault("Every 6 clicks creates a burp");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			ClickerCompat.EnableClickEffect(player, "ClickerAddon:Carbonated");
		}
	}
}