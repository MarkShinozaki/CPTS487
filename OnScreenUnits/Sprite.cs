

namespace EGGS.OnScreenUnits
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;
    using EGGS.OnScreenUnits.MovementDesign;
  

    internal abstract class Sprite
    {
        
        private bool isRemoved = false;
       

        public Sprite(Texture2D texture, MovementPattern movement)
        {
            Texture = texture;
           
            this.Movement = movement;
            
        }

        public Texture2D Texture { get; set; }
        public MovementPattern Movement { get; set; }


        public virtual void Update(GameTime gametime, List<Sprite> sprites)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            // Assuming you want to draw the sprite with its position, rotation, and origin,
            // but without specifying a destination rectangle (thus, using the texture's size),
            // and with a scale of 1 and no sprite effects or layer depth.
            spriteBatch.Draw(this.Texture, this.Movement.Position, null, this.Movement.Rotation, this.Movement.Origin, 1);


        }




























    }
}
