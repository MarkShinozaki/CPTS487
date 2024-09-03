


namespace EGGS.Utility
{
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework;

    internal class GraphicsManager
    {

        public static GraphicsDeviceManager GraphicsDeviceManager { get; set; }

        public static GraphicsDevice GraphicsDevice { get => GraphicsDeviceManager.GraphicsDevice; }
    }
}
