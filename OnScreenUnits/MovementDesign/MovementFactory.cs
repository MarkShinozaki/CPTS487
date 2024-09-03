
namespace EGGS.OnScreenUnits.MovementDesign
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
   
    using EGGS.OnScreenUnits.MovementDesign;
    using EGGS.OnScreenUnits.MovementDesign.MovementInstances;

    internal class MovementFactory
    {
        public static MovementPattern CreateMovementPattern(Dictionary<string, object> movementPatternProperties)
        {
            MovementPattern movementPattern = null;
            string type = (string)movementPatternProperties["movementPatternType"];

            switch (type)
            {
                case "playerInput":
                    // Assuming positions have 'spawn' and 'start' properties.
                    var positions = (List<object>)movementPatternProperties["positions"];
                    var positionInfo = (Dictionary<string, object>)positions[0];
                    var spawnDict = (Dictionary<string, object>)positionInfo["spawn"];
                    var startDict = (Dictionary<string, object>)positionInfo["start"];

                    Vector2 spawnPosition = new Vector2(
                        Convert.ToSingle(spawnDict["x"]),
                        Convert.ToSingle(spawnDict["y"])
                    );

                    Vector2 startPosition = new Vector2(
                        Convert.ToSingle(startDict["x"]),
                        Convert.ToSingle(startDict["y"])
                    );

                    int speed = Convert.ToInt32(movementPatternProperties["speed"]);
                    movementPattern = new PlayerInput(spawnPosition, startPosition, speed);
                    break;

                case "linear":
                    var linearVelocity = (Dictionary<string, object>)movementPatternProperties["velocity"];
                    Vector2 linearVelocityVector = new Vector2(
                        Convert.ToSingle(linearVelocity["x"]),
                        Convert.ToSingle(linearVelocity["y"])
                    );
                    speed = Convert.ToInt32(movementPatternProperties["speed"]);
                    movementPattern = new linearMovement(linearVelocityVector, speed);
                    break;

                case "bounce":
                    var bounceVelocity = (Dictionary<string, object>)movementPatternProperties["velocity"];
                    Vector2 bounceVelocityVector = new Vector2(
                        Convert.ToSingle(bounceVelocity["x"]),
                        Convert.ToSingle(bounceVelocity["y"])
                    );
                    var bounceStartPositionDict = (Dictionary<string, object>)movementPatternProperties["startPosition"];
                    Vector2 bounceStartPosition = new Vector2(
                        Convert.ToSingle(bounceStartPositionDict["x"]),
                        Convert.ToSingle(bounceStartPositionDict["y"])
                    );
                    speed = Convert.ToInt32(movementPatternProperties["speed"]);
                    movementPattern = new BounceMovement(bounceStartPosition, bounceVelocityVector, speed);
                    break;

                default:
                    throw new ArgumentException($"Invalid movement pattern type: {type}");
            }

            return movementPattern;
        }
    

        public static List<MovementPattern> CreateListOfMovementPatterns(Dictionary<string, object> movementPatternProperties, int amountOfMovementPatterns)
        {
            List<MovementPattern> movementPatterns = new List<MovementPattern>();

            for (int i = 0; i < amountOfMovementPatterns; i++)
            {
                Dictionary<string, object> properties = new Dictionary<string, object>();
                foreach (string key in movementPatternProperties.Keys)
                {
                    if (movementPatternProperties[key] is List<object> list)
                    {
                        properties.Add(key, (int)list[i]);
                    }
                    else
                    {
                        properties.Add(key, movementPatternProperties[key]);
                    }
                }

                movementPatterns.Add(CreateMovementPattern(properties));
            }

            return movementPatterns;
        }
    }
}
