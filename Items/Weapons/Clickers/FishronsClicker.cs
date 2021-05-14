using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ObjectData;

namespace ClickerAddon.Items.Weapons.Clickers
{
	public class FishronsClicker : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerWeapon(this);
			DisplayName.SetDefault("Fishron`s Clicker");
			Tooltip.SetDefault("Click on an enemy within range and sight to damage them");

			string Terra = ClickerCompat.RegisterClickEffect(mod, "MiniSharkrones", "Mini Sharkrones", "Shot 4 Mini Sharkrones to the target", 8, new Color(32, 224, 144, 0), delegate (Player player, Vector2 position, int type, int damage, float knockBack)
			{
				Main.PlaySound(SoundID.Roar, (int)Main.MouseWorld.X, (int)Main.MouseWorld.Y, 5);
				Mod clickerClass = ModLoader.GetMod("ClickerClass");


				Vector2 pos = Main.MouseWorld;

				int index = -1;
				for (int i = 0; i < 200; i++)
				{
					NPC npc = Main.npc[i];
					if (npc.active && npc.CanBeChasedBy() && Vector2.DistanceSquared(pos, npc.Center) < 400f * 400f && Collision.CanHit(pos, 1, 1, npc.Center, 1, 1))
					{
						index = i;
					}
				}
				for (int i2 = 0; i2 < 4; i2++)
				{
					Vector2 pos2 = Main.MouseWorld + new Vector2(Main.rand.NextFloat(-50f, 50f), Main.rand.NextFloat(-10f, 10f));
					if (index != -1)
					{
						Vector2 vector = Main.npc[index].Center - pos2;
						float speed = 3f;
						float mag = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
						if (mag > speed)
						{
							mag = speed / mag;
						}
						vector *= mag;
						Projectile.NewProjectile(pos2.X, pos2.Y, vector.X * 3, vector.Y * 3, ProjectileID.MiniSharkron, damage, knockBack, player.whoAmI);
					}
				}
			});
		}
		
		public override void SetDefaults()
		{
			ClickerCompat.SetClickerWeaponDefaults(item);
			ClickerCompat.SetRadius(item, 6f);
			ClickerCompat.SetColor(item, new Color(32, 224, 144, 0));
			ClickerCompat.SetDust(item, 87);
			//ClickerCompat.SetEffectW(item, "Holy Nova", 9);
			ClickerCompat.AddEffect(item, "ClickerAddon:MiniSharkrones");
			
			item.damage = 84;
			item.width = 30;
			item.height = 30;
			item.knockBack = 1f;
			item.value = 75000 * 5;
			item.rare = ItemRarityID.Yellow;
		}
	}
}
