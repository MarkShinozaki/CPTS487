using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGGS.Utility
{
    internal class LoadTextures
    {
        public static ContentManager Content { get; set; }

        public static Texture2D GetTexture(string textureName)
        {
            var texture = Content.Load<Texture2D>(textureName);
            return texture;
        }

        
    }
}
