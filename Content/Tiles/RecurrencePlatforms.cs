using Microsoft.Xna.Framework;
using RecurrenceMod.Content.Items.Themes.Skylite;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace RecurrenceMod.Content.Tiles
{
    internal class RecurrencePlatforms : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileNoSunLight[Type] = true;

            TileID.Sets.Platforms[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
            AddMapEntry(new Color(200, 200, 200));

            TileObjectData.newTile.CoordinateHeights = new[] { 16 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleMultiplier = 27;
            TileObjectData.newTile.StyleWrapLimit = 27;
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.LavaDeath = true;
            TileObjectData.addTile(Type);
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            Tile tile = Main.tile[i, j];
            int style = tile.TileFrameX / 18;
            int item = style switch
            {
                _ => ModContent.ItemType<SkylitePlatform>(),
            };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, item);

            base.Drop(i, j);
        }

        public override bool CanKillTile(int i, int j, ref bool blockDamaged)
        {
            Tile tile = Main.tile[i, j];
            int style = tile.TileFrameX / 18;



            return true;
        }
    }
}
