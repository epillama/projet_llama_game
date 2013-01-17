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
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
    };

    class Player : Scroll
    {
        // champs

        public static Rectangle player_hitbox;
        Direction direction;
        int frameline;
        int framecolumn;
        SpriteEffects Mirror;
        int animationspeed;
        int timer;
        
        public static int speed;

        //constructeur

        public Player()
        {
            player_hitbox = centreecran; // llama centré
            this.frameline = 0;
            this.framecolumn = 0;
            this.Mirror = SpriteEffects.None;
            this.animationspeed = 10;
            speed = 4;
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

        public void update_Player()
        {
            if (MainMenu.CurrentGameState == MainMenu.GameState.Playing)
            {
                if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickRight) || Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    if (borddroit)
                    {
                        for (int i = 1; i <= speed && player_hitbox.X + player_hitbox.Width <= largeurecran; i++)
                        {
                            player_hitbox.X += 1;
                        }
                    }
                    if (bordgauche)
                    {
                        for (int i = 1; i <= speed && !(player_hitbox.X == centreecran.X); i++)
                        {
                            player_hitbox.X += 1;
                        }
                    }

                    this.direction = Direction.Right;
                    this.frameline = 1;
                    this.Animate();

                }
                else if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickLeft) || Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    if (bordgauche)
                    {
                        for (int i = 1; i <= speed && player_hitbox.X > 0; i++)
                        {
                            player_hitbox.X -= 1;
                        }
                    }
                    if (borddroit)
                    {
                        for (int i = 1; i <= speed && !(player_hitbox.X == centreecran.X); i++)
                        {
                            player_hitbox.X -= 1;
                        }
                    }
                    this.frameline = 1;
                    this.direction = Direction.Left;
                    this.Animate();
                }
                else if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickUp) || Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    if (bordhaut)
                    {
                        for (int i = 1; i <= speed && player_hitbox.Y > 0; i++)
                        {
                            player_hitbox.Y -= 1;
                        }
                    }
                    if (bordbas)
                    {
                        for (int i = 1; i <= speed && !(player_hitbox.Y == centreecran.Y); i++)
                        {
                            player_hitbox.Y -= 1;
                        }
                    }
                    this.frameline = 5;
                    this.direction = Direction.Up;
                    this.Animate();

                }
                else if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickDown) || Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    if (bordbas)
                    {
                        for (int i = 1; i <= speed && player_hitbox.Y + player_hitbox.Height < hauteurecran; i++)
                        {
                            player_hitbox.Y += 1;
                        }
                    }
                    if (bordhaut)
                    {
                        for (int i = 1; i <= speed && !(player_hitbox.Y == centreecran.Y); i++)
                        {
                            player_hitbox.Y += 1;
                        }
                    }
                    this.frameline = 3;
                    this.direction = Direction.Down;
                    this.Animate();
                }

                if (Keyboard.GetState().IsKeyUp(Keys.Up) && Keyboard.GetState().IsKeyUp(Keys.Down) && Keyboard.GetState().IsKeyUp(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Right))
                {
                    if (direction == Direction.Left || direction == Direction.Right)
                        this.frameline = 0;
                    else if (direction == Direction.Down)
                        this.frameline = 2;
                    else if (direction == Direction.Up)
                        this.frameline = 4;
                    this.Animate();
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
        }

        public void draw_player(SpriteBatch spriteBatch)
        {
            if (MainMenu.CurrentGameState == MainMenu.GameState.Playing)
                spriteBatch.Draw(Ressources.joueur, player_hitbox, new Rectangle(this.framecolumn * 56, this.frameline * 58, 56, 58), Color.White, 0f, new Vector2(0, 0), this.Mirror, 0f);
        }
    }
}
