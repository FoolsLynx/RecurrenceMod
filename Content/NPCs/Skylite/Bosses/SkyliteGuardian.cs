using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RecurrenceMod.Content.NPCs.Skylite.Bosses
{
    [AutoloadBossHead]
    internal class SkyliteGuardian : ModNPC
    {
        public override void SetStaticDefaults()
        {
            
        }

        public override void SetDefaults()
        {
            
        }

        public override void BossLoot(ref string name, ref int potionType)
        {

        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            
        }

        public override void OnKill()
        {
            
        }


        public override void FindFrame(int frameHeight)
        {
            
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if(Main.netMode == NetmodeID.Server)
            {
                return;
            }

            if(NPC.life <= 0)
            {

            }
        }

        public override void AI()
        {
            // Target Closest NPC
            if(!RecurrenceUtils.HasTarget(NPC))
            {
                NPC.TargetClosest();
            }
            // Get Current Target Player
            Player player = Main.player[NPC.target];
            // Check if player is Dead
            if(player.dead)
            {
                // Start Despawn
                NPC.velocity.Y -= 0.04f;
                NPC.EncourageDespawn(20);
                return;
            }

        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {


            return true;
        }

        private void DrawWings(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColour)
        {

        }
    }
}
