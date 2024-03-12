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

        [Header("$Mods.FargoSeeds.Configs.WorldConfig.Header1")]
        [Label("[i:68][i:1330] Both Evils")]
        [DefaultValue(true)]
        public bool BothEvils;

        [Label("[i:12][i:699] Spawn Both Ore Sets")]
        [DefaultValue(true)]
        public bool BothOres;

        [Label("[i:207] Inverted Underworld")]
        [DefaultValue(false)]
        public bool InvertedHell;

        [Label("[i:324] Guarantee Ocean Caves")]
        [DefaultValue(true)]
        public bool OceanCaves;

        [Label("[i:832] More Surface Living Trees")]
        [DefaultValue(true)]
        public bool LivingTrees;

        [Label("[i:5066] Big Bee Hives")]
        [DefaultValue(true)]
        public bool BigHives;




        [Header("$Mods.FargoSeeds.Configs.WorldConfig.Header2")]
        [Label("[i:848] Guarantee Pyramid Entrance to Underground Desert")]
        [DefaultValue(true)]
        public bool PyramidEntrance;

        [Label("[i:324] Ocean Spawn Point")]
        [DefaultValue(false)]
        public bool OceanSpawn;




        [Header("$Mods.FargoSeeds.Configs.WorldConfig.Header3")]
        [Label("[i:1153] Huge Jungle Temple")]
        [DefaultValue(true)]
        public bool HugeTemple;

        [Label("[i:952] Extra Spider Caves")]
        [DefaultValue(true)]
        public bool MoreSpiders;
    }
}
