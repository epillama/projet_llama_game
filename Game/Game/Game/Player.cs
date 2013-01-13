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
        bool immobile = true;
        //constructeur

        public Player()
        {
            player_hitbox = new Rectangle(0, 0, 78, 58);
        }

        // methodes

        // update & draw

        public void update(MouseState mouse, KeyboardState clavier)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && immobile)
            {
                player_hitbox.X = player_hitbox.X + 8;
                immobile = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && immobile)
            {
                player_hitbox.X = player_hitbox.X - 8;
                immobile = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && immobile)
            {
                player_hitbox.Y = player_hitbox.Y - 8;
                immobile = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && immobile)
            {
                player_hitbox.Y = player_hitbox.Y + 8;
                immobile = false;
            }
            immobile = true;
        }

        public void draw_player(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Ressources.joueur, player_hitbox, new Rectangle(0, 0, 78, 58), Color.White); 
        }
    }
}
