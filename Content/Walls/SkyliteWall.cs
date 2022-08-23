using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace RecurrenceMod.Content.Walls
{
    internal class SkyliteWall : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;

            ItemDrop = ModContent.ItemType<Items.Themes.Skylite.SkyliteWall>();

            AddMapEntry(new Color(150, 150, 150));
        }
    }
}
