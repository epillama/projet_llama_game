using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

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
        public static Texture2D grass;
        //textures pour les options
        public static Texture2D fondOptions;
        public static Texture2D volumeOptions;
        public static Texture2D fullscreenOptions;
        public static Texture2D marcheOptions;
        public static Texture2D arretOptions;
        public static Texture2D retourOptions;
        public static Texture2D marchearret;
        // Son
        public static Song song;
        public static SoundEffect effect;
        public static SoundEffect quiteffect;
        public static Song songtest;

        public static void LoadContent(ContentManager Content)
        {
            //personnage
            joueur = Content.Load<Texture2D>("Sprite/Llama/llama");
            // menu
            jouer1 = Content.Load<Texture2D>("Sprite/Menu/jouer1");
            jouer2 = Content.Load<Texture2D>("Sprite/Menu/jouer2");
            options1 = Content.Load<Texture2D>("Sprite/Menu/Options1");
            options2 = Content.Load<Texture2D>("Sprite/Menu/Options2");
            quit1 = Content.Load<Texture2D>("Sprite/Menu/Quitter1");
            quit2 = Content.Load<Texture2D>("Sprite/Menu/Quitter2");
            fondMenu = Content.Load<Texture2D>("Sprite/Menu/fond");//ajouter un fond
            imageQuit = Content.Load<Texture2D>("Sprite/End");

            //options
            fondOptions = Content.Load<Texture2D>("Sprite/Background/OptionsBackground");
            marchearret = Content.Load<Texture2D>("Sprite/elementsOptions/marchearret");
            //Map
            grass = Content.Load<Texture2D>("Sprite/Background/grass");
            //Son
            // Son
            song = Content.Load<Song>("Sons/menusong");
            effect = Content.Load<SoundEffect>("Sons/effectmenu");
            quiteffect = Content.Load<SoundEffect>("Sons/quiteffect");
            songtest = Content.Load<Song>("Sons/test");
        }
    }
}
