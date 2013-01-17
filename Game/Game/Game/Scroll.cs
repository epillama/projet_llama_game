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
    class Scroll
    {
        static public Rectangle mapaffiche;
        static public int hauteurecran;
        static public int largeurecran;
        static public int hauteurmap;
        static public int largeurmap;
        static public bool bordhaut;
        static public bool bordbas;
        static public bool bordgauche;
        static public bool borddroit;
        static public bool centreX;
        static public bool centreY;
        static public Rectangle rectangleecran;
        static public Rectangle centreecran;
        int speedplayer;

        public Scroll()
        {
            hauteurecran = Ressources.fondMenu.Height;
            largeurecran = Ressources.fondMenu.Width;
            hauteurmap = Ressources.grass.Height;
            largeurmap = Ressources.grass.Width;
            centreecran = new Rectangle((Ressources.fondMenu.Width - 56) / 2, (Ressources.fondMenu.Height - 58) / 2, 56, 58);
            bordhaut = false;
            bordbas = false;
            bordgauche = false;
            borddroit = false;
            centreX = true;
            centreY = true;
            speedplayer = Player.speed;
            rectangleecran = new Rectangle(0, 0, Ressources.fondMenu.Width, Ressources.fondMenu.Height);
            mapaffiche = new Rectangle(0, 0, Ressources.fondMenu.Width, Ressources.fondMenu.Height);
        }

        public void testbords()
        {
            if (mapaffiche.X <= 0)
                bordgauche = true;
            else
                bordgauche = false;
            if (mapaffiche.Y <= 0)
                bordhaut = true;
            else
                bordhaut = false;
            if (mapaffiche.X + largeurecran > largeurmap)
                borddroit = true;
            else
                borddroit = false;
            if (mapaffiche.Y + hauteurecran > hauteurmap)
                bordbas = true;
            else
                bordbas = false;
            if (Player.player_hitbox.X == centreecran.X)
                centreX = true;
            else
                centreX = false;
            if (Player.player_hitbox.Y == centreecran.Y)
                centreY = true;
            else
                centreY = false;
        }

        public void update_scroll()
        {
            if (MainMenu.CurrentGameState == MainMenu.GameState.Playing)
            {
                if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickRight) || Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    if (!borddroit && !bordgauche || centreX)
                    {
                        for (int i = 1; i <= speedplayer && !borddroit; i++)
                        {
                            mapaffiche.X += 1;
                            Enemy.enemy_hitbox.X -= 1;
                        }
                    }
                }
                else if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickLeft) || Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    if (!bordgauche && !borddroit || centreX)
                    {
                        for (int i = 1; i <= speedplayer && !bordgauche; i++)
                        {
                            mapaffiche.X -= 1;
                            Enemy.enemy_hitbox.X += 1;
                        }
                    }
                }
                else if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickUp) || Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    if (!bordhaut && !bordbas || centreY)
                    {
                        for (int i = 1; i <= speedplayer && !bordhaut; i++)
                        {
                            mapaffiche.Y -= 1;
                            Enemy.enemy_hitbox.Y += 1;
                        }
                    }
                }
                else if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickDown) || Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    if (!bordhaut && !bordbas || centreY)
                    {
                        for (int i = 1; i <= speedplayer && !bordbas; i++)
                        {
                            mapaffiche.Y += 1;
                            Enemy.enemy_hitbox.Y -= 1;
                        }
                    }
                }
            }

        }

        public void draw_scroll(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Ressources.grass, new Rectangle(0, 0, Ressources.fondMenu.Width, Ressources.fondMenu.Height), mapaffiche, Color.White);
        }
    }
}
