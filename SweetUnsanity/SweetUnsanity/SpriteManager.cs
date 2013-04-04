using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SweetUnsanity.SuperClasses;
using SweetUnsanity.Sprites;



namespace SweetUnsanity
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class SpriteManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        Player player;
        SpriteBatch spriteBatch;
        Platform platform;
        Platform platform2;

        List<Sprite> spriteList = new List<Sprite>();
        

        public SpriteManager(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            player = new Player(Game.Content.Load<Texture2D>(@"Images/spriteSheet"), Vector2.Zero,32,32,new Point(22, 40), new Point(0,1), new Point(3, 0), 100, 2,0);
            spriteList.Add(new Platform(Game.Content.Load<Texture2D>(@"Images/platformBox"), new Vector2(400,420), 64, 32, new Point(64, 32), new Point(0, 0), new Point(0, 0)));
            spriteList.Add(new Platform(Game.Content.Load<Texture2D>(@"Images/platformBox"), new Vector2(425, 320), 64, 32, new Point(64, 32), new Point(0, 0), new Point(0, 0)));
            //spriteList.Add(new Platform(Game.Content.Load<Texture2D>(@"Images/platformBox"), new Vector2(400,420), 64, 32, new Point(64, 32), new Point(0, 0), new Point(0, 0)));
           // platform2 = new Platform(Game.Content.Load<Texture2D>(@"Images/platformBox"), new Vector2(1000, 0), 64, 32, new Point(64, 32), new Point(0, 0), new Point(0, 0));
            base.LoadContent();
        }

        public void CheckCollision(){

            foreach (Sprite s in spriteList)
            {

                Vector2 depth = FindIntersectionDepth(player.collisionRect, s.collisionRect);

               

                if (depth != Vector2.Zero)
                {
                    if (Math.Abs(depth.X) > Math.Abs(depth.Y))
                    {
                        player.velocityY  = 0f;
                        player._position.Y -= depth.Y;
                        player.jumped = false;
                        CheckCollision();
                    }
                    else
                    {
                        player.velocityX = 0f;
                        player._position.X -= depth.X;
                        CheckCollision();
                    }


                }
            }

        }

        public Vector2 FindIntersectionDepth(Rectangle r1, Rectangle r2)
        {
            Vector2 depth = new Vector2(0, 0);

            if (r1.Intersects(r2))
            {
                int x1 = r1.Right - r2.Left;
                int x2 = r1.Left - r2.Right;
                int y1 = r1.Top - r2.Bottom;
                int y2 = r1.Bottom - r2.Top;


                depth.X = Math.Abs(x1) < Math.Abs(x2) ? x1 : x2;
                depth.Y = Math.Abs(y1) < Math.Abs(y2) ? y1 : y2;

                


                Console.WriteLine(r1.Bottom + " " + r2.Bottom);
               //Console.WriteLine("X1 " + " " + x1 + " " + "X2 " + x2 + " " + "Y1 " + y1 + " "  + "y2 " + y2);
               
            }

            //Console.WriteLine("X1 " + " " + x1 + " " + "X2 " + x2 + " " + "Y1 " + y1 + " " + "y2 " + y2);

            return depth;
        }


       

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
       
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            //Console.WriteLine(player.position.X);
           
            
            player.Update(gameTime);
            foreach (Sprite s in spriteList)
                s.Update(gameTime);
          //  if (player.velocityY != 0 || player.velocityX != 0)
                CheckCollision();
           // platform2.Update(gameTime);
           // Console.WriteLine(player.rightCollide);
            base.Update(gameTime);

        }
        

        public override void Draw(GameTime gameTime)
        {
            
            spriteBatch.Begin();
            foreach (Sprite s in spriteList)
                s.Draw(gameTime, spriteBatch);
             //platform2.Draw(gameTime, spriteBatch);
            player.Draw(gameTime,spriteBatch);
           

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
