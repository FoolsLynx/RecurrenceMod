using Microsoft.Xna.Framework;
using RecurrenceMod.Content.Items.Themes.Skylite.Furniture;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace RecurrenceMod.Content.Tiles.Furniture
{
    internal class RecurrenceBathtubs : ModTile
    {
        public const int NextStyleHeight = 38;

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;

            TileID.Sets.DisableSmartCursor[Type] = true;

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

            TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
            TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, -2);
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(144, 148, 144), CreateMapEntryName());
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Tile tile = Main.tile[i, j];
            int style = tile.TileFrameY / NextStyleHeight;
            int item = style switch
            {
                _ => ModContent.ItemType<SkyliteBathtub>(),
            };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, item);
        }
    }
}
