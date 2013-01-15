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
        MainMenu affichemenu;


        // constructeur

        public Afficheur()
        {
            localplayer = new Player();
            affichemenu = new MainMenu();
        }

        // methode


        // update & draw


        public void Update()
        {
            // update des autres classes
            
            affichemenu.Update();
            localplayer.update();
        }

        public void Draw_affiche(SpriteBatch spriteBatch)
        {
            
            affichemenu.Draw_Menu(spriteBatch);
            localplayer.draw_player(spriteBatch);
        }


    }
}
