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
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        switch (menuPosition)
                        {
                            case 0:
                                CurrentGameState = GameState.Playing;
                                MediaPlayer.Stop();
                                MediaPlayer.Play(Ressources.songtest);
                                break;
                            case 1:
                                CurrentGameState = GameState.Options;
                                Ressources.effect.Play();
                                break;
                            case 2:
                                CurrentGameState = GameState.Quit;
                                Ressources.effect.Play();
                                break;
                        }
                    }
                    break;

                case GameState.Playing:
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    {
                        MediaPlayer.Stop();
                        Ressources.effect.Play();
                        MediaPlayer.Play(Ressources.song);
                        CurrentGameState = GameState.MainMenu;
                        
                    }
                    break;

                case GameState.Options:
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    {
                        CurrentGameState = GameState.MainMenu;
                        Ressources.effect.Play();
                    }
                    break;

                case GameState.Pause:
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    {
                        CurrentGameState = GameState.MainMenu;
                        Ressources.effect.Play();
                    }
                    break;

                case GameState.Quit:
                    {
                        MediaPlayer.Stop();
                        IsQuit = true;
                        Ressources.quiteffect.Play();
                    }
                    break;

            }
        }

        public void Draw_Menu(SpriteBatch spriteBatch)
        {
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    spriteBatch.Draw(Ressources.fondMenu, Vector2.Zero, Color.White);
                    spriteBatch.Draw(Ressources.jouer1, new Vector2(50, 400), Color.White);
                    spriteBatch.Draw(Ressources.options1, new Vector2(50, 475), Color.White);
                    spriteBatch.Draw(Ressources.quit1, new Vector2(50, 550), Color.White);
                    //Surbrillance
                    if (menuPosition == 0)
                        spriteBatch.Draw(Ressources.jouer2, new Vector2(50, 400), Color.White);
                    if (menuPosition == 1)
                        spriteBatch.Draw(Ressources.options2, new Vector2(50, 475), Color.White);
                    if (menuPosition == 2)
                        spriteBatch.Draw(Ressources.quit2, new Vector2(50, 550), Color.White);

                    break;

                case GameState.Playing:
                    spriteBatch.Draw(Ressources.grass, Player.Map, Color.White);
                    break;

                case GameState.Pause:

                    break;

                case GameState.Options:
                    spriteBatch.Draw(Ressources.fondOptions, Vector2.Zero, Color.White);
                    spriteBatch.Draw(Ressources.marchearret, new Rectangle(571, 352, 200, 76), new Rectangle(0, 0, 200, 76), Color.White);// premier rectangle : emplacement pour le fullscreen deuxieme : Marche
                    spriteBatch.Draw(Ressources.marchearret, new Rectangle(569, 468, 200, 76), new Rectangle(0, 76, 200, 75), Color.White);// premier rectangle : emplacement pour le Volume deuxieme : arret
                    break;

                case GameState.Quit:
                    spriteBatch.Draw(Ressources.imageQuit, Vector2.Zero, Color.White);
                    
                    break;
            }
        }

    }
}
