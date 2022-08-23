using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace RecurrenceMod
{
    internal static class RecurrenceUtils
    {

        public static bool CheckArea(int x, int y, int width, int height, List<ushort> tiles, bool fromCenter = true)
        {
            int x1 = x;
            int x2 = x + width;
            int y1 = y;
            int y2 = y + height;
            if(fromCenter)
            {
                x1 -= (int)(width * 0.5f);
                y1 -= (int)(height * 0.5f);
                x2 = x1 + width;
                y2 += height;
            }

            Tile tile;
            for(int i = x1; i < x2; i++)
            {
                for(int j = y1; j < y2; j++)
                {
                    tile = Main.tile[i, j];
                    if(!tile.HasTile)
                    {
                        continue;
                    }

                    ushort type = tile.TileType;
                    if (tiles.Contains(type))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool CheckAreaForLiquid(int x, int y, int width, int height, int liquidType, int requiredAmount = 255, bool fromCenter = true)
        {
            int x1 = x;
            int x2 = x + width;
            int y1 = y;
            int y2 = y + height;
            if (fromCenter)
            {
                x1 -= (int)(width * 0.5f);
                y1 -= (int)(height * 0.5f);
                x2 = x1 + width;
                y2 += height;
            }

            Tile tile;
            int amount = 0;
            for (int i = x1; i < x2; i++)
            {
                for (int j = y1; j < y2; j++)
                {
                    tile = Main.tile[i, j];
                    if(tile.LiquidType == liquidType)
                    {
                        amount += tile.LiquidAmount;
                    }
                }
            }
            return amount >= requiredAmount;
        }

        public static bool CheckAreaForAir(int x, int y, int width, int height, int requiredAir, bool fromCenter = true)
        {
            int x1 = x;
            int x2 = x + width;
            int y1 = y;
            int y2 = y + height;
            if (fromCenter)
            {
                x1 -= (int)(width * 0.5f);
                y1 -= (int)(height * 0.5f);
                x2 = x1 + width;
                y2 += height;
            }

            int counter = 0;
            Tile tile;
            for (int i = x1; i < x2; i++)
            {
                for (int j = y1; j < y2; j++)
                {
                    tile = Main.tile[i, j];
                    if (!tile.HasTile)
                    {
                        counter++;
                    }
                }
            }

            return counter >= requiredAir;
        }

        public static bool CheckTile(int x, int y, List<int> tiles)
        {
            Tile tile = Main.tile[x, y];
            if (!tile.HasTile) return false;

            int type = tile.TileType;
            if(tiles.Contains(type))
            {
                return true;
            }
            return false;
        }

        public static int GetInventorySlot(Player player, int id)
        {
            for(var i = 0; i < player.inventory.Length; i++)
            {
                if (player.inventory[i].type == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public static float ColourValueToFloat(int value)
        {
            return MathHelper.Clamp((float)(1 / 255) * value, 0.0f, 1.0f);
        }

        public static bool HasTarget(NPC npc)
        {
            if(npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                return false;
            }
            return true;
        }
    }
}
