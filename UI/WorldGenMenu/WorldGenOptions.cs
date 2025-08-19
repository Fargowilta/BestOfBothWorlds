using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Localization;
using Terraria.ModLoader;

namespace FargoSeeds.UI.WorldGenMenu
{
    public static class WorldGenOptions
    {
        internal static void AddOptions(Mod mod)
        {
            void AddToggleFromConfig(LocalizedText category, string config, Color textColor, string iconTexturePath, bool defaultValue, Action<bool> action)
            {
                string path = "Mods.FargoSeeds.Configs.WorldConfig.";
                WorldGenUIManager.AddToggle(
                    mod,
                    category,
                    Language.GetText(path + config + ".Label"),
                    Language.GetText(path + config + ".Tooltip"),
                    textColor,
                    iconTexturePath,
                    defaultValue,
                    action
                    );
            }
            void AddSliderFromConfig(LocalizedText category, string config, Color textColor, string iconTexturePath, float defaultValue, Action<float> action, bool intSlider, List<float> sliderRange)
            {
                string path = "Mods.FargoSeeds.Configs.WorldConfig.";
                WorldGenUIManager.AddSlider(
                    mod,
                    category,
                    Language.GetText(path + config + ".Label"),
                    Language.GetText(path + config + ".Tooltip"),
                    textColor,
                    iconTexturePath,
                    defaultValue,
                    action,
                    intSlider,
                    sliderRange
                    );
            }
            string headerPath = "Mods.FargoSeeds.WorldGen.Headers.";
            LocalizedText generalHeader = Language.GetText(headerPath + "General");
            LocalizedText undergroundHeader = Language.GetText(headerPath + "Underground");
            LocalizedText surfaceHeader = Language.GetText(headerPath + "Surface");
            LocalizedText structureHeader = Language.GetText(headerPath + "Structure");
            LocalizedText frequencyHeader = Language.GetText(headerPath + "Frequency");
            LocalizedText miscellaneousHeader = Language.GetText(headerPath + "Miscellaneous");

            Color color = Color.MediumPurple;


            // GENERAL
            AddToggleFromConfig(generalHeader, "BothEvils", color, null,
                WorldConfig.Instance.BothEvils, value =>
                {
                    WorldConfig.Instance.BothEvils = value;
                    WorldConfig.Instance.SaveChanges();
                }
            );

            // UNDERGROUND
            AddToggleFromConfig(generalHeader, "WavyCaves", color, null,
                WorldConfig.Instance.WavyCaves, value =>
                {
                    WorldConfig.Instance.WavyCaves = value;
                    WorldConfig.Instance.SaveChanges();
                }
            );

            // SURFACE

            // STRUCTURE

            // FREQUENCY

            // MISC

            /*
            WorldGenUIManager.AddToggle(
                this,
                Language.GetText("World Generation"),
                Language.GetText("Both Evils"),
                Language.GetText("Whether both Corruption and Crimson should be generated."),
                Color.MediumPurple,
                "Terraria/Images/UI/WorldCreation/IconEvilCorruption",
                WorldConfig.Instance.BothEvils,
                value =>
                {
                    WorldConfig.Instance.BothEvils = value;
                    WorldConfig.Instance.SaveChanges();
                }
                );

            WorldGenUIManager.AddSlider(
                this,
                Language.GetText("Multipliers"),
                Language.GetText("Cave Multiplier"),
                Language.GetText("Cave multiplier"),
                Color.MediumPurple,
                "Terraria/Images/UI/WorldCreation/IconEvilCorruption",
                WorldConfig.Instance.CaveMultiplier,
                value =>
                {
                    WorldConfig.Instance.CaveMultiplier = (int)(value * 5);
                    WorldConfig.Instance.SaveChanges();
                },
                true,
                [0, 5]
                );
            */
        }
    }
}
