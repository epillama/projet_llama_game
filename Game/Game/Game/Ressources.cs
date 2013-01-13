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

        public static void LoadContent(ContentManager Content)
        {
            joueur = Content.Load<Texture2D>("Sprite/Lama2");

            // menu
            jouer = Content.Load<Texture2D>("Sprite/bouton_jouer2");
        }
    }
}
