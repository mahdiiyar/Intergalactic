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
    public class ScrollingBackground : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Rectangle srcRect;
        private Vector2 position1, position2;
        private Vector2 speed;

        public ScrollingBackground(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Rectangle srcRect,
            Vector2 position,
            Vector2 speed)
            : base(game)
        {
            // TODO: Construct any child components here
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.srcRect = srcRect;
            this.speed = speed;

            this.position1 = position;
            this.position2 = new Vector2(position1.X, position1.Y - 690);
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


            //if (position1.X > -tex.Width)
            //{
            //    position1.X -= speed.X;
            //}
            //else
            //{
            //    position1.X = position2.X + tex.Width;
            //}

            //if (position2.X > -tex.Width)
            //{
            //    position2.X -= speed.X;
            //}
            //else
            //{
            //    position2.X = position1.X + tex.Width;
            //}


            if (position1.Y < 690)
            {
                position1.Y += speed.Y;
            }
            else
            {
                position1.Y = position2.Y - 690;
            }

            if (position2.Y < 690)
            {
                position2.Y += speed.Y;
            }
            else
            {
                position2.Y = position1.Y - 690;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position1, srcRect, Color.White);
            spriteBatch.Draw(tex, position2, srcRect, Color.White);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
