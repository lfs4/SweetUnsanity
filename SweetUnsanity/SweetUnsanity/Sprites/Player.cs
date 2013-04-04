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

        float moveSpeed = .4f;

        int timeSinceLastFrame = 0;
        int millisecondsPerFrame = 75;

        float jumpHeight = .75f;

        public float gravity = .02f;
        float dy = 0;

       public float velocityY;
       public float velocityX;

       public bool jumped = false;
        bool wallJumped = false;

        float wallJumpDelay = 550f;
        float wallJumpTimer = 0f;

        bool gPressed = false;

        bool sPressed = false;

        public bool rightCollide = false;

        

        float gravSwitch = 1;

        string temp;

       

       




        
        
        public Player(Texture2D image, Vector2 _position, int height, int width, Point frameSize, Point currentFrame, Point sheetSize)
            : base(image, _position, height, width, frameSize, currentFrame, sheetSize)
        {
        }

        public Player(Texture2D image, Vector2 _position, int height, int width, Point frameSize, Point currentFrame, Point sheetSize, int miliSecondsPerFrame, int pixelOffset, int collisionOffset)
            : base(image, _position, height, width, frameSize, currentFrame, sheetSize,miliSecondsPerFrame,pixelOffset,collisionOffset)
        {    
            
        }



        public override void Update(GameTime gameTime)
        {
            KeyboardState keystate = Keyboard.GetState();

            //lastPosition = _position;

            _position.Y += velocityY;

            _position.X += velocityX;

            if (wallJumpTimer <= 0)
                wallJumped = false;
            else
                wallJumpTimer -= gameTime.ElapsedGameTime.Milliseconds;

            if (!wallJumped)
                velocityX = 0;

            if (keystate.IsKeyDown(Keys.A) || keystate.IsKeyDown(Keys.Left))
            {
              
                    if (!wallJumped)
                        velocityX -= moveSpeed * gameTime.ElapsedGameTime.Milliseconds;

            }
            if (keystate.IsKeyDown(Keys.D) || keystate.IsKeyDown(Keys.Right) )
            {


                    if (!wallJumped)
                        velocityX = +moveSpeed * gameTime.ElapsedGameTime.Milliseconds;
      

            }
            if (keystate.IsKeyDown(Keys.Space))
            {
                if (!jumped && !sPressed)
                {
                    velocityY -= jumpHeight * gameTime.ElapsedGameTime.Milliseconds * gravSwitch;
                    jumped = true;
                    sPressed = true;
                }
            }
            else if (sPressed)
                sPressed = false;


            if (keystate.IsKeyDown(Keys.G))
            {
                if (!gPressed)
                {
                    switchGravity();
                    gPressed = true;
                }
            }
            else if (gPressed)
                gPressed = false;


            velocityY += (gravity * gameTime.ElapsedGameTime.Milliseconds) * gravSwitch;

           CheckBounds(gameTime);

           // Console.WriteLine("Vx" + velocityX +  " " + "Vy" + velocityY);




           



            base.Update(gameTime);
        }
       private void CheckBounds(GameTime gameTime)
        {

            //temp = (ballPos.Y + velocityY).ToString();

            bool touchGround = false;

            KeyboardState keystate = Keyboard.GetState();


            if (_position.X + velocityX < 0)
            {
                _position.X = 0;
                velocityX = 0;

                if (keystate.IsKeyDown(Keys.Space) && !sPressed)
                {
                    wallJumped = true;
                    sPressed = true;
                    wallJumpTimer = wallJumpDelay;
                    velocityY = -1 * (jumpHeight * 0.75f) * gameTime.ElapsedGameTime.Milliseconds * gravSwitch;
                    velocityX = (moveSpeed * 0.75f) * gameTime.ElapsedGameTime.Milliseconds;
                }
            }
            if (_position.Y + velocityY < 0)
            {
                _position.Y = 0;
                velocityY = 0;

                if (gravSwitch == -1)
                {
                    jumped = false;
                    wallJumped = false;
                    touchGround = true;

                }
            }
            if (_position.X + velocityX > global.Window.ClientBounds.Width - _frameSize.X)
            {
                _position.X = global.Window.ClientBounds.Width - _frameSize.X;
                velocityX = 0;

                if (keystate.IsKeyDown(Keys.Space) && !sPressed)
                {
                    wallJumped = true;
                    sPressed = true;
                    wallJumpTimer = wallJumpDelay;
                    velocityY = -1 * (jumpHeight * 0.75f) * gameTime.ElapsedGameTime.Milliseconds * gravSwitch;
                    velocityX = -1 * (moveSpeed * 0.75f) * gameTime.ElapsedGameTime.Milliseconds;
                }
            }
            if (_position.Y + velocityY > 480 - _frameSize.Y)
            {
                _position.Y = 480 - frameSize.Y;
                velocityY = 0;

                if (gravSwitch == 1)
                {
                    jumped = false;
                    wallJumped = false;
                    touchGround = true;
                }
            }

            if (!touchGround)
                jumped = true;
        }

        public void switchGravity()
        {
            gravSwitch *= -1;
        }

    }
}