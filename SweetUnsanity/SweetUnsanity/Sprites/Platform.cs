/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SweetUnsanity.SuperClasses;

namespace SweetUnsanity.Sprites
{
    
    class Platform: Sprite
    {
        Vector2  speed;

        int Id;

        public Platform(Texture2D textureImage, Vector2 position, Point frameSize, Point currentFrame, Point sheetSize,int Id)
            : base(textureImage,position,frameSize,currentFrame,sheetSize,Id)
        { 
        }

        public override Vector2 direction
        {
            get { return speed; }
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            _position += direction;

            

            base.Update(gameTime, clientBounds);
        }

    }
}*/
