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
    public class ActionScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Bat bat;
        private Bullet bullet;
        private SoundEffect laserSound;


        public ActionScene(Game game, SpriteBatch spriteBatch, SoundEffect laserSound)
            : base(game)
        {
            this.laserSound = laserSound;
            // TODO: Construct any child components here
            this.spriteBatch = spriteBatch;
            bat = new Bat(game, spriteBatch, game.Content.Load<Texture2D>("Images/SpaceShip"));
            this.Components.Add(bat);
            bullet = new Bullet(game, spriteBatch, game.Content.Load<Texture2D>("Images/redLaserRay"), laserSound);
            this.Components.Add(bullet);
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
            
            base.Update(gameTime);
        }
    }
}
