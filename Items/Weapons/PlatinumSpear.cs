﻿using SSCStrawberryMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SSCStrawberryMod.Items.Weapons
{
	public class PlatinumSpear : ModItem
	{

		public override void SetDefaults()
		{
			item.damage = 10;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 26;
			item.useTime = 26;
			item.shootSpeed = 2.7f;
			item.knockBack = 6.5f;
			item.width = 38;
			item.height = 38;
			item.scale = 1f;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(silver: 17, copper: 55);

			item.melee = true;
			item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			item.autoReuse = false; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<PlatinumSpearProjectile>();
		}

		public override bool CanUseItem(Player player)
		{
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[item.shoot] < 1;
		}

        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PlatinumBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}