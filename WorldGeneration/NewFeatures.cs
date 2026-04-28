using Microsoft.Xna.Framework;
using StructureHelper;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Biomes.CaveHouse;
using Terraria.GameContent.Tile_Entities;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using static Terraria.GameContent.Animations.Actions.Sprites;

namespace FargoSeeds.WorldGeneration
{
    public static class NewFeatures
    {
        private static readonly bool[] BlacklistedTiles = TileID.Sets.Factory.CreateBoolSet(true, 225, 41, 43, 44, 226, 203, 112, 25, 151, 21, 467);

        public static Point16 FishingShackSize;
        enum FishingShackTypes
        {
            Base,
            Desert,
            Jungle,
            Mushroom,
            Tundra,
            None
        }
        private static FishingShackTypes GetFishingShackType(Point origin, int sizeX, int sizeY)
        {
            int sizeTotal = sizeX * sizeY;
            float sizeRequirement = sizeTotal * 0.6f;

            int tile = Main.tile[origin].TileType;
            if (tile == TileID.Stone || tile == TileID.Dirt)
            {
                // check for normal biome
                Dictionary<ushort, int> tileDictionary = [];
                WorldUtils.Gen(origin, new Shapes.Rectangle(sizeX, sizeY), new Actions.TileScanner(TileID.Stone, TileID.Dirt).Output(tileDictionary));
                if (tileDictionary[TileID.Stone] + tileDictionary[TileID.Dirt] > sizeRequirement)
                    return FishingShackTypes.Base;
                return FishingShackTypes.None;
            }
            if (tile == TileID.JungleGrass || tile == TileID.MushroomGrass) // jungle or mushroom biome
            {
                // check for jungle
                Dictionary<ushort, int> tileDictionary = [];
                WorldUtils.Gen(origin, new Shapes.Rectangle(sizeX, sizeY), new Actions.TileScanner(TileID.Mud, TileID.JungleGrass).Output(tileDictionary));
                if (tileDictionary[TileID.Mud] + tileDictionary[TileID.JungleGrass] > sizeRequirement)
                    return FishingShackTypes.Jungle;

                /*
                // check for mushroom biome
                tileDictionary = [];
                WorldUtils.Gen(origin, new Shapes.Rectangle(sizeX, sizeY), new Actions.TileScanner(TileID.Mud, TileID.MushroomGrass).Output(tileDictionary));
                if (tileDictionary[TileID.Mud] + tileDictionary[TileID.MushroomGrass] > sizeRequirement)
                    return FishingShackTypes.Mushroom;
                */
                return FishingShackTypes.None;
            }
            if (tile == TileID.IceBlock || tile == TileID.SnowBlock)
            {

                // check for tundra biome
                Dictionary<ushort, int> tileDictionary = [];
                WorldUtils.Gen(origin, new Shapes.Rectangle(sizeX, sizeY), new Actions.TileScanner(TileID.SnowBlock, TileID.IceBlock).Output(tileDictionary));
                if (tileDictionary[TileID.SnowBlock] + tileDictionary[TileID.IceBlock] > sizeRequirement)
                    return FishingShackTypes.Tundra;

                return FishingShackTypes.None;
            }
            return FishingShackTypes.None;
        }
        public static bool TryPlaceFishingShack(Point origin)
        {

            int extraX = WorldGen.genRand.Next(36, 42);
            int extraY = WorldGen.genRand.Next(7, 12);
            int extraYUp = (int)(extraY * 0.65f);
            int xPadding = 0;
            int totalWidth = FishingShackSize.X + extraX + xPadding;
            int totalHeight = FishingShackSize.Y + extraY + extraYUp;
            int dir = WorldGen.genRand.NextBool() ? 1 : -1;

            Point16 shackPos = new(origin.X, origin.Y);
            if (!WorldGen.InWorld(origin.X, origin.Y, 10))
                return false;

            var type = GetFishingShackType(origin, totalWidth, (int)(totalHeight * 1.5f));
            if (type == FishingShackTypes.None)
                return false;

            // turn origin into top left of expanded structure area
            if (dir < 0)
                origin.X -= extraX;
            else
                origin.X -= xPadding;
            origin.Y -= extraY;
            Rectangle rect = new(origin.X, origin.Y, FishingShackSize.X + extraX + xPadding, FishingShackSize.Y + extraY + extraYUp);

            if (WorldUtils.Find(new Point(rect.X - 2, rect.Y - 2), Searches.Chain(new Searches.Rectangle(rect.Width + 4, rect.Height + 4).RequireAll(mode: false), new Conditions.HasLava()), out var _))
                return false;

            if (GenVars.structures != null && !GenVars.structures.CanPlace(rect, BlacklistedTiles, 10))
            {
                return false;
            }

            string extra = "_" + type.ToString();

            // dig out opening
            Point digoutPos = new(origin.X, origin.Y + (int)(extraYUp * 1f));
            float passes = 6;
            for (int i = 0; i < passes; i++)
            {
                if (i == 0 && dir > 0 || i == passes - 1 && dir < 0)
                    continue;
                digoutPos.X += (int)(totalWidth / passes);
                WorldGen.TileRunner(digoutPos.X, digoutPos.Y, totalWidth * 0.55f, 10, -1, speedX: WorldGen.genRand.NextBool() ? 4f : -4f);
            }
            ushort tileType = type switch
            {
                FishingShackTypes.Tundra => TileID.IceBlock,
                FishingShackTypes.Jungle => TileID.Mud,
                FishingShackTypes.Desert => TileID.Sandstone,
                FishingShackTypes.Mushroom => TileID.Mud,
                _ => TileID.Stone
            };
            // make island
            var slime = new Shapes.Slime((int)(totalWidth * 0.7f), 1f, 0.4f);
            ShapeData slimeShapeData = new ShapeData();
            int islandX = origin.X + dir * (int)(extraX * 0f);
            if (dir > 0)
            {
                islandX += totalWidth / 2;
            }
            else
            {
                islandX += totalWidth / 2;
            }
            Point islandPos = new(islandX, origin.Y + totalHeight);
            // make the island blob
            WorldUtils.Gen(islandPos, slime, Actions.Chain(new Modifiers.Blotches(2, 1, 0.8), new Actions.SetTile(tileType), new Actions.SetFrames(frameNeighbors: true).Output(slimeShapeData)));
            // cut out blocks above house ground level
            Point cutoutPos = new(origin.X - 6, origin.Y + extraY - 1);
            var cutoutRect = new Shapes.Rectangle(new(0, 0, totalWidth + 12, FishingShackSize.Y));
            WorldUtils.Gen(cutoutPos, cutoutRect, Actions.Chain(new Modifiers.Blotches(2, 0.4), new Actions.ClearTile(frameNeighbors: true).Output(slimeShapeData)));
            // cut out lake
            Point lakePos = islandPos;
            lakePos.Y -= (int)(extraY * 0.9f);
            lakePos.X += dir * (int)(extraX * 0.27f);
            var lake = new Shapes.Slime((int)(totalWidth * 0.35f), 1f, 1.2f);
            WorldUtils.Gen(lakePos, lake, Actions.Chain(new Modifiers.Blotches(2, 1, 0.8), new Actions.ClearTile(frameNeighbors: true).Output(slimeShapeData)));
            // make water
            WorldUtils.Gen(lakePos, lake, Actions.Chain(new Modifiers.RectangleMask(-extraX - 4, extraX + 4, 3, extraY + 3), new Modifiers.IsEmpty(), new Actions.SetLiquid()));

            if (type == FishingShackTypes.Jungle) // grassify
            {
                for (int i = origin.X - 20; i < origin.X + totalWidth + 40; i++)
                {
                    for (int j = origin.Y - 20; j < origin.Y + totalHeight + 40; j++)
                    {
                        WorldGen.SpreadGrass(i, j, TileID.Mud, TileID.JungleGrass);
                    }
                }
                
            }

            // fill in frame
            for (int i = 0; i < FishingShackSize.X; i++)
            {
                for (int j = 0; j < FishingShackSize.Y; j++)
                {
                    Point p = new(shackPos.X + i, shackPos.Y + j);
                    Tile t = Main.tile[p];
                    if (t.TileType == TileID.ItemFrame)
                    {
                        int num13 = TEItemFrame.Find(p.X, p.Y);
                        if (num13 != -1 && ((TEItemFrame)TileEntity.ByID[num13]).item.stack > 0)
                        {
                            
                        }
                    }
                }
            }

            string path = "WorldGeneration/FishingShack";
            Mod mod = FargoSeeds.Mod;
            StructureHelper.API.Generator.GenerateStructure(path + extra, shackPos, mod);
            GenVars.structures?.AddProtectedStructure(rect, 20);
            return true;
        }
        public static void FishingShacks(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = Language.GetTextValue("Mods.FargoSeeds.WorldGenMessages.FishingShacks");

            string path = "WorldGeneration/FishingShack";
            Mod mod = FargoSeeds.Mod;
            if (FishingShackSize == Point16.Zero)
                FishingShackSize = StructureHelper.API.Generator.GetStructureDimensions(path + "_Base", mod);

            int amt = WorldGen.GetWorldSize() switch
            {
                0 => 8,
                1 => 12,
                2 => 16,
                _ => 8 * WorldGen.GetWorldSize() * 4
            };

            for (int i = 0; i < amt; i++)
            {
                progress.Set((float)i / amt);

                int attempts = 15000;



                for (int attempt = 0; attempt < attempts; attempt++)
                {
                    int x = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
                    int y = WorldGen.genRand.Next((int)(GenVars.worldSurfaceHigh + 230), Main.maxTilesY - 230);

                    Point origin = new(x, y);
                    if (TryPlaceFishingShack(origin))
                        break;
                }
            }
        }
    }
}
