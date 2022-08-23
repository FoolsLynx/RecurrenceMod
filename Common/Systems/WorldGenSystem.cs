using RecurrenceMod.Common.Systems.GenPasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;
using Terraria.WorldBuilding;

namespace RecurrenceMod.Common.Systems
{
    internal class WorldGenSystem : ModSystem
    {
        public static int cloudPalaceX;
        public static int cloudPalaceY;


        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {

            // Generate the Island for the Cloud Palace
            int cloudsIndex = tasks.FindIndex(x => x.Name.Equals("Floating Islands"));
            if(cloudsIndex != -1)
            {
                tasks.Insert(cloudsIndex + 1, new CloudPalaceBasePass());
            }

            // Generate the Cloud Palace
            int cloudsHouseIndex = tasks.FindIndex(x => x.Name.Equals("Floating Island Houses"));
            if(cloudsHouseIndex != -1)
            {
                tasks.Insert(cloudsHouseIndex + 1, new CloudPalacePass());
            }

            // Generate the Ore
            int shinesIndex = tasks.FindIndex(x => x.Name.Equals("Shinies"));
            if(shinesIndex != -1)
            {
                tasks.Insert(shinesIndex + 1, new OrePass());
            }
        }

        public override void ModifyHardmodeTasks(List<GenPass> list)
        {
            
        }
    }
}
