using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Config;

namespace FargoSeeds
{
    [Label("Fargo Seeds Config")]
    class WorldConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        public static WorldConfig Instance
        {
            get; private set;
        }

        public override void OnLoaded()
        {
            Instance = this;
        }

        [Header("$Mods.FargoSeeds.Configs.WorldConfig.Header0")]

        [Label("[i:4765] Tree Multiplier")]
        [Increment(1)]
        [Range(0, 5)]
        [DefaultValue(1)]
        [Slider]
        public int TreeMultiplier;

        [Label("[i:832] Living Tree Multiplier")]
        [Increment(1)]
        [Range(0, 5)]
        [DefaultValue(1)]
        [Slider]
        public int LivingTreeMultiplier;

        [Label("[i:4761] Surface Cave Multiplier")]
        [Increment(1)]
        [Range(0, 5)]
        [DefaultValue(1)]
        [Slider]
        public int CaveMultiplier;

        [Label("[i:838] Floating Island Multiplier")]
        [Increment(1)]
        [Range(0, 5)]
        [DefaultValue(1)]
        [Slider]
        public int FloatingIslandMultiplier;

        [Label("[i:3157] Marble Multiplier")]
        [Increment(1)]
        [Range(0, 5)]
        [DefaultValue(1)]
        [Slider]
        public int MarbleMultiplier;

        [Label("[i:3086] Granite Multiplier")]
        [Increment(1)]
        [Range(0, 5)]
        [DefaultValue(1)]
        [Slider]
        public int GraniteMultiplier;

        [Label("[i:952] Spider Cave Multiplier")]
        [Increment(1)]
        [Range(0, 5)]
        [DefaultValue(1)]
        [Slider]
        public int SpiderMultiplier;

        [Label("[i:1126] Hive Multiplier")]
        [Increment(1)]
        [Range(0, 5)]
        [DefaultValue(1)]
        [Slider]
        public int HiveMultiplier;

        [Label("[i:13] Ore Multiplier")]
        [Increment(1)]
        [Range(0, 5)]
        [DefaultValue(1)]
        [Slider]
        public int OreMultiplier;

        [Label("[i:3086] Gem Multiplier")]
        [Increment(1)]
        [Range(0, 5)]
        [DefaultValue(1)]
        [Slider]
        public int GemMultiplier;

        [Label("[i:306] Chest Multiplier")]
        [Increment(1)]
        [Range(0, 5)]
        [DefaultValue(1)]
        [Slider]
        public int ChestMultiplier;

        [Label("[i:345] Pot Multiplier")]
        [Increment(1)]
        [Range(0, 5)]
        [DefaultValue(1)]
        [Slider]
        public int PotMultiplier;

        [Label("[i:29] Life Crystal Multiplier")]
        [Increment(1)]
        [Range(0, 5)]
        [DefaultValue(1)]
        [Slider]
        public int LifeCrystalMultiplier;

        [Label("[i:52] Statue Multiplier")]
        [Increment(1)]
        [Range(0, 5)]
        [DefaultValue(1)]
        [Slider]
        public int StatueMultiplier;

        [Label("[i:539] Trap Multiplier")]
        [Increment(1)]
        [Range(0, 5)]
        [DefaultValue(1)]
        [Slider]
        public int TrapMultiplier;

        [Label("[i:2340][i:989] Microbiome Multiplier")]
        [Increment(1)]
        [Range(0, 5)]
        [DefaultValue(1)]
        [Slider]
        public int MicroMultiplier;





        [Header("$Mods.FargoSeeds.Configs.WorldConfig.HeaderToggles")]

        [Label("[i:86][i:1329] World Evil Toggle")]
        [DefaultValue(true)]
        public bool EvilToggle;

        [Label("[i:134] Dungeon Toggle")]
        [DefaultValue(true)]
        public bool DungeonToggle;

        [Label("[i:2625] Ocean Toggle")]
        [DefaultValue(true)]
        public bool OceanToggle;

        [Label("[i:276] Desert Toggle")]
        [DefaultValue(true)]
        public bool DesertToggle;

        [Label("[i:208] Jungle Toggle")]
        [DefaultValue(true)]
        public bool JungleToggle;

        [Label("[i:2358] Ice Toggle")]
        [DefaultValue(true)]
        public bool IceToggle;

        [Label("[i:2358] Caves Toggle")]
        [DefaultValue(true)]
        public bool CavesToggle;

        [Label("[i:183] Glowing Mushroom Toggle")]
        [DefaultValue(true)]
        public bool MushroomToggle;

        [Label("[i:318] Underworld Toggle")]
        [DefaultValue(true)]
        public bool UnderworldToggle;

        [Label("[i:5340] Aether Toggle")]
        [DefaultValue(true)]
        public bool AetherToggle;


        [Header("$Mods.FargoSeeds.Configs.WorldConfig.Header1")]
        [Label("[i:68][i:1330] Both Evils")]
        [DefaultValue(true)]
        public bool BothEvils;

        [Label("[i:12][i:699] Spawn Both Ore Sets")]
        [DefaultValue(true)]
        public bool BothOres;

        [Label("[i:3157][i:3086] Marble and Granite Swapped")]
        [DefaultValue(false)]
        public bool MarbleGraniteSwapped;

