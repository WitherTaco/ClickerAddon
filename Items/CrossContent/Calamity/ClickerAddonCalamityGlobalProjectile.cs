using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Projectiles;

namespace ClickerAddon.Items.CrossContent.Calamity
{
	public class ClickerAddonCalamityGlobalProjectile : GlobalProjectile
	{
		public override bool Autoload(ref string name)
		{
			return ModLoader.GetMod("CalamityMod") != null;
		}
		public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{
			Player player = Main.LocalPlayer;
			Mod calamity = ModLoader.GetMod("CalamityMod");
			if (player.GetModPlayer<ClickerAddonPlayer>().ataxiaCapsuit && ClickerCompat.IsClickerItem(player.HeldItem))
			{
				if ((double)Main.player[Main.myPlayer].lifeSteal > 0.0 && target.canGhostHeal && (target.type != 488 && target.type != calamity.NPCType("SuperDummyNPC")) && !player.moonLeech)
				{
					float healMultiplier = 0.1f - (float)projectile.numHits * 0.05f;
					float healAmount = (float)projectile.damage * healMultiplier;
					if ((double)healAmount > 50.0)
						healAmount = 50f;
					if (CalamityGlobalProjectile.CanSpawnLifeStealProjectile(projectile, healMultiplier, healAmount))
						CalamityGlobalProjectile.SpawnLifeStealProjectile(projectile, player, healAmount, calamity.ProjectileType("AtaxiaHealOrb"), 1200f, 2f);
				}
			}
		}
	}
}