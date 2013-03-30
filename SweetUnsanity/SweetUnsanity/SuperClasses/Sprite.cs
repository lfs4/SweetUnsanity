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

        
        protected Point _frameSize;
        public  Point currentFrame;
        public  Point sheetSize;

        int millisecondsPerFrame;
        int timeSinceLastFrame = 0;
      
        const int defaultMillisecondsPerFrame = 100;

        const int defaultPixelOffset = 0;

        const int defaultCollisionOffset = 0;

        protected int pixelOffset;

        protected int collisionOffset;

        protected SpriteEffects _spriteEffects;

        protected GlobalClass global;


        public Sprite(Texture2D image, Vector2 _position, int height, int width, Point frameSize, Point currentFrame, Point sheetSize) :
            this(image, _position, height, width, frameSize, currentFrame, sheetSize,defaultMillisecondsPerFrame, defaultPixelOffset, defaultCollisionOffset)
        {
 
        }

        public Sprite(Texture2D image, Vector2 _position, int height, int width, Point frameSize, Point currentFrame, Point sheetSize, int millisecondsPerFrame, int pixelOffset, int collisionOffset)
           
        {
            this.image = image;

            this._position = _position;

            this.height = height;
            this.width = width;

            this._frameSize = frameSize;
            this.currentFrame = currentFrame;
            this.sheetSize = sheetSize;
            this.millisecondsPerFrame = millisecondsPerFrame;
            this._spriteEffects = SpriteEffects.FlipHorizontally;
            this.pixelOffset = pixelOffset;
            this.collisionOffset = collisionOffset;
            this.global = new GlobalClass();

            
        }

        public Vector2 position {
            get {
                return this._position;
            }
            set {
                this._position = value; 
           }
        }
        public Point frameSize {
            get {
                return this._frameSize;
            }
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
                new Rectangle(currentFrame.X * _frameSize.X, (currentFrame.Y * _frameSize.Y) + pixelOffset, _frameSize.X, _frameSize.Y),
                Color.White
                ,0,Vector2.Zero,1f,_spriteEffects,0);

        }

        public Rectangle collisionRect {
            get {
                return new Rectangle(_position.X + collisionOffset, _position.Y, _frameSize.X, _frameSize.Y);
            }
            
        }

        
    }
    
}
