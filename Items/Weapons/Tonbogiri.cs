using Microsoft.Xna.Framework;
using SSCStrawberryMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SSCStrawberryMod.Items.Weapons
{
	public class Tonbogiri : ModItem
	{

		public override void SetDefaults()
		{
			item.damage = 17;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 28;
			item.useTime = 27;
			item.shootSpeed = 2.7f;
			item.knockBack = 4f;
			item.width = 38;
			item.height = 38;
			item.scale = 1.5f;
			item.rare = ItemRarityID.Orange;
			item.value = Item.sellPrice(gold: 1, silver: 13, copper: 75);

			item.melee = true;
			item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<TonbogiriProjectile>();
		}

		public override bool CanUseItem(Player player)
		{
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[item.shoot] < 1;
		}

		

		
    }
}