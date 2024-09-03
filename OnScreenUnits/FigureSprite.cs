

namespace EGGS.OnScreenUnits
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
  
    using System.Collections.Generic;
  
    using EGGS.OnScreenUnits.MovementDesign;
  

    internal abstract class FigureSprite
    {
        
        private bool isRemoved = false;
       

        public FigureSprite(Texture2D texture, MovementPattern movement)
        {
            Texture = texture;
           
            this.Movement = movement;
            
        }

        public Texture2D Texture { get; set; }
        public MovementPattern Movement { get; set; }


        public virtual void Update(GameTime gametime, List<FigureSprite> sprites)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            // Assuming you want to draw the sprite with its position, rotation, and origin,
            // but without specifying a destination rectangle (thus, using the texture's size),
            // and with a scale of 1 and no sprite effects or layer depth.
            Vector2 origin = new Vector2(Texture.Width / 2f, Texture.Height / 2f); // Center origin for rotation
            float scale = 0.5f;
            
            spriteBatch.Draw(
                texture: Texture,
                position: this.Movement.Position,
                sourceRectangle: null, // Use the entire texture
                color: Color.White, // No tint
                rotation: MathHelper.ToRadians(this.Movement.Rotation), // Convert degrees to radians if needed
                origin: origin,
                scale: scale, // No scaling
                effects: SpriteEffects.None,
                layerDepth: 0f // Default layer depth
            );
        }



    }
}
