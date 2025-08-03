using FargoSeeds.UI;
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
            WorldGenUIManager.Toggles.Add(new WorldGenToggle(
                WorldConfig.Instance.BothEvils, // default value
                Language.GetText("Both Evils"), // toggle title
                Language.GetText("Whether both Corruption and Crimson should be generated."), // toggle description
                Color.MediumPurple, // toggle title text color
                "Images/UI/WorldCreation/IconEvilCorruption", // toggle icon texture path
                (bool value) => // toggle action
                {
                    WorldConfig.Instance.BothEvils = value;
                    WorldConfig.Instance.SaveChanges();
                }));
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
                            if (args[1].GetType() != typeof(bool)) // Default toggle value
                                break;
                            if (args[1].GetType() != typeof(string)) // Toggle Title
                                break;
                            if (args[1].GetType() != typeof(string)) // Toggle Description
                                break;
                            if (args[1].GetType() != typeof(Color)) // Toggle title text color
                                break;
                            if (args[1].GetType() != typeof(string)) // Toggle icon texture path
                                break;
                            if (args[1].GetType() != typeof(Action<bool>)) // Toggle action (should flip your bool that determines the given worldgen option
                                break;
                            WorldGenUIManager.Toggles.Add(new WorldGenToggle((bool)args[1], Language.GetText((string)args[2]), Language.GetText((string)args[3]), (Color)args[4], (string)args[5], (Action<bool>)args[6]));
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