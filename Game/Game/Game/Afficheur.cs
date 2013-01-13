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
    public class Afficheur
    {

        // champs

        Player localplayer;
 

        // constructeur

        public Afficheur()
        {
           localplayer = new Player();
        }

        // methode

      
        // update & draw


        public void Update(MouseState souris, KeyboardState clavier)
        {
            // update des autres classes
            localplayer.update(souris, clavier);
        }

        public void Draw_affiche(SpriteBatch spriteBatch)
        {
            localplayer.draw_player(spriteBatch);
        }


    }
}
