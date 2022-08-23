using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RecurrenceMod.Content.Tiles.Ores
{
    internal class FireElementOre : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileOreFinderPriority[Type] = 280;
            Main.tileSpelunker[Type] = true;
            Main.tileShine[Type] = 850;
            Main.tileShine2[Type] = true;

            TileID.Sets.Ore[Type] = true;

            AddMapEntry(new Color(168, 43, 18), CreateMapEntryName());

            ItemDrop = ModContent.ItemType<Items.Ores.FireElementOre>();
            HitSound = SoundID.Tink;

            MinPick = 45;
            MineResist = 1.3f;
        }
    }
}
