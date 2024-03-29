﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace RecurrenceMod.Content.Biomes.Backgrounds
{
    internal class SkyPalaceBackgroundStyle : ModSurfaceBackgroundStyle
    {
        public override void ModifyFarFades(float[] fades, float transitionSpeed)
        {
			for (int i = 0; i < fades.Length; i++)
			{
				if (i == Slot)
				{
					fades[i] += transitionSpeed;
					if (fades[i] > 1f)
					{
						fades[i] = 1f;
					}
				}
				else
				{
					fades[i] -= transitionSpeed;
					if (fades[i] < 0f)
					{
						fades[i] = 0f;
					}
				}
			}
		}

        public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b)
        {
			return BackgroundTextureLoader.GetBackgroundSlot("RecurrenceMod/Assets/Textures/Backgrounds/SkyPalaceBiomeSurfaceClose");
        }

        public override int ChooseMiddleTexture()
        {
			return BackgroundTextureLoader.GetBackgroundSlot("RecurrenceMod/Assets/Textures/Backgrounds/SkyPalaceBiomeSurfaceMid");
        }

        public override int ChooseFarTexture()
        {
			return BackgroundTextureLoader.GetBackgroundSlot("RecurrenceMod/Assets/Textures/Backgrounds/SkyPalaceBiomeSurfaceFar");
		}
    }
}