        [Label("[i:207] Inverted Underworld")]
        [DefaultValue(false)]
        public bool InvertedHell;

        [Label("[i:324] Guarantee Ocean Caves")]
        [DefaultValue(true)]
        public bool OceanCaves;

        [Label("[i:832] More Surface Living Trees")]
        [DefaultValue(false)]
        public bool LivingTrees;

        [Label("[i:5066] Big Bee Hives")]
        [DefaultValue(false)]
        public bool BigHives;

        [Label("[i:5066] Underground Dungeon")]
        [DefaultValue(false)]
        public bool UndergroundDungeon;

        [Label("[i:3360] Mahogany Trees Everywhere")]
        [DefaultValue(false)]
        public bool MahoganyTrees;


        [Header("$Mods.FargoSeeds.Configs.WorldConfig.Header2")]
        [Label("[i:848] Guarantee Pyramid Entrance to Underground Desert")]
        [DefaultValue(true)]
        public bool PyramidEntrance;

        [Label("[i:662] Rainbow Underground Cabins")]
        [DefaultValue(false)]
        public bool RainbowCabins;


        [Label("[i:662] Paint Everything")]
        [DefaultValue(false)]
        public bool PaintEverything;


        [Header("$Mods.FargoSeeds.Configs.WorldConfig.Header3")]
        [Label("[i:1153] Huge Jungle Temple")]
        [DefaultValue(false)]
        public bool HugeTemple;

        [Header("$Mods.FargoSeeds.Configs.WorldConfig.HeaderConstant")]
        [Label("[i:2607] Surface Spider Caves")]
        [DefaultValue(false)]
        public bool SurfaceSpiders;

        [Label("[i:3157] Surface Marble")]
        [DefaultValue(false)]
        public bool SurfaceMarble;

        [Label("[i:4524] Wavy Caves")]
        [DefaultValue(false)]
        public bool WavyCaves;

        [Header("$Mods.FargoSeeds.Configs.WorldConfig.HeaderTraps")]
        [Label("[i:5384] \"No\" Traps")]
        [DefaultValue(false)]
        public bool NoTraps;

        [Header("$Mods.FargoSeeds.Configs.WorldConfig.HeaderRemix")]
        [Label("[i:59][i:2171] Evil Surface")]
        [DefaultValue(false)]
        public bool EvilSurface;

        [Label("[i:1153] Surface Temple")]
        [DefaultValue(false)]
        public bool SurfaceTemple;

        [Label("[i:207] Remix Underworld")]
        [DefaultValue(false)]
        public bool RemixUnderworld;

        [Label("[i:183] Mushroom Layer")]
        [DefaultValue(false)]
        public bool MushroomLayer;


        [Header("$Mods.FargoSeeds.Configs.WorldConfig.HeaderExtras")]
        [Label("[i:1169] Two Dungeons")]
        [DefaultValue(false)]
        public bool SecondDungeon;

        [Label("[i:5340] Two Shimmers")]
        [DefaultValue(false)]
        public bool SecondShimmer;

        [Label("[i:3031][i:4820][i:5302][i:5364] Replace all Liquids With")]
        [DefaultValue(LiquidReplace.None)]
        [Slider]
        public LiquidReplace liquidReplace;

        //[Label("[i:3031] Replace all Liquids with Water")]
        //[DefaultValue(false)]
        //public bool AllWater;

        //[Label("[i:4820] Replace all Liquids with Lava")]
        //[DefaultValue(false)]
        //public bool AllLava;

        //[Label("[i:5302] Replace all Liquids with Honey")]
        //[DefaultValue(false)]
        //public bool AllHoney;

        //[Label("[i:5364] Replace all Liquids with Shimmer")]
        //[DefaultValue(false)]
        //public bool AllShimmer;

        //[Label("[i:3031][i:4820][i:5302][i:5364] Randomly Swap Liquids")]
        //[DefaultValue(false)]
        //public bool LiquidSwap;

        [Label("[i:3335] Start in HardMode")]
        [DefaultValue(false)]
        public bool EarlyHardMode;

        [Label("[i:364] HardMode Ore")]
        [Increment(1)]
        [Range(0, 5)]
        [DefaultValue(0)]
        [Slider]
        public int HardModeOreMulti;

        [Label("[i:183] Surface Mushroom Biomes")]
        [Increment(1)]
        [Range(0, 5)]
        [DefaultValue(0)]
        [Slider]
        public int SurfaceMushroom;

        [Label("[i:267] Spawn Location")]
        [DefaultValue(SpawnLocation.Normal)]
        [Slider]
        public SpawnLocation spawnLocation;

        [Label("[i:267] Starting NPC")]
        [DefaultValue(StartingNPC.Guide)]
        [Slider]
        public StartingNPC startingNPC;

        //[Header("$Mods.FargoSeeds.Configs.WorldConfig.HeaderPost")]
        //[Label("[i:66] No Evil Spread")]
        //[DefaultValue(true)]
        //public bool NoEvilSpread;

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

        public enum LiquidReplace
        {
            None,
            Water,
            Lava,
            Honey,
            Shimmer,
            Random
        }
    }
}
