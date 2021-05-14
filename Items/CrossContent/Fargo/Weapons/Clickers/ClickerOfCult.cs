using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ObjectData;

using ClickerAddon.Projectiles.Clickers;

namespace ClickerAddon.Items.CrossContent.Fargo.Weapons.Clickers
{
	public class ClickerOfCult : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("FargowiltasSouls");
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Clicker of the Cult");
			Tooltip.SetDefault("Click on an enemy within range and sight to damage them");
			ClickerCompat.RegisterClickerWeapon(this);
			
			string SuperClone = ClickerCompat.RegisterClickEffect(mod, "CultClick", "Click of Cult", "Creates random Lunatic Cultist`s attack that deals damage", 10, new Color(1, 66, 149), delegate (Player player, Vector2 position, int type, int damage, float knockBack)
			{				
				int attack = Main.rand.Next(4);
				Vector2 center = Main.MouseWorld;
				if (attack == 1)
				{
					//Vector2 vec2_1 = ()
					int index = -1;
					for (int i = 0; i < 200; i++)
					{
						NPC npc = Main.npc[i];
						if (npc.active && npc.CanBeChasedBy() && Vector2.DistanceSquared(center, npc.Center) < 400f * 400f && Collision.CanHit(center, 1, 1, npc.Center, 1, 1))
						{
							index = i;
						}
					}
					if (index != -1)
					{
						for (int i = 0; i < 3; i++) {
							Vector2 vec2_1 = (Main.npc[index].Center - center).RotatedByRandom(Math.PI / 6.0);
							vec2_1.Normalize();
							Vector2 vec2_2 = vec2_1 * Utils.NextFloat(Main.rand, 6f, 10f);
							Projectile.NewProjectile(center, vec2_2, mod.ProjectileType("CultistFireball"), (int)(damage * 0.5f), knockBack, player.whoAmI); 
						}
					}
				}
				else if (attack == 2)
				{
					Main.PlaySound(SoundID.Item121, Main.MouseWorld);
					center.Y -= 100;
					Projectile.NewProjectile(center, Vector2.Zero, mod.ProjectileType("CultistLightningOrb"), damage, knockBack, player.whoAmI);
				}
				else if (attack == 3)
				{
					int index = -1;
					for (int i = 0; i < 200; i++)
					{
						NPC npc = Main.npc[i];
						if (npc.active && npc.CanBeChasedBy() && Vector2.DistanceSquared(center, npc.Center) < 400f * 400f && Collision.CanHit(center, 1, 1, npc.Center, 1, 1))
						{
							index = i;
						}
					}
					if (index != -1)
					{
						for (int i = 0; i < 3; i++)
						{
							Vector2 vec2_1 = Main.npc[index].Center - center;
							vec2_1.Normalize();
							Vector2 vec2_2 = vec2_1 * 4.25f;
							Projectile.NewProjectile(center, vec2_2, mod.ProjectileType("CultistIceMist"), damage, knockBack, player.whoAmI);
						}
					}
				}
			});
		}
		
		public override void SetDefaults()
		{
			/*isClicker = true;
			isClickerWeapon = true;
			radiusBoost = 6f;
			clickerColorItem = new Color(255, 255, 255, 0);
			clickerDustColor = 91;
			itemClickerAmount = 1;
			itemClickerEffect = "SuperConqueror";
			itemClickerColorEffect = "ffffff";*/
			
			ClickerCompat.SetClickerWeaponDefaults(item);
			ClickerCompat.SetRadius(item, 6f);
			ClickerCompat.SetColor(item, new Color(41, 66, 149, 0));
			ClickerCompat.SetDust(item, 226);
			ClickerCompat.AddEffect(item, "ClickerAddon:CultClick");
			
			item.damage = 92;
			item.width = 30;
			item.height = 30;
			item.knockBack = 1f;
			item.value = Item.sellPrice(gold: 5);
			item.rare = ItemRarityID.Red;
		}
	}
}
