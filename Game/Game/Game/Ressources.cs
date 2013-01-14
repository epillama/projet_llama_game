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
        public static Texture2D jouer1;
        public static Texture2D jouer2;
        public static Texture2D options1;
        public static Texture2D options2;
        public static Texture2D quit1;
        public static Texture2D quit2;
        //Textures des bouttons du menu.
        public static Texture2D fondMenu;
        public static Texture2D imageQuit;

        public static void LoadContent(ContentManager Content)
        {
            //personnage
            joueur = Content.Load<Texture2D>("Sprite/Lama2");
            // menu
            jouer1 = Content.Load<Texture2D>("Sprite/Menu/jouer1");
            jouer2 = Content.Load<Texture2D>("Sprite/Menu/jouer2");
            options1 = Content.Load<Texture2D>("Sprite/Menu/Options1");
            options2 = Content.Load<Texture2D>("Sprite/Menu/Options2");
            quit1 = Content.Load<Texture2D>("Sprite/Menu/Quitter1");
            quit2 = Content.Load<Texture2D>("Sprite/Menu/Quitter2");
            fondMenu = Content.Load<Texture2D>("Sprite/fond");//ajouter un fond
            imageQuit = Content.Load<Texture2D>("Sprite/End");
            //Map
        }
    }
}
