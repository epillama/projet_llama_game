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
        Enemy enemy;
        MainMenu affichemenu;
        Scroll scrolling;

        // constructeur

        public Afficheur()
        {
            localplayer = new Player();
            enemy = new Enemy();
            affichemenu = new MainMenu();
            scrolling = new Scroll();
        }

        // methode


        // update & draw


        public void Update()
        {
            // update des autres classes
            affichemenu.Update();
            scrolling.testbords();
            scrolling.update_scroll();
            localplayer.update_Player();
            enemy.update();
        }

        public void Draw_affiche(SpriteBatch spriteBatch)
        {
            
            affichemenu.Draw_Menu(spriteBatch);
            if (Player.player_hitbox.Y < Enemy.enemy_hitbox.Y)
            {
                localplayer.draw_player(spriteBatch);
                enemy.draw_enemy(spriteBatch);
            }
            else
            {
                enemy.draw_enemy(spriteBatch);
                localplayer.draw_player(spriteBatch);
            }
        }


    }
}
