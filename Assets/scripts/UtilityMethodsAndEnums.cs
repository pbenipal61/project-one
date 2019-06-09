using System;
namespace UtilityMethodsAndEnums
{

    namespace UtilityEnums
    {
        /// <summary>
        /// Types of Swipes possible
        /// </summary>
        public enum Swipe
        {
            RIGHT, LEFT, UP, DOWN
        }

        /// <summary>
        /// Player types.
        /// </summary>
        public enum PlayerType
        {
            STONE, BOOMERANG
        }

        namespace Obstacles
        {
            /// <summary>
            /// Obstcale types.
            /// </summary>
            public enum ObstacleType
            {
                OBSTRUCTION, FATAL, COLLECTABLE
            }

            /// <summary>
            /// Collectable types.
            /// </summary>
            public enum CollectableObstacle
            {
                MANGO, APPLE
            }

            /// <summary>
            /// Fatal obstacles.
            /// </summary>
            public enum FatalObstacle
            {
                EGG, BIRD, NEST
            }

            /// <summary>
            /// Obstructive obstacles.
            /// </summary>
            public enum ObstructionObstacle
            {
                BRANCH
            }
        }
    }

    namespace Models
    {
        public class LevelCreationData
        {
            private int numberOfObstacles;  // Number of obstacles to generate

            /// <summary>
            /// Initializes a new instance of the <see cref="T:UtilityMethodsAndEnums.Models.LevelCreationData"/> class based on passed inputs.
            /// </summary>
            /// <param name="numberOfObstacles">Number of obstacles.</param>
            public LevelCreationData(int numberOfObstacles = 20)
            {
                this.numberOfObstacles = numberOfObstacles;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:UtilityMethodsAndEnums.Models.LevelCreationData"/> class.
            /// </summary>
            public LevelCreationData() { }

            /// <summary>
            /// Gets the number of obstacles.
            /// </summary>
            /// <returns>The number of obstacles.</returns>
            public int getNumberOfObstacles() { return this.numberOfObstacles; }
        }
    }
}
