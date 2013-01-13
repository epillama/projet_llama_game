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
        Player Localplayer;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameState CurrentGameState = GameState.MainMenu;

        enum GameState
        {
            MainMenu,
            Options,
            Playing,
            Pause,
        }

        //screen adjusts
        int ScreenWidth = 800, screenHeight = 600;

        Button ButtonPlay;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            affiche = new Afficheur();
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

        }

        protected override void LoadContent()
        {
            Ressources.LoadContent(Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            affiche = new Afficheur();

            IsMouseVisible = true;
            ButtonPlay = new Button(Content.Load<Texture2D>("Sprite/bouton_jouer2"), graphics.GraphicsDevice);
            ButtonPlay.SetPosition(new Vector2(350, 300));   
        }

        protected override void UnloadContent()
        {
            //ca sert pas a grand chose!
        }

        protected override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            affiche.Update(Mouse.GetState(), Keyboard.GetState());

            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    if (ButtonPlay.isClicked == true) CurrentGameState = GameState.Playing;
                    break;

                case GameState.Playing:

                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

                switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    spriteBatch.Draw(Content.Load<Texture2D>("Sprite/fond"), new Rectangle(0, 0, ScreenWidth, screenHeight), Color.White);
                    ButtonPlay.Draw(spriteBatch);
                    break;

                case GameState.Playing:
                    affiche.Draw_affiche(spriteBatch);
                    break;
            }
                spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}