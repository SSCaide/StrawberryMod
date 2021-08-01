using Microsoft.Xna.Framework;
using SSCStrawberryMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SSCStrawberryMod.Items.Weapons
{
	public class DusksPoint : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dusk's Point");
		}

		public override void SetDefaults()
		{
			item.damage = 26;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 31;
			item.useTime = 30;
			item.shootSpeed = 2.7f;
			item.knockBack = 5f;
			item.width = 38;
			item.height = 38;
			item.scale = 1.5f;
			item.rare = ItemRarityID.Orange;
			item.value = Item.sellPrice(gold: 2, silver: 60);

			item.melee = true;
			item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<DusksPointProjectile>();
		}

		public override bool CanUseItem(Player player)
		{
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[item.shoot] < 1;
		}

		

		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.GetItem("ImpsPitchfork"));
			recipe.AddIngredient(mod.GetItem("Spearmint"));
			recipe.AddIngredient(mod.GetItem("Tonbogiri"));
			recipe.AddIngredient(mod.GetItem("DevilsFork"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(mod.GetItem("ImpsPitchfork"));
			recipe2.AddIngredient(mod.GetItem("Spearmint"));
			recipe2.AddIngredient(mod.GetItem("Tonbogiri"));
			recipe2.AddIngredient(ItemID.TheRottedFork);
			recipe2.AddTile(TileID.DemonAltar);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
		}
    }
}