using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.GameInput;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClickerAddon.Other
{ 
	public class GraphicPlayer : ModPlayer
	{
		public bool rainbowGelArmorAnim = true;
		public bool rainbowGelArmor = false;
		public bool rainbowGelArmorDrow => rainbowGelArmor && rainbowGelArmorAnim;

		public bool lunarGelArmorAnim = true;
		public bool lunarGelArmor = false;
		public bool lunarGelArmorDrow => lunarGelArmor && lunarGelArmorAnim;

		public override void ResetEffects()
		{
			rainbowGelArmorAnim = true;
			rainbowGelArmor = false;

			lunarGelArmorAnim = true;
			lunarGelArmor = false;
		}
		public override void PostUpdateEquips()
		{

			//Armor
			int head = 0;
			int body = 1;
			int legs = 2;
			int vanityHead = 10;
			int vanityBody = 11;
			int vanityLegs = 12;

			Item itemHead = player.armor[head];
			Item itemBody = player.armor[body];
			Item itemLegs = player.armor[legs];

			Item itemVanityHead = player.armor[vanityHead];
			Item itemVanityBody = player.armor[vanityBody];
			Item itemVanityLegs = player.armor[vanityLegs];

			if (player.wereWolf || player.merman)
			{
				rainbowGelArmorAnim = false;
				lunarGelArmorAnim = false;
			}
			if(itemVanityHead.type > 0)
			{
				if (itemVanityHead.type != mod.ItemType("RainbowGelCapsuit"))
				{
					rainbowGelArmorAnim = false;
				}
				if (itemVanityHead.type != mod.ItemType("LunarGelCapsuit"))
				{
					lunarGelArmorAnim = false;
				}
			}
			if (itemVanityBody.type > 0)
			{
				if (itemVanityBody.type != mod.ItemType("RainbowGelPlate"))
				{
					rainbowGelArmorAnim = false;
				}
				if (itemVanityBody.type != mod.ItemType("LunarGelPlate"))
				{
					lunarGelArmorAnim = false;
				}
			}
			if (itemVanityLegs.type > 0)
			{
				if (itemVanityLegs.type != mod.ItemType("RainbowGelLeggins"))
				{
					rainbowGelArmorAnim = false;
				}
				if (itemVanityLegs.type != mod.ItemType("LunarGelLeggins"))
				{
					lunarGelArmorAnim = false;
				}
			}
		}
		public override void ModifyDrawLayers(List<PlayerLayer> layers)
		{
			int index = layers.IndexOf(PlayerLayer.HeldItem);
			if (index != -1)
			{
				layers.Insert(index + 1, WeaponGlow);
			}
			index = layers.IndexOf(PlayerLayer.Head);
			if (index != -1)
			{
				layers.Insert(index + 1, HeadGlow);
			}
			index = layers.IndexOf(PlayerLayer.Legs);
			if (index != -1)
			{
				layers.Insert(index + 1, LegsGlow);
			}
			index = layers.IndexOf(PlayerLayer.Body);
			if (index != -1)
			{
				layers.Insert(index + 1, BodyGlow);
			}
			index = layers.IndexOf(PlayerLayer.Arms);
			if (index != -1)
			{
				layers.Insert(index + 1, ArmsGlow);
			}
			/*index = layers.IndexOf(PlayerLayer.MiscEffectsFront);
			if (index != -1)
			{
				layers.Insert(index + 1, MiscEffects);
			}*/

			WeaponGlow.visible = true;
			HeadGlow.visible = true;
			BodyGlow.visible = true;
			LegsGlow.visible = true;
			ArmsGlow.visible = true;
			//MiscEffects.visible = true;
		}
		public static readonly PlayerLayer HeadGlow = new PlayerLayer("ClickerAddon", "HeadGlow", PlayerLayer.Head, delegate (PlayerDrawInfo drawInfo)
		{
			Player drawPlayer = drawInfo.drawPlayer;
			Mod mod = ModLoader.GetMod("ClickerAddon");
			ClickerAddonPlayer modPlayer = drawPlayer.GetModPlayer<ClickerAddonPlayer>();
			GraphicPlayer modPlayerGraphic = drawPlayer.GetModPlayer<GraphicPlayer>();
			Color color = drawPlayer.GetImmuneAlphaPure(Color.White, drawInfo.shadow);
			Texture2D texture = null;

			if (drawInfo.shadow != 0f || drawInfo.drawPlayer.invis)
			{
				return;
			}

			if (modPlayerGraphic.rainbowGelArmorDrow)
			{
				texture = mod.GetTexture("Items/Armor/Gel/RainbowGelCapsuit_Head");
				color = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB, 0f);
			}
			else if (modPlayerGraphic.lunarGelArmorDrow)
			{
				texture = mod.GetTexture("Items/CrossContent/SoA/Armor/LunarGelCapsuit_Head");
				color = modPlayer.lunarColor;
			}
			else
			{
				color = drawPlayer.GetImmuneAlphaPure(Color.White, drawInfo.shadow);
			}

			if (texture == null)
			{
				return;
			}
			Vector2 drawPos = drawInfo.position - Main.screenPosition + new Vector2(drawPlayer.width / 2 - drawPlayer.bodyFrame.Width / 2, drawPlayer.height - drawPlayer.bodyFrame.Height + 4f) + drawPlayer.headPosition;
			DrawData drawData = new DrawData(texture, drawPos.Floor() + drawInfo.headOrigin, drawPlayer.bodyFrame, color, drawPlayer.headRotation, drawInfo.headOrigin, 1f, drawInfo.spriteEffects, 0)
			{
				shader = drawInfo.headArmorShader
			};
			Main.playerDrawData.Add(drawData);
		});
		public static readonly PlayerLayer BodyGlow = new PlayerLayer("ClickerAddon", "BodyGlow", PlayerLayer.Body, delegate (PlayerDrawInfo drawInfo)
		{
			Player drawPlayer = drawInfo.drawPlayer;
			Mod mod = ModLoader.GetMod("ClickerAddon");
			ClickerAddonPlayer modPlayer = drawPlayer.GetModPlayer<ClickerAddonPlayer>();
			GraphicPlayer modPlayerGraphic = drawPlayer.GetModPlayer<GraphicPlayer>();
			Color color = drawPlayer.GetImmuneAlphaPure(Color.White, drawInfo.shadow);
			Texture2D texture = null;

			if (drawInfo.shadow != 0f || drawInfo.drawPlayer.invis)
			{
				return;
			}

			if (modPlayerGraphic.rainbowGelArmorDrow)
			{
				texture = mod.GetTexture("Items/Armor/Gel/RainbowGelPlate_Body");
				color = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB, 0f);
			}
			else if (modPlayerGraphic.lunarGelArmorDrow)
			{
				texture = mod.GetTexture("Items/CrossContent/SoA/Armor/LunarGelPlate_Body");
				color = modPlayer.lunarColor;
			}
			else
			{
				color = drawPlayer.GetImmuneAlphaPure(Color.White, drawInfo.shadow);
			}

			if (texture == null)
			{
				return;
			}
			Vector2 drawPos = drawInfo.position - Main.screenPosition + new Vector2(drawPlayer.width / 2 - drawPlayer.bodyFrame.Width / 2, drawPlayer.height - drawPlayer.bodyFrame.Height + 4f) + drawPlayer.bodyPosition;
			DrawData drawData = new DrawData(texture, drawPos.Floor() + drawPlayer.bodyFrame.Size() / 2, drawPlayer.bodyFrame, color, drawPlayer.bodyRotation, drawInfo.bodyOrigin, 1f, drawInfo.spriteEffects, 0)
			{
				shader = drawInfo.bodyArmorShader
			};
			Main.playerDrawData.Add(drawData);
		});
		public static readonly PlayerLayer ArmsGlow = new PlayerLayer("ClickerAddon", "ArmsGlow", PlayerLayer.Arms, delegate (PlayerDrawInfo drawInfo)
		{
			Player drawPlayer = drawInfo.drawPlayer;
			Mod mod = ModLoader.GetMod("ClickerAddon");
			ClickerAddonPlayer modPlayer = drawPlayer.GetModPlayer<ClickerAddonPlayer>();
			GraphicPlayer modPlayerGraphic = drawPlayer.GetModPlayer<GraphicPlayer>();
			Color color = drawPlayer.GetImmuneAlphaPure(Color.White, drawInfo.shadow);
			Texture2D texture = null;

			if (drawInfo.shadow != 0f || drawInfo.drawPlayer.invis)
			{
				return;
			}

			if (modPlayerGraphic.rainbowGelArmorDrow)
			{
				texture = mod.GetTexture("Items/Armor/Gel/RainbowGelPlate_Arms");
				color = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB, 0f);
			}
			else if (modPlayerGraphic.lunarGelArmorDrow)
			{
				texture = mod.GetTexture("Items/CrossContent/SoA/Armor/LunarGelPlate_Arms");
				color = modPlayer.lunarColor;
			}
			else
			{
				color = drawPlayer.GetImmuneAlphaPure(Color.White, drawInfo.shadow);
			}


			if (texture == null)
			{
				return;
			}
			Vector2 drawPos = drawInfo.position - Main.screenPosition + new Vector2(drawPlayer.width / 2 - drawPlayer.bodyFrame.Width / 2, drawPlayer.height - drawPlayer.bodyFrame.Height + 4f) + drawPlayer.bodyPosition;
			DrawData drawData = new DrawData(texture, drawPos.Floor() + drawPlayer.bodyFrame.Size() / 2, drawPlayer.bodyFrame, color, drawPlayer.bodyRotation, drawInfo.bodyOrigin, 1f, drawInfo.spriteEffects, 0)
			{
				shader = drawInfo.bodyArmorShader
			};
			Main.playerDrawData.Add(drawData);
		});
		public static readonly PlayerLayer LegsGlow = new PlayerLayer("ClickerAddon", "LegsGlow", PlayerLayer.Legs, delegate (PlayerDrawInfo drawInfo)
		{
			Player drawPlayer = drawInfo.drawPlayer;
			Mod mod = ModLoader.GetMod("ClickerAddon");
			ClickerAddonPlayer modPlayer = drawPlayer.GetModPlayer<ClickerAddonPlayer>();
			GraphicPlayer modPlayerGraphic = drawPlayer.GetModPlayer<GraphicPlayer>();
			Color color = drawPlayer.GetImmuneAlphaPure(Color.White, drawInfo.shadow);
			Texture2D texture = null;

			if (drawInfo.shadow != 0f || drawInfo.drawPlayer.invis)
			{
				return;
			}

			if (modPlayerGraphic.rainbowGelArmorDrow)
			{
				texture = mod.GetTexture("Items/Armor/Gel/RainbowGelLeggins_Legs");
				color = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB, 0f);
			}
			else if (modPlayerGraphic.lunarGelArmorDrow)
			{
				texture = mod.GetTexture("Items/CrossContent/SoA/Armor/LunarGelLeggins_Legs");
				color = modPlayer.lunarColor;
			}
			else
			{
				color = drawPlayer.GetImmuneAlphaPure(Color.White, drawInfo.shadow);
			}

			if (texture == null)
			{
				return;
			}
			Vector2 drawPos = drawInfo.position - Main.screenPosition + new Vector2(drawPlayer.width / 2 - drawPlayer.bodyFrame.Width / 2, drawPlayer.height - drawPlayer.bodyFrame.Height + 4f) + drawPlayer.bodyPosition;
			DrawData drawData = new DrawData(texture, drawPos.Floor() + drawPlayer.bodyFrame.Size() / 2, drawPlayer.bodyFrame, color, drawPlayer.bodyRotation, drawInfo.bodyOrigin, 1f, drawInfo.spriteEffects, 0)
			{
				shader = drawInfo.bodyArmorShader
			};
			Main.playerDrawData.Add(drawData);
		});
		public static readonly PlayerLayer WeaponGlow = new PlayerLayer("ClickerAddon", "WeaponGlow", PlayerLayer.HeldItem, delegate (PlayerDrawInfo drawInfo)
		{
			Player drawPlayer = drawInfo.drawPlayer;
			Mod mod = ModLoader.GetMod("ClickerAddon");
			GraphicPlayer modPlayer = drawPlayer.GetModPlayer<GraphicPlayer>();
			Color color = drawPlayer.GetImmuneAlphaPure(Color.White, drawInfo.shadow);
			Texture2D texture = null;

			if (drawInfo.shadow != 0f || drawPlayer.dead || drawPlayer.frozen || drawPlayer.itemAnimation <= 0)
			{
				return;
			}

			

			if (texture == null)
			{
				return;
			}

			Vector2 drawPos = drawInfo.position - Main.screenPosition + new Vector2(drawPlayer.width / 2 - drawPlayer.bodyFrame.Width / 2, drawPlayer.height - drawPlayer.bodyFrame.Height + 4f) + drawPlayer.bodyPosition;
			DrawData drawData = new DrawData(texture, drawPos.Floor() + drawPlayer.bodyFrame.Size() / 2, drawPlayer.bodyFrame, color, drawPlayer.bodyRotation, drawInfo.bodyOrigin, 1f, drawInfo.spriteEffects, 0)
			{
				shader = drawInfo.bodyArmorShader
			};
			Main.playerDrawData.Add(drawData);
		});
	}
}