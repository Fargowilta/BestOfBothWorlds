using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace FargoSeeds.UI.WorldGenMenu
{
    public class WorldGenOptions : ModSystem
    {
        public static string Path = "Mods.FargoSeeds.WorldGenMenu.";
        public override void Load()
        {
            AddOptions();
        }
        internal void AddToggle(LocalizedText category, string config, Color textColor, int iconItemID, bool defaultValue, Action<bool> action)
        {
            string iconTexturePath = "Terraria/Images/Item_" + iconItemID;
            WorldGenUIManager.AddToggle(
                Mod,
                category,
                Language.GetText(Path + config + ".Label"),
                Language.GetText(Path + config + ".Tooltip"),
                textColor,
                iconTexturePath,
                defaultValue,
                action
                );
        }
        internal void AddToggle(LocalizedText category, string config, Color textColor, string iconTexturePath, bool defaultValue, Action<bool> action)
        {
            WorldGenUIManager.AddToggle(
                Mod,
                category,
                Language.GetText(Path + config + ".Label"),
                Language.GetText(Path + config + ".Tooltip"),
                textColor,
                iconTexturePath,
                defaultValue,
                action
                );
        }
        internal void AddSlider(LocalizedText category, string config, Color textColor, string iconTexturePath, float defaultValue, Action<float> action, bool intSlider, List<float> sliderRange)
        {
            WorldGenUIManager.AddSlider(
                Mod,
                category,
                Language.GetText(Path + config + ".Label"),
                Language.GetText(Path + config + ".Tooltip"),
                textColor,
                iconTexturePath,
                defaultValue,
                action,
                intSlider,
                sliderRange
                );
        }
        internal void AddFrequencySlider(string config, Color textColor, int iconItemID, Action<float> action, int defaultValue = 1)
        {
            string iconTexturePath = "Terraria/Images/Item_" + iconItemID;
            WorldGenUIManager.AddSlider(
                Mod,
                Language.GetText(Path + "HeaderFrequency"),
                Language.GetText(Path + config + ".Label"),
                Language.GetText(Path + config + ".Tooltip"),
                textColor,
                iconTexturePath,
                defaultValue,
                action,
                true,
                [0, 5]
                );
        }
        internal void AddOptions()
        {
            string headerPath = Path + "Header";

            Color color = Color.White;

            // GENERAL
            LocalizedText header = Language.GetText(headerPath + "General");

            AddToggle(header, "BothEvils", color, ItemID.CrimstoneBlock, true, (value) => { BothEvils = value; });
            AddToggle(header, "BothOres", color, ItemID.TinOre, true, (value) => { BothOres = value; });

            // UNDERGROUND
            header = Language.GetText(headerPath + "Underground");
            AddToggle(header, "WavyCaves", color, ItemID.StoneBlock, true, (value) => { WavyCaves = value; });
            AddToggle(header, "RemixUnderworld", color, ItemID.Hellstone, true, (value) => { RemixUnderworld = value; });

            // SURFACE
            header = Language.GetText(headerPath + "Surface");
            AddToggle(header, "LivingTrees", color, 832, false, (value) => { LivingTrees = value; });
            AddToggle(header, "SurfaceMushroom", color, ItemID.GlowingMushroom, false, (value) => { SurfaceMushroom = value; });
            AddToggle(header, "SurfaceMarble", color, ItemID.MarbleBlock, false, (value) => { SurfaceMarble = value; });
            AddToggle(header, "SurfaceSpiders", color, ItemID.Cobweb, false, (value) => { SurfaceSpiders = value; });

            // STRUCTURE
            header = Language.GetText(headerPath + "Structure");
            AddToggle(header, "BigHives", color, ItemID.Hive, true, (value) => { BigHives = value; });
            AddToggle(header, "PyramidEntrance", color, 848, true, (value) => { PyramidEntrance = value; });
            AddToggle(header, "HugeTemple", color, 1153, false, (value) => { HugeTemple = value; });
            AddToggle(header, "SecondShimmer", color, ItemID.BottomlessShimmerBucket, false, (value) => { SecondShimmer = value; });

            // FREQUENCY
            AddFrequencySlider("CaveMultiplier", color, ItemID.StoneBlock, (value) => { CaveMultiplier = (int)value; });
            AddFrequencySlider("TreeMultiplier", color, 4765, (value) => { TreeMultiplier = (int)value; });
            AddFrequencySlider("FloatingIslandMultiplier", color, 838, (value) => { FloatingIslandMultiplier = (int)value; });
            AddFrequencySlider("MarbleMultiplier", color, ItemID.Marble, (value) => { MarbleMultiplier = (int)value; });
            AddFrequencySlider("GraniteMultiplier", color, ItemID.Granite, (value) => { GraniteMultiplier = (int)value; });
            AddFrequencySlider("SpiderMultiplier", color, 952, (value) => { SpiderMultiplier = (int)value; });
            AddFrequencySlider("HiveMultiplier", color, ItemID.Hive, (value) => { HiveMultiplier = (int)value; });
            AddFrequencySlider("OreMultiplier", color, 13, (value) => { OreMultiplier = (int)value; });
            AddFrequencySlider("GemMultiplier", color, ItemID.Diamond, (value) => { GemMultiplier = (int)value; });
            AddFrequencySlider("ChestMultiplier", color, 306, (value) => { ChestMultiplier = (int)value; });
            AddFrequencySlider("PotMultiplier", color, ItemID.ObsidianVase, (value) => { PotMultiplier = (int)value; });
            AddFrequencySlider("LifeCrystalMultiplier", color, 29, (value) => { LifeCrystalMultiplier = (int)value; });
            AddFrequencySlider("StatueMultiplier", color, 52, (value) => { StatueMultiplier = (int)value; });
            AddFrequencySlider("TrapMultiplier", color, 539, (value) => { TrapMultiplier = (int)value; });
            AddFrequencySlider("MicroMultiplier", color, ItemID.MinecartTrack, (value) => { MicroMultiplier = (int)value; });

            // MISC
            header = Language.GetText(headerPath + "Miscellaneous");
            AddToggle(header, "OceanCaves", color, ItemID.Coral, false, (value) => { OceanCaves = value; });
            AddToggle(header, "SurfaceTemple", color, 1153, false, (value) => { SurfaceTemple = value; });
            AddToggle(header, "EvilSurface", color, 59, false, (value) => { EvilSurface = value; });
            AddToggle(header, "NoTraps", color, ItemID.DartTrap, false, (value) => { NoTraps = value; });
            AddToggle(header, "MushroomLayer", color, 183, false, (value) => { MushroomLayer = value; });
            AddToggle(header, "RainbowCabins", color, ItemID.Paintbrush, false, (value) => { RainbowCabins = value; });
            AddToggle(header, "PaintEverything", color, ItemID.Paintbrush, false, (value) => { PaintEverything = value; });
            AddToggle(header, "MahoganyTrees", color, 3360, false, (value) => { MahoganyTrees = value; });
            AddToggle(header, "UndergroundDungeon", color, ItemID.BlueBrick, false, (value) => { UndergroundDungeon = value; });
            AddToggle(header, "MarbleGraniteSwapped", color, ItemID.Marble, false, (value) => { MarbleGraniteSwapped = value; });
        }

        #region General
        public static bool BothEvils;

        public static bool BothOres;
        #endregion

        #region Underground
        public static bool WavyCaves;

        public static bool RemixUnderworld;
        #endregion

        #region Surface
        public static bool LivingTrees;

        public static bool SurfaceMushroom;

        public static bool SurfaceMarble;

        public static bool SurfaceSpiders;
        #endregion

        #region Structure
        public static bool BigHives;

        public static bool PyramidEntrance;

        public static bool HugeTemple;

        public static bool SecondShimmer;
        #endregion

        #region Frequency
        // all of these are 0-5 int
        public static int TreeMultiplier;

        public static int CaveMultiplier;

        public static int FloatingIslandMultiplier;

        public static int MarbleMultiplier;

        public static int GraniteMultiplier;

        public static int SpiderMultiplier;

        public static int HiveMultiplier;

        public static int OreMultiplier;

        public static int GemMultiplier;

        public static int ChestMultiplier;

        public static int PotMultiplier;

        public static int LifeCrystalMultiplier;

        public static int StatueMultiplier;

        public static int TrapMultiplier;

        public static int MicroMultiplier;
        #endregion

        #region Misc
        public static bool OceanCaves;

        public static bool SurfaceTemple;

        public static bool EvilSurface;

        public static bool NoTraps;

        public static bool MushroomLayer;

        public static bool RainbowCabins;

        public static bool PaintEverything;

        public static bool MahoganyTrees;

        public static bool UndergroundDungeon;

        public static bool MarbleGraniteSwapped;
        #endregion

        /*

        [Label("[i:267] Spawn Location")]
        [DefaultValue(SpawnLocation.Normal)]
        [Slider]
        public SpawnLocation spawnLocation;

        
        [Label("[i:267] Starting NPC")]
        [DefaultValue(StartingNPC.Guide)]
        [Slider]
        public StartingNPC startingNPC;
        
        
        public enum SpawnLocation
        {
            Normal,
            Ocean,
            Underworld,
            Random
        }

        public enum StartingNPC
        {
            Guide,
            PartyGirl,
            Merchant,
            Demolitionist,
            PartyGroup,
            TaxCollector,
            Angler
        }
        */
    }
}
