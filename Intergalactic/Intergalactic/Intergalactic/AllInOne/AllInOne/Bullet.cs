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
    public class Bullet : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 speed;
        private SoundEffect laserSound;

        //private int shootPos = 192;

        public Bullet(Game game, SpriteBatch spriteBatch,
            Texture2D tex, SoundEffect laserSound)
            : base(game)
        {
            // TODO: Construct any child components here
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.laserSound = laserSound;

            //position = new Vector2(Shared.stage.X / 2 - tex.Width / 2,
            //    Shared.stage.Y - tex.Height - 80);

            //position = new Vector2(shootPos + Shared.stage.X / 2 - 9,
                //Shared.stage.Y - tex.Height - 80);
            position.X = 192;
            speed = new Vector2(4, 0);

            this.Visible = false;

            SoundEffect.MasterVolume = 0.01f;
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

            if (ks.IsKeyDown(Keys.Left))
            {
                if (position.X < 38)
                {
                    position.X = 38;
                }
                position.X -= 4;
            }
            if (ks.IsKeyDown(Keys.Right))
            {
                if (position.X > 345)
                {
                    position.X = 345;
                }
                position.X += 4;
            }


            if (ks.IsKeyDown(Keys.Space))
            {                
                this.Visible = true;
                
                // LASER SOUND EFFECT
                //laserSound.Play();  
            }



            if (this.Visible == true)
            {
                // moves bullet up
                position.Y -= 45;
                //position.X = shootPos;

                // if bullet goes off the screen
                if (position.Y < -10)
                {
                    this.Visible = false;
                    position.Y = Shared.stage.Y - tex.Height - 80;
                }
            }

            //position = new Vector2(shootPos + Shared.stage.X / 2 - 9,
               // Shared.stage.Y - tex.Height - 80);

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
