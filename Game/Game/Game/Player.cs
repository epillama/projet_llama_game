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

    class Player
    {
        // champs

        public static Rectangle player_hitbox;
        Direction direction;
        int frameline;
        int framecolumn;
        SpriteEffects Mirror;
        public static Rectangle Map;
        int animationspeed;
        int timer;
        int speed;

        //constructeur

        public Player()
        {
            player_hitbox = new Rectangle(0, 0, 56, 58);
            this.frameline = 0;
            this.framecolumn = 0;
            this.Mirror = SpriteEffects.None;
            this.animationspeed = 10;
            this.speed = 4;
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
                if ((GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadRight) || Keyboard.GetState().IsKeyDown(Keys.Right)) && player_hitbox.X < Ressources.grass.Width)
                {
                    player_hitbox.X += speed;
                    this.direction = Direction.Right;
                    this.Animate();

                }
                else if ((GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadLeft) || Keyboard.GetState().IsKeyDown(Keys.Left)) && player_hitbox.X > 0)
                {
                    player_hitbox.X -= speed;
                    this.direction = Direction.Left;
                    this.Animate();
                }
                else if ((GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadUp) || Keyboard.GetState().IsKeyDown(Keys.Up)) && player_hitbox.Y > 0)
                {
                    player_hitbox.Y -= speed;
                    this.direction = Direction.Up;
                    this.Animate();

                }
                else if ((GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadDown) || Keyboard.GetState().IsKeyDown(Keys.Down)) && player_hitbox.Y < Ressources.grass.Height)
                {
                    player_hitbox.Y += speed;
                    this.direction = Direction.Down;
                    this.Animate();
                }
                if (Keyboard.GetState().IsKeyUp(Keys.Up) && Keyboard.GetState().IsKeyUp(Keys.Down) && Keyboard.GetState().IsKeyUp(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Right))
                {
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
