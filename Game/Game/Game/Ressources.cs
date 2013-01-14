using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    class Ressources
    {
        //Cette classe va gerer tout les load de ressources (ca fait plus propre)

        public static Texture2D joueur;
        //texture du lama
        public static Texture2D jouer;
        public static Texture2D options;
        public static Texture2D quit;
        //Textures des bouttons du menu.
        public static Texture2D fondMenu;

        public static void LoadContent(ContentManager Content)
        {
            //personnage
            joueur = Content.Load<Texture2D>("Sprite/Lama2");
            // menu
            jouer = Content.Load<Texture2D>("Sprite/Menu/Jouer");
            options = Content.Load<Texture2D>("Sprite/Menu/Options");
            quit = Content.Load<Texture2D>("Sprite/Menu/Quit");
            fondMenu = Content.Load<Texture2D>("Sprite/fond");//ajouter un fond
            //Map
        }
    }
}
