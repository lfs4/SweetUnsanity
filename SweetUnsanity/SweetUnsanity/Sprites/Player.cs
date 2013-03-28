using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SweetUnsanity.SuperClasses;

namespace SweetUnsanity
{
    class Player: Sprite
    {
        bool Jumping = false;
        
        
        public Player(Texture2D image, Vector2 _position, int height, int width, Point frameSize, Point currentFrame, Point sheetSize)
            : base(image, _position, height, width, frameSize, currentFrame, sheetSize)
        { 
                
        
        }

        public Player(Texture2D image, Vector2 _position, int height, int width, Point frameSize, Point currentFrame, Point sheetSize, int miliSecondsPerFrame, int pixelOffset)
            : base(image, _position, height, width, frameSize, currentFrame, sheetSize,miliSecondsPerFrame,pixelOffset)
        {
           

        }

        public override void Update(GameTime gameTime)
        {

            

            if (Jumping == true)
                currentFrame.Y = 1;

            
                

            base.Update(gameTime);
        }

        
    }
}
