using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Game
{


    class Enemy
    {

        // champs

        public static Rectangle enemy_hitbox;
        Direction direction;
        int frameline;
        int framecolumn;
        SpriteEffects Mirror;
        public static Rectangle Map;
        int animationspeed;
        int timer;
        int speed_e;

        //constructeur

        public Enemy()
        {
            enemy_hitbox = new Rectangle(100, 100, 56, 58);
            this.frameline = 0;
            this.framecolumn = 0;
            this.Mirror = SpriteEffects.None;
            this.animationspeed = 10;
            this.speed_e = 2;
            Map = new Rectangle(0, 0, Ressources.grass.Width, Ressources.grass.Height);
        }

        // methodes

        public void Animate()
        {
            this.timer++;
            if (this.timer == this.animationspeed)
            {
                this.framecolumn++;
                if (this.framecolumn > 3)
                {
                    this.framecolumn = 0;
                }
                this.timer = 0;
            }
        }

        // update & draw

        public void update()
        {
            if (MainMenu.CurrentGameState == MainMenu.GameState.Playing)
            {
                if (enemy_hitbox.X < Player.player_hitbox.X)
                {

                    enemy_hitbox.X += speed_e;
                    this.direction = Direction.Right;
                    this.frameline = 1;
                    this.Animate();


                }
                
                else

                if (enemy_hitbox.X > Player.player_hitbox.X)
                {

                    enemy_hitbox.X -= speed_e;
                    this.frameline = 1;
                    this.direction = Direction.Left;
                    this.Animate();

                }


                else
                {
                    if (enemy_hitbox.Y > Player.player_hitbox.Y)
                    {
                        enemy_hitbox.Y -= speed_e - 1;
                        this.frameline = 5;
                        this.direction = Direction.Down;
                        this.Animate();


                    }
                    else

                    if (enemy_hitbox.Y < Player.player_hitbox.Y)
                    {
                        enemy_hitbox.Y += speed_e - 1;
                        this.frameline = 3;
                        this.direction = Direction.Up;
                        this.Animate();
                    }

                }


            }
            switch (this.direction)
            {
                case Direction.Up:
                    this.Mirror = SpriteEffects.None;
                    break;
                case Direction.Down:
                    this.Mirror = SpriteEffects.None;
                    break;
                case Direction.Left:
                    this.Mirror = SpriteEffects.None;
                    break;
                case Direction.Right:
                    this.Mirror = SpriteEffects.FlipHorizontally;
                    break;
            }
        }
        public void draw_enemy(SpriteBatch spriteBatch)
        {
            if (MainMenu.CurrentGameState == MainMenu.GameState.Playing)
                spriteBatch.Draw(Ressources.joueur, enemy_hitbox, new Rectangle(this.framecolumn * 56, this.frameline * 58, 56, 58), Color.White, 0f, new Vector2(0, 0), this.Mirror, 0f);
        }
    }
}







