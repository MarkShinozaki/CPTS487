

namespace EGGS.OnScreenUnits.CollisionDectection
{
    using System.Collections.Generic;
    internal class CollisionCheck : Command
    {
        private readonly FigureSprite focusSprite;
        private readonly List<FigureSprite> sprites;

        public CollisionCheck(FigureSprite focusSprite, List<FigureSprite> sprites)
        {
            this.focusSprite = focusSprite;
            this.sprites = sprites;
        }

        public void Execute() => this.focusSprite.CheckForCollision(this.sprites);
    }
}
