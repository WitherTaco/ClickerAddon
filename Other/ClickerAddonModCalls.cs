using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using ClickerAddon;

public class ClickerAddonModCalls
{
	public static object Call(params object[] args)
	{
		Mod clickerAddon = ModLoader.GetMod("ClickerAddon");
		string success = "Success";
		try
		{
			string mes = args[0] as string;
			int index = 1;

			if(mes == "ClickerAddonStat")
			{
				var player = args[index + 0] as Player;
				var type = args[index + 1] as string;
				if (type == null)
				{
					throw new Exception($"Call Error: The statName argument for the attempted message, \"{mes}\" has returned null.");
				}
				if (player == null)
				{
					throw new Exception($"Call Error: The player argument for the attempted message, \"{mes}\" has returned null.");
				}
				ClickerAddonPlayer modPlayer = player.GetModPlayer<ClickerAddonPlayer>();
				if (type == "SetArmorSet")
				{
					var name = args[index + 2] as string;
					if (name == null)
					{
						throw new Exception($"Call Error: The armorName argument for the attempted message, \"{mes}\" has returned null.");
					}


					if (ModLoader.GetMod("CalamityMod") != null)
					{
						if (name == "reaver" || name == "Reaver")
							modPlayer.reaverCapsuit = true;
						else if (name == "hydrothermic" || name == "Hydrothermic")
							modPlayer.ataxiaCapsuit = true;
						else if (name == "bloodflare" || name == "Bloodflare" || name == "BloodFlare")
							modPlayer.bloodflareCapsuit = true;
						else if (name == "godslayer" || name == "godSlayer" || name == "GodSlayer")
							modPlayer.godSlayerCapsuit = true;
						else if (name == "silva" || name == "Silva")
							modPlayer.silvaCapsuit = true;
					}
					else
						throw new Exception($"Call Error: Calamity Mod is not loaded ");
				}
				if(type == "SetAccessory")
				{
					var name = args[index + 2] as string;
					if (name == null)
					{
						throw new Exception($"Call Error: The accName argument for the attempted message, \"{mes}\" has returned null.");
					}

					if (name == "magmaChair")
						modPlayer.magmaChair = true;
					if (name == "bigRedButton")
						modPlayer.bigRedButton = true;
					if (name == "bandOfClicking")
						modPlayer.bandOfClicking = true;
					if (name == "dice")
						modPlayer.diceEffect = true;
				}
				if(type == "SetOtherEffect")
				{
					var name = args[index + 2] as string;
					if (name == null)
					{
						throw new Exception($"Call Error: The otherEffectName argument for the attempted message, \"{mes}\" has returned null.");
					}

					if (name == "carbonatedPotion" || name == "CarbonatedPotion")
						ClickerCompat.EnableClickEffect(player, "ClickerAddon:Carbonated");
					if (name == "cheatautoclick" || name == "cheatAutoClick" || name == "CheatAutoClick")
						modPlayer.autoClicker = true;
					if (name == "cheatautoclick10x" || name == "cheatAutoClick10x" || name == "CheatAutoClick10x")
					{
						modPlayer.autoClicker = true;
						modPlayer.autoClickerMultiplier = new float[] { 0.1f, 10f };
					}
				}
			}
		}
		catch (Exception e)
		{
			clickerAddon.Logger.Error($"Call Error: {e.StackTrace} {e.Message}");
		}
		return null;
	}
}