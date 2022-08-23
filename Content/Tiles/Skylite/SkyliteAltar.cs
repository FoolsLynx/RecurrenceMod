using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Audio;

namespace RecurrenceMod.Content.Tiles.Skylite
{
    internal class SkyliteAltar : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileLighted[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Origin = new Point16(1, 2);
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(150, 150, 150), CreateMapEntryName());

            MinPick = 200;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.93f;
            g = 0.82f;
            b = 0.84f;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Themes.Skylite.SkyliteAltar>());
        }

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            bool canSpawn = false;
            if(!Main.hardMode)
            {
                int slot = RecurrenceUtils.GetInventorySlot(player, ItemID.Diamond);
                if(slot != -1)
                {
                    player.inventory[slot].stack--;
                    if (player.inventory[slot].stack == 0)
                    {
                        player.inventory[slot].SetDefaults();
                    }
                    canSpawn = true;
                }
            }
            if(canSpawn)
            {
                SoundEngine.PlaySound(SoundID.ForceRoar, player.position);
                if(Main.netMode != -1)
                {
                    NPC.SpawnOnPlayer(player.whoAmI, NPCID.BlueSlime);
                } else
                {
                    NetMessage.SendData(MessageID.SpawnBoss, -1, -1, null, player.whoAmI, NPCID.BlueSlime);
                }
                return true;
            }

            return false;
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ItemID.Diamond;
        }
    }
}
