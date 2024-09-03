namespace EGGS.OnScreenUnits.MovementDesign.MovementInstances
{

    using Microsoft.Xna.Framework.Input;

    internal class PlayerMovement
    {
        private static Keys up = Keys.W;
        private static Keys down = Keys.S;
        private static Keys left = Keys.A;
        private static Keys right = Keys.D;
        private static Keys attack = Keys.Space;

        public static Keys Up { get => up; set => up = value; }

        public static Keys Down { get => down; set => down = value; }

        public static Keys Left { get => left; set => left = value; }

        public static Keys Right { get => right; set => right = value; }

        public static Keys Attack { get => attack; set => attack = value; }

    }
}

