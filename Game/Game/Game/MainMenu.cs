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
    class MainMenu
    {
        //Fields
        public enum GameState
        {
            MainMenu,
            Options,
            Playing,
            Pause,
            Quit,
        }

        static public GameState CurrentGameState = GameState.MainMenu;
        Button ButtonPlay;
        Button ButtonOptions;
        Button ButtonQuit;
        int menuPosition = 0;
        static public bool IsQuit = false;
        bool changeselection = false;

        //Constructeurs

        //Methods
        public void Load_Content()
        {

        }

        //Update & Draw
        public void Update()
        {
            MouseState mouse = Mouse.GetState();

            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    if (Keyboard.GetState().IsKeyDown(Keys.Down) && !changeselection)
                    {
                        menuPosition++;
                        changeselection = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Up) && !changeselection)
                    {
                        menuPosition--;
                        changeselection = true;
                    }
                    if (Keyboard.GetState().IsKeyUp(Keys.Down) && Keyboard.GetState().IsKeyUp(Keys.Up))
                        changeselection = false;
                    //cas haut bas
                    if (menuPosition == -1)
                        menuPosition = 2;
                    if (menuPosition == 3)
                        menuPosition = 0;
                    //selection
                    if (Keyboard.GetState().IsKeyDown(Keys.Space) && menuPosition == 0)
                        CurrentGameState = GameState.Playing;
                    if (Keyboard.GetState().IsKeyDown(Keys.Space) && menuPosition == 1)
                        CurrentGameState = GameState.Options;
                    if (Keyboard.GetState().IsKeyDown(Keys.Space) && menuPosition == 2)
                        CurrentGameState = GameState.Quit;
                    break;

                case GameState.Playing:
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                        CurrentGameState = GameState.MainMenu;
                    break;

                case GameState.Options:
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                        CurrentGameState = GameState.MainMenu;
                    break;

                case GameState.Pause:
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                        CurrentGameState = GameState.MainMenu;
                    break;

                case GameState.Quit:
                    IsQuit = true;
                    break;

            }
        }

        public void Draw_Menu(SpriteBatch spriteBatch)
        {
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    spriteBatch.Draw(Ressources.fondMenu, Vector2.Zero, Color.White);
                    spriteBatch.Draw(Ressources.jouer, new Vector2(50, 400), Color.White);
                    spriteBatch.Draw(Ressources.options, new Vector2(50, 450), Color.White);
                    spriteBatch.Draw(Ressources.quit, new Vector2(50, 500), Color.White);
                    //Surbrillance
                    if (menuPosition == 0)
                        spriteBatch.Draw(Ressources.jouer, new Vector2(50, 400), Color.Black);
                    if (menuPosition == 1)
                        spriteBatch.Draw(Ressources.options, new Vector2(50, 450), Color.Black);
                    if (menuPosition == 2)
                        spriteBatch.Draw(Ressources.quit, new Vector2(50, 500), Color.Black);

                    break;

                case GameState.Playing:

                    break;

                case GameState.Pause:

                    break;

                case GameState.Options:

                    break;

                case GameState.Quit:

                    break;
            }
        }

    }
}
