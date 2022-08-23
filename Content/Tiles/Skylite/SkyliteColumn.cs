using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RecurrenceMod.Content.Tiles.Skylite
{
    internal class SkyliteColumn : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.IsBeam[Type] = true;

            AddMapEntry(new Color(128, 128, 128));

            ItemDrop = ModContent.ItemType<Items.Themes.Skylite.SkyliteColumn>();
        }
    }
}
