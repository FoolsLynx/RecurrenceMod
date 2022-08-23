using Microsoft.Xna.Framework;
using RecurrenceMod.Content.Items.Themes.Skylite.Furniture;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace RecurrenceMod.Content.Tiles.Furniture
{
    internal class RecurrenceBookcases : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileLavaDeath[Type] = true;

            AdjTiles = new int[] { TileID.Bookcases };

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
            TileObjectData.newTile.StyleWrapLimitVisualOverride = 37;
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(191, 142, 111), CreateMapEntryName());
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Main.NewText(string.Format("{0}, {1}", frameX, frameY));

            int style = frameX * (frameY + 1);
            int item = style switch
            {
                _ => ModContent.ItemType<SkyliteBookcase>(),
            };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, item);
        }
    }
}
