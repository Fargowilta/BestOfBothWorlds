using FargoSeeds.UI.WorldGenMenu;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace FargoSeeds
{
	public class FargoSeeds : Mod
	{
        public override void Load()
        {
            base.Load();
            WorldGenUIManager.AddToggle(
                this,
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

            for (int i = 1; i < 30; i++)
            {
                WorldGenUIManager.AddToggle(
                    this,
                    Language.GetText("Example Toggle " + i),
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
            }
        }
        public override object Call(params object[] args)
        {
            try
            {
                string code = args[0].ToString();

                switch (code)
                {
                    case "AddWorldGenToggle":
                        {
                            if (args[1].GetType() != typeof(string)) // Your mod name
                                break;
                            if (args[2].GetType() != typeof(string)) // Toggle Title
                                break;
                            if (args[3].GetType() != typeof(string)) // Toggle Description
                                break;
                            if (args[4].GetType() != typeof(Color)) // Toggle title text color
                                break;
                            if (args[5].GetType() != typeof(string)) // Toggle icon texture path
                                break;
                            if (args[6].GetType() != typeof(bool)) // Default toggle value
                                break;
                            if (args[7].GetType() != typeof(Action<bool>)) // Toggle action (should flip your bool that determines the given worldgen option
                                break;
                            WorldGenUIManager.AddToggle(ModLoader.GetMod((string)args[1]), Language.GetText((string)args[2]), Language.GetText((string)args[3]), (Color)args[4], (string)args[5], (bool)args[6], (Action<bool>)args[7]);
                        }
                        break;
                    case "AddWorldGenSlider":
                        {
                            if (args[1].GetType() != typeof(string)) // Your mod name
                                break;
                            if (args[2].GetType() != typeof(string)) // Toggle Title
                                break;
                            if (args[3].GetType() != typeof(string)) // Toggle Description
                                break;
                            if (args[4].GetType() != typeof(Color)) // Toggle title text color
                                break;
                            if (args[5].GetType() != typeof(string)) // Toggle icon texture path
                                break;
                            if (args[6].GetType() != typeof(float)) // Default slider value
                                break;
                            if (args[7].GetType() != typeof(Action<float>)) // Toggle action (should flip your bool that determines the given worldgen option
                                break;
                            if (args[8].GetType() != typeof(Action<float>)) // Whether the slider should be locked to integers
                                break;
                            if (args[9].GetType() != typeof(List<float>)) // Slider range
                                break;
                            if (((List<float>)args[9]).Count != 2) // Range must have two elements (min, max)
                                break;
                            WorldGenUIManager.AddSlider(ModLoader.GetMod((string)args[1]), Language.GetText((string)args[2]), Language.GetText((string)args[3]), (Color)args[4], (string)args[5], (float)args[6], (Action<float>)args[7], (bool)args[8], (List<float>)args[9]);
                        }
                        break;
                }

            }
            catch (Exception e)
            {
                Logger.Error("Call Error: " + e.StackTrace + e.Message);
            }

            return base.Call(args);
        }
	}
}