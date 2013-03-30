using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SweetUnsanity.SuperClasses;

namespace SweetUnsanity.Sprites
{

    class Platform : Sprite
    {
        public Platform(Texture2D image, Vector2 _position, int height, int width, Point frameSize, Point currentFrame, Point sheetSize)
            : base(image, _position, height, width, frameSize, currentFrame, sheetSize)
        { 
            
        }
    }
}
