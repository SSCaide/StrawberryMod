using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace SSCStrawberryMod.Items.Weapons
{
    public class Spear : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if(item.type == ItemID.Spear)
            {
                item.damage = 7;
            }
        }
    }
}
