# EGGS Project - 487 FINAL GROUP PROJECT

The project, titled "Bullet Hell: Cats vs. Dogs (CvD)", is a bullet hell game developed by Epic Gamer Game Studios (EGGS) using C# and the MonoGame engine. The game involves controlling a player character in a two-dimensional space, avoiding projectiles from enemy waves, and shooting enemies to score points. The game is designed to be modular, allowing users to create custom levels using a level interpreter that processes JSON files to generate gameplay elements.

### Key Aspects of the Project:

1. Architectural Design Goals:

Performance: The game is designed to be highly responsive, with a focus on optimizing processing time for game functions like enemy spawning and wave management.
Testability: The game is built with testing in mind, using techniques like state control and limiting system complexity to ensure efficient bug detection and resolution.

2. Software Architecture:

- Multi-layered Architecture: The game follows a multi-layered architectural pattern where the Game component is central, supported by subsystems like Interpreter, Projectile, Player, Enemy, and Level subsystems.

- Subsystems:
  - Interpreter Subsystem: Manages game environment setup by interpreting JSON files.
  - Game Subsystem: Manages the core gameplay experience, integrating components from Player, Enemy, and Level subsystems.
  - Level Subsystem: Controls the timing and spawning of enemy waves.
  - Player Subsystem: Handles player control, shooting, and stats.
  - Enemy Subsystem: Manages enemy creation and behavior.
  - Projectile Subsystem: Handles projectile creation and interactions.

3. Design Patterns:

  - The project utilizes several design patterns:

    - Factory Pattern: Used for creating enemies and projectiles.
    - Builder Pattern: Employed by the level interpreter to construct game levels.
    - Command Pattern: Implemented in the EnemyManager to control enemy behaviors and handle events like enemy death.

### Specific Details of the EGGS Project - Bullet Hell: Cats vs. Dogs (CvD)

The EGGS project focuses on a modular and scalable design that allows users to customize gameplay through JSON-based level configuration. This flexibility is achieved through the careful implementation of design patterns and a layered architectural approach.

### Key Subsystems and Their Roles:

- **Interpreter Subsystem**: Reads JSON files to configure the game environment, including enemy types, wave durations, player lives, and more. This subsystem ensures that the game can be easily modified or extended with new levels and gameplay elements without altering the core game logic.

- **Game Subsystem**: The main driver of the game, where the player's interaction with the game world occurs. It uses inputs from other subsystems to render the game environment, manage game states, and ensure smooth gameplay.

- **Level Subsystem**: Handles the creation and management of enemy waves, ensuring that the game progresses with increasing difficulty by spawning enemies at appropriate intervals.

- **Player Subsystem**: Manages player input, controls movement, shooting, and tracking of player statistics like lives and scores.

- **Enemy Subsystem**: Responsible for generating enemy characters and managing their behavior, such as movement patterns and attack strategies. This subsystem uses the Factory pattern to create different types of enemies based on the level configuration.

- **Projectile Subsystem**: Manages all projectile-related activities, including player and enemy shooting mechanics, collision detection, and damage calculation.

### Secret Features of the Project:
As outlined in the "Project Secret Features" document:

- **Secret Features**: The project includes special features inspired by gameplay videos. One task involves implementing an "image reversal" gimmick or a collision detection mechanism for bullets in a final boss fight. These features require additional design and implementation work, which might involve modifying existing patterns or introducing new ones.

- **Design Impact**: The secret features necessitate a detailed design plan that considers the current architecture, identifies the required changes, and determines the design patterns that can accommodate these new features.
