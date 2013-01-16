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
    public abstract partial class @new : DrawableGameComponent
    {
        #region Fields and Properties
        List<GameComponent> childComponents;
        public List<GameComponent> Components
        {
            get { return childComponents; }
        }
        @new tag;
public @new Tag
        {
            get { return tag; }
        }
        protected GameStateManager StateManager;
        #endregion
        #region Constructor Region
        public @new(Game game, GameStateManager manager)
            : base(game)
        {
            StateManager = manager;
            childComponents = new List<GameComponent>();
            tag = this;
        }
    }
}
