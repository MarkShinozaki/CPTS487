

namespace EGGS.OnScreenUnits.CollisionDectection
{
    using System.Collections.Generic;
    using EGGS.OnScreenUnits;
    using Microsoft.Xna.Framework;

    internal class UpdateCommand
    {
        private readonly FigureSprite focusSprite;
        private readonly GameTime gameTime;
        private readonly List<FigureSprite> sprites;

        public UpdateCommand(FigureSprite focusSprite, GameTime time, List<FigureSprite> sprites)
        {
            this.focusSprite = focusSprite;
            this.gameTime = time;
            this.sprites = sprites;
        }

        public void Execute() => this.focusSprite.Update(this.gameTime, this.sprites);
    }
}
