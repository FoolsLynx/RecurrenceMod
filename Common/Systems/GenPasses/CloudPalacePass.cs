using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace RecurrenceMod.Common.Systems.GenPasses
{
    internal class CloudPalacePass : GenPass
    {
        public CloudPalacePass() : base("Cloud Palace", 1000f) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Creating the Palace";

            int palaceX = WorldGenSystem.cloudPalaceX;
            int palaceY = WorldGenSystem.cloudPalaceY;

            int surfaceX = palaceX;
            int surfaceY = palaceY;

            // Check if we are above the Surface
            if (!Main.tile[palaceX, palaceY].HasTile)
            {
                while (!Main.tile[surfaceX, surfaceY].HasTile)
                {
                    surfaceY++;
                    if(surfaceY >= palaceY + 20)
                    {
                        surfaceY = palaceY;
                        break;
                    }
                }
            } else if (Main.tile[palaceX, palaceY].HasTile)
            {
                // Check if we are below the surface
                while (Main.tile[surfaceX, surfaceY - 1].HasTile)
                {
                    surfaceY--;
                    if(surfaceY <= palaceY - 10)
                    {
                        surfaceY = palaceY;
                        break;
                    }
                }
            }
            // Get our Types
            int tileType = ModContent.TileType<Content.Tiles.Skylite.SkyliteBlock>();
            int wallType = ModContent.WallType<Content.Walls.SkyliteWall>();
            ushort windowType = WallID.Glass;

            // Randomise Settings
            int prioritySide = WorldGen.genRand.Next(2);
            switch(WorldGen.genRand.Next(7))
            {
                case 0: windowType = WallID.RedStainedGlass; break;
                case 1: windowType = WallID.OrangeStainedGlass; break;
                case 2: windowType = WallID.YellowStainedGlass; break;
                case 3: windowType = WallID.GreenStainedGlass; break;
                case 4: windowType = WallID.BlueStainedGlass; break;
                case 5: windowType = WallID.PurpleStainedGlass; break;
                case 6: windowType = WallID.Glass; break;
            }


            // Create the Box
            int palaceCenterX = surfaceX;
            int palaceCenterY = surfaceY - 8;

            int palaceX1 = palaceCenterX - 18;
            int palaceX2 = palaceCenterX + 18;
            int palaceY1 = palaceCenterY - 8;
            int palaceY2 = palaceCenterY + 8;

            Tile tile;

            for(int i = palaceX1; i <= palaceX2; i++)
            {
                for(int j = palaceY1; j <= palaceY2; j++)
                {
                    tile = Main.tile[i, j];
                    tile.ClearEverything();

                    WorldGen.PlaceTile(i, j, tileType, forced: true);
                }
            }
            // Add Walls
            for (int i = palaceX1 + 1; i <= palaceX2 - 1; i++)
            {
                for (int j = palaceY1 + 1; j <= palaceY2 - 1; j++)
                {
                    WorldGen.PlaceWall(i, j, wallType);
                }
            }
            // Remove the Center
            for (int i = palaceX1 + 2; i <= palaceX2 - 2; i++)
            {
                for(int j = palaceY1 + 2; j <= palaceY2 - 2; j++)
                {
                    tile = Main.tile[i, j];
                    tile.ClearTile();
                }
            }
            // Add the Windows
            int windowX = palaceCenterX - 8;
            int windowY = palaceCenterY - 1;
            for(int i = windowX - 1; i <= windowX + 1; i++)
            {
                for(int j = windowY - 3; j <= windowY + 3; j++)
                {
                    tile = Main.tile[i, j];
                    tile.Clear(TileDataType.Wall);
                    WorldGen.PlaceWall(i, j, windowType);
                }
            }
            windowX = palaceCenterX + 8;
            windowY = palaceCenterY - 1;
            for (int i = windowX - 1; i <= windowX + 1; i++)
            {
                for (int j = windowY - 3; j <= windowY + 3; j++)
                {
                    tile = Main.tile[i, j];
                    tile.Clear(TileDataType.Wall);
                    WorldGen.PlaceWall(i, j, windowType);
                }
            }

            // Cut out and Place Door
            int doorX1 = palaceX1;
            int doorY1 = palaceY2 - 4;
            int doorX2 = doorX1 + 1;
            int doorY2 = doorY1 + 2;

            int doorAnchorX = doorX1;
            int doorAnchorY = doorY2 - 1;
            if (prioritySide == 1)
            {
                doorX1 = palaceX2 - 1;
                doorX2 = doorX1 + 1;
                doorAnchorX = doorX2;
            }

            for (int i = doorX1; i <= doorX2; i++)
            {
                for(int j = doorY1; j <= doorY2; j++)
                {
                    tile = Main.tile[i, j];
                    tile.ClearTile();
                }
            }

            if(!WorldGen.PlaceDoor(doorAnchorX, doorAnchorY, TileID.ClosedDoor))
            {
                Recurrence.Instance.Logger.Info("Failed to Place Door");
                if(WorldGen.PlaceDoor(doorAnchorX, doorAnchorY - 3, TileID.ClosedDoor))
                {
                    Recurrence.Instance.Logger.Info("Placed 3 Tiles Above");
                }
            }

            // Create Door Platform
            int pX1, pX2, pY1, pY2;
            
            if(prioritySide == 1)
            {
                pX1 = palaceX2 + 1;
                pX2 = pX1 + 2;
            } else
            {
                pX1 = palaceX1 - 3;
                pX2 = pX1 + 2;
            }
            pY1 = palaceY2 - 1;
            pY2 = palaceY2;


            for(int i = pX1; i <= pX2; i++)
            {
                for(int j = pY1; j <= pY2; j++)
                {
                    tile = Main.tile[i, j];
                    tile.ClearTile();
                    WorldGen.PlaceTile(i, j, tileType, forced: true);
                }
            }

            if(prioritySide == 0)
            {
                tile = Main.tile[pX1, pY1];
                tile.Slope = SlopeType.SlopeDownRight;
            } else
            {
                tile = Main.tile[pX2, pY1];
                tile.Slope = SlopeType.SlopeDownLeft;
            }


            // Create the Roof
            int rX1 = palaceX1 - 4;
            int rX2 = palaceX2 + 4;
            int ry1 = palaceY1 - 5;
            int ry2 = palaceY1;

            for (int j = ry2; j >= ry1; j--)
            {
                for (int i = rX1; i <= rX2; i++)
                {
                    WorldGen.PlaceTile(i, j, tileType, forced: true);
                    WorldGen.PlaceTile(i, j - 1, tileType, forced: true);

                    tile = Main.tile[i, j - 1];
                    if(i == rX1)
                    {
                        tile.Slope = SlopeType.SlopeDownRight;
                    }
                    if(i == rX2)
                    {
                        tile.Slope = SlopeType.SlopeDownLeft;
                    }
                }
                rX1 += 4;
                rX2 -= 4;
            }

            // Place Roof Walls
            int rX3 = palaceX1 + 5;
            int rX4 = palaceX2 - 5;
            int rY3 = palaceY1 - 4;
            int rY4 = palaceY1 - 1;

            for(int j = rY4; j >= rY3; j--)
            {
                for (int i = rX3; i <= rX4; i++)
                {
                    tile = Main.tile[i, j];
                    tile.ClearTile();
                    WorldGen.PlaceWall(i, j, wallType);
                }
                rX3 += 4;
                rX4 -= 4;
            }

            // Columns
            int cX1 = palaceX1 + 6;
            int cY1 = palaceY1 + 2;
            int cY2 = palaceY2 - 2;

            for(int c = 0; c < 4; c++)
            {
                for(int j = cY1; j <= cY2; j++)
                {
                    WorldGen.PlaceTile(cX1, j, ModContent.TileType<Content.Tiles.Skylite.SkyliteColumn>(), forced: true);
                }
                cX1 += 8;
            }

            // Lanterns
            int lX1 = palaceX1 - 4;
            int lX2 = palaceX2 + 4;
            int lY2 = palaceY1 + 1;
            WorldGen.Place1x2Top(lX1, lY2, TileID.HangingLanterns, 0);
            WorldGen.Place1x2Top(lX2, lY2, TileID.HangingLanterns, 0);

            // Torches
            int tX = palaceX1 + 6;
            int tY = palaceY1 + 9;
            for(int i = 0; i < 4; i++)
            {
                tile = Main.tile[tX, tY];
                if(tile.TileType == ModContent.TileType<Content.Tiles.Skylite.SkyliteColumn>())
                {
                    WorldGen.PlaceTile(tX - 1, tY, TileID.Torches, style: 4);
                    WorldGen.PlaceTile(tX + 1, tY, TileID.Torches, style: 4);
                }
                tX += 8;
            }

            // Altar
            int aX = palaceCenterX;
            int aY = palaceY2 - 2;
            while(!WorldGen.PlaceTile(aX, aY, ModContent.TileType<Content.Tiles.Skylite.SkyliteAltar>()))
            {
                aY--;
                if(aY < palaceCenterY)
                {
                    Recurrence.Instance.Logger.Error(string.Format("Failed to place SkyliteAltar"));
                    break;
                }
            }

        }
    }
}
