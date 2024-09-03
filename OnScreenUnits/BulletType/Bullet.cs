
namespace EGGS.OnScreenUnits.BulletType
{

    using EGGS.MovementDesign;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework;
    using System;


    class Bullet : Entity
    {
        private Movement currentMove;
        private Double movementStartTime;
        public Vector2 velocity;
        public Vector2 origin = Vector2.Zero;
        public bool isVisible;
        private Movement move;
        private BulletMovement moves;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newTexture"></param>
        /// <param name="newPosition"></param>
        /// <param name="newVelocity"></param>
        /// <param name="visibility"></param>
        /// <param name="newMoves"></param>
        public Bullet(Texture2D newTexture, Vector2 newPosition, Vector2 newVelocity, bool visibility, BulletMovement newMoves)
        {
            texture = newTexture;
            isVisible = visibility;
            position = newPosition;
            velocity = newVelocity;
            moves = newMoves;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            
            if (moves == null)
            {
                position += velocity;
            }
            else if (currentMove == null)
            {
                currentMove = moves.GetMovement(); // Change 
                movementStartTime = gameTime.TotalGameTime.TotalSeconds;
            }
            else if (currentMove.seconds <= (gameTime.TotalGameTime.TotalSeconds - movementStartTime))
            {
                moves.popMovement(); // Change 
                currentMove = null;
            }
            else
            {
                position = currentMove.getNewPosition(position, velocity); // Change
            }

            if (Vector2.Distance(position, origin) > 2000)
                isVisible = false;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0f, origin, 0.2f, SpriteEffects.None, 1);
        }
    }
}
