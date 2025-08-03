using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameContent.UI.Elements;
using Terraria.GameContent.UI.States;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.UI.Chat;
using static Terraria.WorldGen;

namespace FargoSeeds.UI
{
    internal class WorldGenUIManager : ModSystem
    {
        public UIElement InfoMenuParent;
        public UIElement InfoMenuParentParent;
        public bool IsActive = false;
        public static List<WorldGenToggle> Toggles = [];
        public int TogglesPerColumn => 6;
        public int ToggleXAmt => 1 + Toggles.Count / TogglesPerColumn;
        public override void Load()
        {
            base.Load();
        }
        public override void PostSetupContent()
        {
            // load stuff
            On_UIWorldCreation.MakeInfoMenu += MakeInfoMenu_Detour;
            On_UIWorldCreation.FinishCreatingWorld += FinishCreatingWorld_Detour;
        }

        UIPanel TogglePanel;

        private void MakeInfoMenu_Detour(On_UIWorldCreation.orig_MakeInfoMenu orig, UIWorldCreation self, UIElement parentContainer)
        {
            orig(self, parentContainer);
            InfoMenuParent = parentContainer;

            int num = 18;
            float panelWidth = 198f * ToggleXAmt;
            TogglePanel = new()
            {
                Width = StyleDimension.FromPixels(panelWidth),
                Height = StyleDimension.FromPixels(260),
                HAlign = 0.5f,
                VAlign = 1,
                Top = StyleDimension.FromPixels(-32f),
                BackgroundColor = new Color(33, 43, 79) * 0.8f
            };
            self.Append(TogglePanel);
            AddOptions(TogglePanel);
        }
        public void AddOptions(UIElement uiPanel)
        {
            int toggleWidth = 184;
            int toggleHeight = 34;
            int toggleSeparation = 8;

            int currentX = 0;
            int currentY = 0;
            int toggleCount = 0;
            foreach (WorldGenToggle toggle in Toggles)
            {
                UIWorldGenToggle uiToggle = new(toggle.EnabledByDefault, toggle.Title, toggle.Description, toggle.TextColor, toggle.IconTexturePath, toggle.Toggle)
                {
                    Width = StyleDimension.FromPixels(toggleWidth),
                    Height = StyleDimension.FromPixels(toggleHeight),
                    VAlign = 0f,
                    HAlign = 0f,
                    Top = StyleDimension.FromPixels(currentY),
                    Left = StyleDimension.FromPixels(currentX)
                };
                uiToggle.OnLeftMouseDown += Click_SetToggle;
                uiToggle.OnMouseOver += ShowToggleDescription;
                uiToggle.OnMouseOut += ClearToggleDescription;
                uiToggle.SetSnapPoint("WorldGenToggle" + toggleCount, 0);
                uiPanel.Append(uiToggle);
                currentY += toggleHeight + toggleSeparation;
                toggleCount++;
                if (toggleCount % TogglesPerColumn == 0)
                {
                    currentX += toggleWidth + toggleSeparation;
                    currentY = 0;
                }
            }

            /*
            UIVerticalSeparator separator = new()
            {
                Height = StyleDimension.FromPercent(1),
                HAlign = 0.5f,
                Color = Color.Lerp(Color.White, new Color(63, 65, 151, 255), 0.85f) * 0.9f
            };
            uiPanel.Append(separator);
            */
        }
        private void ShowToggleDescription(UIMouseEvent evt, UIElement listeningElement)
        {
            if (listeningElement is UIWorldGenToggle uiToggle)
            {
                LocalizedText localizedText = uiToggle.Description;
                //(typeof(UIWorldCreation).GetField("_descriptionText").GetValue(UIWorldCreation) as UIText).SetText(localizedText);
            }

        }
        private void ClearToggleDescription(UIMouseEvent evt, UIElement listeningElement)
        {
            //(typeof(UIWorldCreation).GetField("_descriptionText").GetValue(UIWorldCreation) as UIText).SetText(Language.GetText("UI.WorldDescriptionDefault"));
        }
        private void Click_SetToggle(UIMouseEvent evt, UIElement listeningElement)
        {
            // man the things i have to do to make UI work like i want
            /*
            if (!IsActive)
            {
                InfoMenuParentParent = InfoMenuParent.Parent;
                InfoMenuParent.Parent.RemoveChild(InfoMenuParent);
            }
            else
            {
                InfoMenuParentParent.Append(InfoMenuParent);
            }
            IsActive = !IsActive;
            */
        }

        private void FinishCreatingWorld_Detour(On_UIWorldCreation.orig_FinishCreatingWorld orig, UIWorldCreation self)
        {
            foreach (var toggle in TogglePanel.Children)
            {
                if (toggle is  UIWorldGenToggle uiToggle)
                {
                    uiToggle.InvokeToggle();
                }
            }
            orig(self);
        }
    }
}
