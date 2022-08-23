using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RecurrenceMod.Content.Items.Themes.Skylite.Furniture;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace RecurrenceMod.Content.Tiles.Furniture
{
    internal class RecurrenceCandelabras : ModTile
    {
        private Asset<Texture2D> flameTexture;

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileLavaDeath[Type] = true;

            TileID.Sets.InteractibleByNPCs[Type] = true;

            AdjTiles = new int[] { TileID.Candelabras };

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(253, 221, 3), CreateMapEntryName());

            if(!Main.dedServ)
            {
                flameTexture = ModContent.Request<Texture2D>("RecurrenceMod/Content/Tiles/Furniture/RecurrenceCandelabras_Flame");
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int style = frameY / 36;
            int item = style switch
            {
                _ => ModContent.ItemType<SkyliteCandelabra>(),
            };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, item);
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Tile tile = Main.tile[i, j];

            int style = tile.TileFrameY / 36;

            if(tile.TileFrameX < 36)
            {
                switch(style)
                {
                    default:
                        r = 0.9f;
                        g = 0.9f;
                        b = 0.9f;
                        break;
                }
            }
        }

        public override void HitWire(int i, int j)
        {
            int left = i - (Main.tile[i, j].TileFrameX / 18) % 2;
            int top = j - (Main.tile[i, j].TileFrameY / 18) % 2;
            for(int x = left; x < left + 2; x++)
            {
                for(int y = top; y < top + 2; y++)
                {
                    if (Main.tile[x, y].TileFrameX >= 36)
                    {
                        Main.tile[x, y].TileFrameX -= 36;
                    } else
                    {
                        Main.tile[x, y].TileFrameX += 36;
                    }
                }
            }
            if(Wiring.running)
            {
                Wiring.SkipWire(left, top);
                Wiring.SkipWire(left, top + 1);
                Wiring.SkipWire(left + 1, top);
                Wiring.SkipWire(left + 1, top + 1);
            }
            NetMessage.SendTileSquare(-1, left, top + 1, 2);
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            ulong seed = Main.TileFrameSeed ^ (ulong)(((long)i << 32) | (uint)j);

            int style = Main.tile[i, j].TileFrameY / 36;

            int frameX = Main.tile[i, j].TileFrameX;
            int frameY = Main.tile[i, j].TileFrameY;

            int width = 20;
            int height = 20;

            int offsetX = 2;
            int offsetY = 2;
            Vector2 zero = new(Main.offScreenRange, Main.offScreenRange);
            if(Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            Color colour = new(255, 255, 255);
            switch(style)
            {
                default:
                    for(int k = 0; k < 7; k++)
                    {
                        float x = (float)Utils.RandomInt(ref seed, -10, 11) * 0.15f;
                        float y = (float)Utils.RandomInt(ref seed, -10, 1) * 0.35f; 
                        spriteBatch.Draw(
                            flameTexture.Value, 
                            new Vector2((float)(i * 16 - (int)Main.screenPosition.X + offsetX) - (width - 16f) / 2f + x, (float)(j * 16 - (int)Main.screenPosition.Y + offsetY) + y) + zero, 
                            new Rectangle(frameX, frameY, width, height), 
                            colour, 
                            0f, 
                            default, 
                            1f, 
                            SpriteEffects.None, 
                            0f
                        );
                    }
                    break;
            }
        }
    }
}
