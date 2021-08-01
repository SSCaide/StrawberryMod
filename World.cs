using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSCStrawberryMod.Items.Weapons;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace SSCStrawberryMod
{
	public class World : ModWorld
	{
		public override void PostWorldGen()
		{
			int[] itemsToPlaceInDungeonChests = { ModContent.ItemType<Tonbogiri>() };
			int itemsToPlaceInDungeonChestsChoice = 0;
			int tonbogiriSpawns = 0;
			for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
			{
				if (tonbogiriSpawns > 1)
				{
					return;
				}
				Chest chest = Main.chest[Main.rand.Next(1000)];
				if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 2 * 36)
				{
					int inventoryIndex = 0;
					chest.item[inventoryIndex].SetDefaults(Main.rand.Next(itemsToPlaceInDungeonChests));
					itemsToPlaceInDungeonChestsChoice = (itemsToPlaceInDungeonChestsChoice + 1) % itemsToPlaceInDungeonChests.Length;
					tonbogiriSpawns++;
					break;
				}
			}
		}
	}
}
