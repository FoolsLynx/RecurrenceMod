using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace RecurrenceMod.Content.Tiles.Skylite
{
    internal class SkyliteBlock : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;

            ItemDrop = ModContent.ItemType<Items.Themes.Skylite.SkyliteBlock>();

            AddMapEntry(new Color(200, 200, 200));
        }
    }
}
