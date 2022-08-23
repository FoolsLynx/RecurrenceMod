using RecurrenceMod.Content.Tiles.Skylite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace RecurrenceMod.Common.Systems
{
    internal class RecurrenceBiomes : ModSystem
    {
        public int skyPalaceBlockCount;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            skyPalaceBlockCount = tileCounts[ModContent.TileType<SkyliteBlock>()];
            skyPalaceBlockCount += tileCounts[ModContent.TileType<SkyliteColumn>()];
        }
    }
}
