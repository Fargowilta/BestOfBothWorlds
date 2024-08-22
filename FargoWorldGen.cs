using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace FargoSeeds
{
	class FargoWorldGen : ModSystem
	{
		public override void PreWorldGen()
		{
			WorldGen.drunkWorldGen = false;
			WorldGen.tenthAnniversaryWorldGen = false;
			WorldGen.getGoodWorldGen = false;

			Main.drunkWorld = false;
			Main.notTheBeesWorld = false;
			Main.getGoodWorld = false;
			Main.tenthAnniversaryWorld = false;
			Main.dontStarveWorld = false;
		}

		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
		{

			//int floatingIslandIndex = tasks.FindIndex(genPass => genPass.Name.Equals("Shinies"));

			//if (WorldConfig.Instance.BothOres)
			//{
			//	tasks.Insert(floatingIslandIndex, new PassLegacy("Toggle", ToggleDrunkSeedOn));
			//	tasks.Insert(floatingIslandIndex + 2, new PassLegacy("Toggle", ToggleDrunkSeedOff));
			//}




			int shiniesIndex = tasks.FindIndex(genPass => genPass.Name.Equals("Shinies"));

			if (WorldConfig.Instance.BothOres)
			{
				tasks.Insert(shiniesIndex, new PassLegacy("Toggle", ToggleDrunkSeedOn));
				tasks.Insert(shiniesIndex + 2, new PassLegacy("Toggle", ToggleDrunkSeedOff));
			}

			int underworldIndex = tasks.FindIndex(genPass => genPass.Name.Equals("Underworld"));

			if (WorldConfig.Instance.InvertedHell)
			{
				tasks.Insert(underworldIndex, new PassLegacy("Toggle", ToggleDrunkSeedOn));
				tasks.Insert(underworldIndex + 2, new PassLegacy("Toggle", ToggleDrunkSeedOff));
			}

			int corruptionIndex = tasks.FindIndex(genPass => genPass.Name.Equals("Corruption"));

            if (WorldConfig.Instance.BothEvils)
			{
				tasks.Insert(corruptionIndex, new PassLegacy("Toggle", ToggleDrunkSeedOn));
				tasks.Insert(corruptionIndex + 2, new PassLegacy("Toggle", ToggleDrunkSeedOff));
            }

            int cleanupIndex = tasks.FindIndex(genPass => genPass.Name.Equals("Tile Cleanup"));

            if (WorldConfig.Instance.BothEvils)
            {
                tasks.Insert(cleanupIndex, new PassLegacy("Toggle", ToggleDrunkSeedOn));
				tasks.Insert(cleanupIndex + 2, new PassLegacy("Toggle", ToggleDrunkSeedOff));
            }

            int oceanCavesIndex = tasks.FindIndex(genPass => genPass.Name.Equals("Create Ocean Caves"));

			if (WorldConfig.Instance.OceanCaves)
			{
				tasks.Insert(oceanCavesIndex, new PassLegacy("Toggle", ToggleDrunkSeedOn));
				tasks.Insert(oceanCavesIndex + 2, new PassLegacy("Toggle", ToggleDrunkSeedOff));
			}

			int pyramidIndex = tasks.FindIndex(genPass => genPass.Name.Equals("Pyramids"));

			if (WorldConfig.Instance.PyramidEntrance)
			{
				tasks.Insert(pyramidIndex, new PassLegacy("Toggle", ToggleCelebrationSeedOn));
				tasks.Insert(pyramidIndex + 2, new PassLegacy("Toggle", ToggleCelebrationSeedOff));
			}

			int livingTreeIndex = tasks.FindIndex(genPass => genPass.Name.Equals("Living Trees"));

			if (WorldConfig.Instance.LivingTrees)
			{
				tasks.Insert(livingTreeIndex, new PassLegacy("Toggle", ToggleDrunkSeedOn));
				tasks.Insert(livingTreeIndex + 2, new PassLegacy("Toggle", ToggleDrunkSeedOff));
			}

			int templeIndex = tasks.FindIndex(genPass => genPass.Name.Equals("Jungle Temple"));

			if (WorldConfig.Instance.HugeTemple)
			{
				tasks.Insert(templeIndex, new PassLegacy("Toggle", ToggleWorthySeedOn));
				tasks.Insert(templeIndex + 2, new PassLegacy("Toggle", ToggleWorthySeedOff));
			}

			int hiveIndex = tasks.FindIndex(genPass => genPass.Name.Equals("Hives"));

			if (WorldConfig.Instance.BigHives)
			{
				tasks.Insert(hiveIndex, new PassLegacy("Toggle", ToggleDrunkSeedOn));
				tasks.Insert(hiveIndex + 2, new PassLegacy("Toggle", ToggleDrunkSeedOff));
			}

			int spiderIndex = tasks.FindIndex(genPass => genPass.Name.Equals("Spider Caves"));

			if (WorldConfig.Instance.MoreSpiders)
			{
				tasks.Insert(spiderIndex, new PassLegacy("Toggle", ToggleWorthySeedOn));
				tasks.Insert(spiderIndex + 2, new PassLegacy("Toggle", ToggleWorthySeedOff));
			}

			int spawnIndex = tasks.FindIndex(genPass => genPass.Name.Equals("Spawn Point"));

			if (WorldConfig.Instance.OceanSpawn)
			{
				tasks.Insert(spawnIndex, new PassLegacy("Toggle", ToggleCelebrationSeedOn));
				tasks.Insert(spawnIndex + 2, new PassLegacy("Toggle", ToggleCelebrationSeedOff));
			}


            //drunk seed
            //more living mahigany trees
            //marble and granite swap generation
            //desert floating island
            //snow floating island
            //dead tree dungeon entrnce

            //not the bees
            //all water becomes honey

            //for the worthy
            //more lava pools
            //more granite/marble
            //more glowing mushroom
            //evil floating island
            //spiky dungeon
            //big glowing moss biome
            //underworld houses are hellstone
            //more lava underworld
            //some chests have a chance to have an angel statue in the first slot instead of a good thing

            //celebration
            //even more living trees
            //painted dungeon
            //rainbow undeground cabins
            //hallow floating island

            //private static void FinishTenthAnniversaryWorld()
            //{
            //	WorldGen.ConvertSkyIslands(2, true);
            //	WorldGen.PaintTheDungeon(24, 24);
            //	WorldGen.PaintTheLivingTrees(12, 12);
            //	WorldGen.PaintTheTemple(10, 5);
            //	WorldGen.PaintTheClouds(12, 12);
            //	WorldGen.PaintTheSand(7, 7);
            //	WorldGen.PaintThePyramids(12, 12);
            //	WorldGen.PaintThePurityGrass(7, 7);
            //	WorldGen.ImproveAllChestContents();
            //}

            //the constant
            //surface spider biomes
            //surface marble biomes
            //wavy caves



            /*ideas
			 * 
			// double chest spawns
			// start in hardmode
			// replace all sources of water with lava*/






            base.ModifyWorldGenTasks(tasks, ref totalWeight);
		}

		private void ToggleDrunkSeedOn(GenerationProgress progress, GameConfiguration configuration)
		{
			WorldGen.drunkWorldGen = true;
		}

		private void ToggleDrunkSeedOff(GenerationProgress progress, GameConfiguration configuration)
		{
			WorldGen.drunkWorldGen = false;
		}

		private void ToggleCelebrationSeedOn(GenerationProgress progress, GameConfiguration configuration)
		{
			Main.tenthAnniversaryWorld = true;
		}

		private void ToggleCelebrationSeedOff(GenerationProgress progress, GameConfiguration configuration)
		{
			Main.tenthAnniversaryWorld = false;
		}

		private void ToggleWorthySeedOn(GenerationProgress progress, GameConfiguration configuration)
		{
			WorldGen.getGoodWorldGen = true;
		}

		private void ToggleWorthySeedOff(GenerationProgress progress, GameConfiguration configuration)
		{
			WorldGen.getGoodWorldGen = false;
		}


		// Fix for incorrect Shadow Orb types
		/*
		public static bool PlacingCrimson = false;
        public override void Load()
        {
			On_WorldGen.CrimPlaceHearts += CrimPlaceHearts_Detour;
			On_WorldGen.AddShadowOrb += AddShadowOrb_Detour;
        }
        public override void Unload()
        {
            On_WorldGen.CrimPlaceHearts -= CrimPlaceHearts_Detour;
            On_WorldGen.AddShadowOrb -= AddShadowOrb_Detour;
        }
		private static void CrimPlaceHearts_Detour(On_WorldGen.orig_CrimPlaceHearts orig)
		{
			PlacingCrimson = true;
			orig();
			PlacingCrimson = false;
		}
		private static void AddShadowOrb_Detour(On_WorldGen.orig_AddShadowOrb orig, int x, int y)
		{
			bool crimson = WorldGen.crimson;
			WorldGen.crimson = PlacingCrimson;
			orig(x, y);
			Main.tile[x - 1, y - 1].TileFrameX = (short)(PlacingCrimson ? 36 : 0);
			WorldGen.crimson = crimson;
		}
		*/
    }
}
