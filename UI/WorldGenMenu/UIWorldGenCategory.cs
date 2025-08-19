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

namespace FargoSeeds.UI.WorldGenMenu
{
    public class UIWorldGenCategory : UIElement
    {
        private LocalizedText _titleText;
        private UIText _title;
        public LocalizedText Text
        {
            get 
            { 
                return _titleText; 
            }
        }
        public UIWorldGenCategory(LocalizedText title)
        {
            this.Width.Set(WorldGenUIManager.ToggleWidth, 0);
            this.Height.Set(WorldGenUIManager.ToggleHeight, 0);
            if (title != null)
            {
                _titleText = title;
                UIText uIText = new(title, 1f)
                {
                    HAlign = 0.5f,
                    VAlign = 0.5f,
                    Width = StyleDimension.FromPixelsAndPercent(0f - 10f, 1f),
                    Top = StyleDimension.FromPixels(0f),
                    TextColor = Color.White
                };
                Append(uIText);
                _title = uIText;
            }
        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            
        }

    }

}
