using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace RecurrenceMod.Content.Tiles
{
    internal class RecurrenceBars : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileShine[Type] = 1100;
            Main.tileSolid[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.MetalBar"));
        }
        public override bool Drop(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            int style = tile.TileFrameX / 18;

            int item = style switch
            {
                1 => ModContent.ItemType<Items.Bars.FireElementBar>(),
                2 => ModContent.ItemType<Items.Bars.WaterElementBar>(),
                3 => ModContent.ItemType<Items.Bars.WindElementBar>(),
                _ => ModContent.ItemType<Items.Bars.EarthElementBar>(),
            };

            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, item);

            return base.Drop(i, j);
        }
    }
}
