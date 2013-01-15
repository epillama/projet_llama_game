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

namespace Game
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        Afficheur affiche;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.graphics.PreferredBackBufferWidth = Ressources.fondMenu.Width;
            this.graphics.PreferredBackBufferHeight = Ressources.fondMenu.Height;
            this.graphics.IsFullScreen = true;
            graphics.ApplyChanges();

        }

        protected override void LoadContent()
        {
            Ressources.LoadContent(Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            affiche = new Afficheur();

        }

        protected override void UnloadContent()
        {
            //ca sert pas a grand chose!
        }

        protected override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            if (MainMenu.CurrentGameState == MainMenu.GameState.MainMenu)
                this.IsMouseVisible = true;
            if (MainMenu.IsQuit)
            {
                System.Threading.Thread.Sleep(3000);
                this.Exit();
            }
            if (MainMenu.CurrentGameState == MainMenu.GameState.Playing)
                this.IsMouseVisible = false;
            affiche.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();    
            affiche.Draw_affiche(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}