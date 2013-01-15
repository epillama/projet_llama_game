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
    class Player
    {
        // champs

        public static Rectangle player_hitbox;
        public static Rectangle Map;
        bool immobile = true;
        //constructeur

        public Player()
        {
            player_hitbox = new Rectangle(0, 0, 78, 58);
            Map = new Rectangle(0, 0, Ressources.grass.Width, Ressources.grass.Height);
        }

        // methodes

        // update & draw

        public void update()
        {
            if (MainMenu.CurrentGameState == MainMenu.GameState.Playing)
            {
                if ((GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadRight) || Keyboard.GetState().IsKeyDown(Keys.Right)) && immobile && player_hitbox.X < Ressources.grass.Width)
                {
                    if (player_hitbox.X < Ressources.fondMenu.Width / 2 - player_hitbox.Width / 2)
                        player_hitbox.X += 8;
                    else
                        Map.X -= 8;

                    immobile = false;

                }
                if ((GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadLeft) || Keyboard.GetState().IsKeyDown(Keys.Left)) && immobile && player_hitbox.X > 0)
                {

                    player_hitbox.X = player_hitbox.X - 8;

                    immobile = false;
                }
                if ((GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadUp) || Keyboard.GetState().IsKeyDown(Keys.Up)) && immobile && player_hitbox.Y > 0)
                {
                    player_hitbox.Y = player_hitbox.Y - 8;
                    immobile = false;

                }
                if ((GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadDown) || Keyboard.GetState().IsKeyDown(Keys.Down)) && immobile && player_hitbox.Y < Ressources.grass.Height)
                {
                    player_hitbox.Y = player_hitbox.Y + 8;
                    immobile = false;
                }
                immobile = true;
            }
        }

        public void draw_player(SpriteBatch spriteBatch)
        {
            if (MainMenu.CurrentGameState == MainMenu.GameState.Playing)
                spriteBatch.Draw(Ressources.joueur, player_hitbox, new Rectangle(0, 0, 78, 58), Color.White);
        }
    }
}
