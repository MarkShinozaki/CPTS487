namespace EGGS.Factory
{
    using EGGS.MovementDesign;


    /// <summary>
    /// 
    /// </summary>
    class MovementsFactory
    {
        public Movement makeMovement(string type, double duration)
        {
            type = type.ToLower();

            switch (type)
            {
                case "moveright":
                    return new MR(duration);
                case "moveleft":
                    return new ML(duration);
                case "moveup":
                    return new MU(duration);
                case "movedown":
                    return new MD(duration);
                case "movedownleft":
                    return new MDL(duration);
                case "movedownright":
                    return new MDR(duration);
                case "moveupleft":
                    return new MUL(duration);
                case "moveupright":
                    return new MUR(duration);
            }
            return null;

        }
    }
}
