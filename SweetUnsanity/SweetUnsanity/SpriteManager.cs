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

            player = new Player(Game.Content.Load<Texture2D>(@"Images/spriteSheet"), Vector2.Zero,32,32, new Point(21,40), new Point(0, 0), new Point(3, 0),150,2,9);
            platform = new Platform(Game.Content.Load<Texture2D>(@"Images/platformBox"), new Vector2(100, 430), 64, 32, new Point(64, 32), new Point(0, 0), new Point(0, 0));
            platform2 = new Platform(Game.Content.Load<Texture2D>(@"Images/platformBox"), new Vector2(300, 330), 64, 32, new Point(64, 32), new Point(0, 0), new Point(0, 0));
            base.LoadContent();
        }
       

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
      

            if (player.collisionRect.Intersects(platform.collisionRect))
            {
                player.position = new Vector2(player.position.X, platform.position.Y - player.frameSize.Y);
                player.velocityY = 0;
                player.jumped = false;
            }
            if (player.collisionRect.Intersects(platform2.collisionRect))
            {
                player.position = new Vector2(player.position.X, platform2.position.Y - player.frameSize.Y);
                player.velocityY = 0;
                player.jumped = false;
            }

            player.Update(gameTime);
            platform.Update(gameTime);
            platform2.Update(gameTime);

            base.Update(gameTime);

        }

        public override void Draw(GameTime gameTime)
        {
            
            spriteBatch.Begin();
             platform.Draw(gameTime, spriteBatch);
             platform2.Draw(gameTime, spriteBatch);
            player.Draw(gameTime,spriteBatch);
           

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
