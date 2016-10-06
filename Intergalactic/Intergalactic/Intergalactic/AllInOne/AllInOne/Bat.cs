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


namespace Intergalactic
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Bat : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        public Vector2 position;
        private Vector2 speed;

        public Bat(Game game, SpriteBatch spriteBatch,
            Texture2D tex)
            : base(game)
        {
            // TODO: Construct any child components here
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            position = new Vector2(Shared.stage.X/2 - tex.Width/2,
                Shared.stage.Y - tex.Height - 30);
            speed = new Vector2(4, 0);
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

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Right))
            {
                position += speed;
                if (position.X > Shared.stage.X - tex.Width)
                {
                    position.X = Shared.stage.X - tex.Width;                    
                }
            }
            if (ks.IsKeyDown(Keys.Left))
            {
                position -= speed;
                if (position.X < 0)
                {
                    position.X = 0;
                }
            }
            if (ks.IsKeyDown(Keys.Up))
            {
                position.Y -= 3;
                if (position.Y < 500)
                {
                    position.Y = 500;
                }
            }
            if (ks.IsKeyDown(Keys.Down))
            {
                if (position.Y > Shared.stage.Y - tex.Height - 30)
                {
                    position.Y = Shared.stage.Y - tex.Height - 30;
                }
                position.Y += 3;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
