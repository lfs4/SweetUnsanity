using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SweetUnsanity.SuperClasses
{

    abstract class Sprite
    {
        Texture2D image;

        protected Vector2 _position;

        int height;
        int width;

        
        protected Point frameSize;
        public  Point currentFrame;
        public  Point sheetSize;

        int millisecondsPerFrame;
        int timeSinceLastFrame = 0;
      
        const int defaultMillisecondsPerFrame = 100;

        const int defaultPixelOffset = 0;

        protected int pixelOffset;

        protected SpriteEffects _spriteEffects;

        public Sprite(Texture2D image, Vector2 _position, int height, int width, Point frameSize, Point currentFrame, Point sheetSize) :
            this(image, _position, height, width, frameSize, currentFrame, sheetSize,defaultMillisecondsPerFrame, defaultPixelOffset)
        {
 
        }

        public Sprite(Texture2D image, Vector2 _position, int height, int width, Point frameSize, Point currentFrame, Point sheetSize, int millisecondsPerFrame, int pixelOffset)
           
        {
            this.image = image;

            this._position = _position;

            this.height = height;
            this.width = width;

            this.frameSize = frameSize;
            this.currentFrame = currentFrame;
            this.sheetSize = sheetSize;
            this.millisecondsPerFrame = millisecondsPerFrame;
            this._spriteEffects = SpriteEffects.None;
            this.pixelOffset = pixelOffset;
            
        }

        public virtual void Update(GameTime gameTime)
        {
            Animate(gameTime);
        }


        void Animate(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame >= millisecondsPerFrame)
            {
                timeSinceLastFrame = 0;
                currentFrame.X++;
                if (currentFrame.X >= sheetSize.X)
                    currentFrame.X = 0;
            }

            if (currentFrame.Y == 0)
            {
                pixelOffset = 0;
            }
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(image,_position,
                new Rectangle(currentFrame.X * frameSize.X, (currentFrame.Y * frameSize.Y) + pixelOffset, frameSize.X, frameSize.Y),
                Color.White
                ,0,Vector2.Zero,1f,_spriteEffects,0);

        }


        
    }
    
}
