using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace FargoSeeds.UI
{
    public readonly struct WorldGenToggle(bool enabledByDefault, LocalizedText title, LocalizedText description, Color textColor, string iconTexturePath, Action<bool> toggle, Mod mod)
    {
        public readonly bool EnabledByDefault = enabledByDefault;
        public readonly LocalizedText Title = title;
        public readonly LocalizedText Description = description;
        public readonly Color TextColor = textColor;
        public readonly string IconTexturePath = iconTexturePath;
        public readonly Action<bool> Toggle = toggle;
        public readonly Mod Mod = mod;
    }

}
