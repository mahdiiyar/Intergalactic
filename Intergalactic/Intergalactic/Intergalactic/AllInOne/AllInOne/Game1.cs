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
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //Declare all scenes here....
        private StartScene startScene;
        private HelpScene helpScene;
        private ActionScene actionScene;
        private HowToPlayScene howToPlayScene;
        Texture2D background;
        Rectangle mainFrame;
        //private SoundEffect laserSound;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here           

            Window.Title = "Intergalactic";
            graphics.PreferredBackBufferHeight = 700;
            graphics.PreferredBackBufferWidth = 400;
            graphics.ApplyChanges();

            Shared.stage = new Vector2(graphics.PreferredBackBufferWidth,
                graphics.PreferredBackBufferHeight);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            // Sound Effects
            SoundEffect laserSound = Content.Load<SoundEffect>("SoundEffects/Laser");

            // Load background image
            background = Content.Load<Texture2D>("Images/space");
            mainFrame = new Rectangle(0, 0, graphics.PreferredBackBufferWidth,
                graphics.PreferredBackBufferHeight);

            // background scrolling
            //Vector2 stage = new Vector2(graphics.PreferredBackBufferWidth,
            //    graphics.PreferredBackBufferHeight);
            //Texture2D tex = Content.Load<Texture2D>("Images/space");
            //Rectangle r = new Rectangle(0, 300, tex.Width, 777);

            //Vector2 pos = new Vector2(0, 0);
            //ScrollingBackground sb = new ScrollingBackground(this,
            //    spriteBatch, tex, r, pos, new Vector2(1, 0));

            Vector2 stage = new Vector2(graphics.PreferredBackBufferWidth,
                graphics.PreferredBackBufferHeight);
            Texture2D tex = Content.Load<Texture2D>("Images/space");
            Rectangle r = new Rectangle(0, 0, 400, 700);

            Vector2 pos = new Vector2(0, 0);
            ScrollingBackground sb = new ScrollingBackground(this,
                spriteBatch, tex, r, pos, new Vector2(0, 4));

            this.Components.Add(sb);

            // create all scenes here and add to Components list.
            // make only startScene active
            startScene = new StartScene(this, spriteBatch);
            this.Components.Add(startScene);

            helpScene = new HelpScene(this, spriteBatch);
            this.Components.Add(helpScene);

            actionScene = new ActionScene(this, spriteBatch, laserSound);
            this.Components.Add(actionScene);

            howToPlayScene = new HowToPlayScene(this, spriteBatch);
            this.Components.Add(howToPlayScene);

            
            startScene.show();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        private void hideAll()
        {
            GameScene gs = null;
            foreach (GameComponent item in Components)
            {
                if (item is GameScene)
                {
                    gs = (GameScene)item;
                    gs.hide();
                }
            }
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            int selectedIndex = 0;
            KeyboardState ks = Keyboard.GetState();
            if (startScene.Enabled)
            {
                selectedIndex = startScene.Menu.SelectedIndex;
                if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAll();
                    actionScene.show();
                }
                else if (selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAll();
                    helpScene.show();
                }
                else if (selectedIndex == 3 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAll();
                    howToPlayScene.show();
                }
                //add the others here
                else if (selectedIndex == 5 && ks.IsKeyDown(Keys.Enter))
                {
                    Exit();
                }
            }

            if (helpScene.Enabled || actionScene.Enabled || howToPlayScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    hideAll();
                    startScene.show();
                }
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(background, mainFrame, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
