# Assignments 

## [Assignment 1](https://github.com/MarkShinozaki/CPTS487-SoftwareDesign-Architecture/tree/Assignments/Assignment%201)

This assignment revolves around designing a simple object-oriented program where users can draw shapes (circles and rectangles) on a canvas. The primary focus is on understanding object-oriented principles such as inheritance, abstraction, composition, and aggregation. Here’s a breakdown of what the assignment is looking for in each question:

1. Defining Classes for Circle and Rectangle:

    - **Task**: Define two classes, Circle and Rectangle, with attributes for their center and methods to calculate their area.
    - **Objective**: To ensure you can create basic classes with specific attributes and methods relevant to their functionality.

2. Creating a Shape Class:

    - **Task**: Create a Shape class that encapsulates the common characteristics of Circle and Rectangle.
    - **Objective**: Understand the concept of inheritance where Circle and Rectangle would inherit from Shape. The relationship is inheritance, and the Shape class is needed to avoid redundancy and to provide a common interface.

3. Making the Shape Class Abstract:

    - **Task**: Decide whether the Shape class should be abstract, meaning it cannot be instantiated on its own.
    - **Objective**: To enforce that only specific shapes (Circle, Rectangle) can be drawn, ensuring the Shape class is an abstract class.

4. Incorporating Style into Shapes:

    - **Task**: Introduce a Style class to encapsulate aesthetic elements like color, fill, and outline, and modify the Shape class to include this.
    - **Objective**: To practice adding attributes and understand how changes in the design might affect the overall class structure.

5. Relationship Between Shape and Style:

    - **Task**: Decide whether Style should be its own class and define the relationship between Shape and Style.
    - **Objective**: To explore aggregation vs. composition relationships in object-oriented design, with Shape having a Style attribute.

6. Implementing a Canvas Class:

    - **Task**: Define a Canvas class with a draw method that allows users to draw shapes on the canvas.
    - **Objective**: To understand how objects interact with one another and how a method can be used to perform an action like drawing on a canvas.

7. Understanding Relationships and Dependencies:

    - **Task**: Discuss the relationship between Canvas and Shape, and between Shape and Style. Also, explore what happens to Shape instances when a Canvas is deleted and what happens to Style instances when a Shape is deleted.

    - **Objective**: To solidify the understanding of object lifecycles, especially how composition (Canvas-Shape) differs from aggregation (Shape-Style).

### Solution Details:

- The provided solution outlines the answers to these questions, emphasizing the following:

    - The creation of an abstract `Shape` class with concrete `Circle` and Rectangle subclasses.

    - Use of an abstract method for `getArea()` in `Shape`, implemented in the subclasses.

    - Incorporation of a `Style` class, associated with `Shape` through aggregation.

    - Implementation of a `Canvas` class that manages `Shape` instances through composition, meaning deleting a `Canvas` deletes all associated shapes.


### Key Concepts Covered:

- **Inheritance**: Creating a hierarchy of classes where Circle and Rectangle inherit from Shape.

- **Abstraction**: Using abstract classes and methods to define a common interface for different shapes.

- **Aggregation and Composition**: Understanding the different ways objects can relate to each other in terms of their lifecycle.

- **Object Interaction**: Implementing methods that allow objects (like shapes) to interact with others (like the canvas).

---

## [Assignment 2](https://github.com/MarkShinozaki/CPTS487-SoftwareDesign-Architecture/tree/Assignments/Assignment%202)

This assignment builds upon the concepts introduced in Assignment 1 and focuses on the Factory Method Pattern. The main goal is to design a system that uses the Factory Method Pattern to create and manage shapes (circles and rectangles) and to explore the limitations of the Factory Method, with considerations for when the Abstract Factory Pattern might be more appropriate.

### Detailed Breakdown of Each Question:

1. **Class Diagram using Factory Method Pattern (10 points)**:
   
    - **Task**: You are required to design a class diagram that includes `Shape`, `Circle`, `Rectangle`, `Canvas`, and other necessary classes following the Factory Method Pattern.
      
    - **Objective**: The Factory Method Pattern involves creating a factory class for each type of product (in this case, a `CircleFactory` and `RectangleFactory`) that will handle the creation of Circle and Rectangle objects. The Canvas class will utilize these factories to draw shapes.
      
    - **Key Points**: Ensure that each shape has its own factory class, and the diagram should clearly show the relationships between these classes.

3. **Role of the Canvas Class (5 points)**:

    - **Task**: Determine whether the Canvas class is part of the Factory Method Pattern or something external to it, and justify your reasoning.

    - **Objective**: This question tests your understanding of the Factory Method Pattern's structure. Generally, the Canvas class would be external to the pattern, as it uses the factories to create shapes rather than being a factory itself.

3. **Sketch Code Demonstrating Drawing a Circle (10 points)**:

    - **Task**: Provide a basic code sketch that demonstrates how to draw a circle on a canvas using the classes defined in the first question. Comments can be used to describe method functionality rather than writing full code.

    - **Objective**: The code should show how the Canvas interacts with the CircleFactory to create and draw a Circle object, demonstrating the practical application of the Factory Method Pattern.

4. **Scenario Where Factory Method Might be Insufficient (5 points)**:

    - **Task**: Describe a situation where the Factory Method Pattern may not be sufficient and where the Abstract Factory Pattern could be more appropriate, such as when introducing new elements like styles for shapes.

    - **Objective**: This question encourages you to think about the limitations of the Factory Method and understand when a more complex pattern, like Abstract Factory, might be needed—particularly in situations where multiple related objects need to be created.

5. **Application of Factory/Abstract Factory in a Course Project (10 points, not for submission)**:

    - **Task**: Consider how you would apply either the Factory Method or Abstract Factory Pattern in the course project. This question is meant to stimulate discussion within your team about the pros and cons of different design patterns.

    - **Objective**: This open-ended question encourages critical thinking about the application of design patterns in real-world projects, helping you start planning for the course project.


### Summary of the Solution:
- The provided solution outlines how to approach each of these questions, with particular emphasis on correctly implementing the Factory Method Pattern through class diagrams and sketch code. The solution also explores scenarios where the Abstract Factory Pattern would be more effective, particularly in handling more complex object creation scenarios.


---
## [Assignment 3](https://github.com/MarkShinozaki/CPTS487-SoftwareDesign-Architecture/tree/Assignments/Assignment%203)

This assignment focuses on applying design patterns, specifically the Factory Method and Abstract Factory patterns, to model the creation of different types of zombies in a game. The task involves deciding on the appropriate pattern to use, creating a class diagram to represent the design, and considering alternative class structures for representing different zombie types.

### Detailed Breakdown of Each Question:

1. **Choosing Between Factory and Abstract Factory Pattern (5 points)**:

    - **Task**: You need to decide whether to use the Factory Method or the Abstract Factory pattern to create the three types of zombies: RegularZombie, ConeZombie, and BucketZombie. You must provide a brief justification for your choice.

    - **Objective**: This question tests your understanding of when to use each pattern. The Factory Method is typically used when there is a single product with multiple variations, while the Abstract Factory is more suitable when dealing with multiple related products.

2. **Class Diagram (5 points)**:

    - **Task**: Draw a class diagram that models the creation of the three zombie types using the pattern you chose in the first question. The structure should be based on the diagram from the "Analysis Case Study 2" slides.

    - **Objective**: This question requires you to apply the chosen pattern to create a proper class hierarchy and relationships between classes. The diagram should include all necessary classes like Product, ConcreteProduct, and Factory, but you do not need to include specific attributes or methods.

3. **Correspondence and Creation Process (5 points)**:

    - **Task**: Map your classes to the corresponding roles in the Factory/Abstract Factory structure (e.g., Zombie as Product, ConeZombie as ConcreteProduct). Describe how the pattern facilitates the creation of the different zombie types.

    - **Objective**: This question ensures that you understand the roles of different classes within the design pattern and how they interact to create specific instances of zombies.

4. **Alternative Class Structure (5 points)**:

    - **Task**: Consider the current inheritance structure where ConeZombie and BucketZombie inherit from RegularZombie. Given that these zombies have different health values (e.g., RegularZombie has 50, ConeZombie has 75, BucketZombie has 150), think of an alternative class structure that could represent these zombies. You are encouraged to think creatively and consider other patterns or approaches.

    - **Objective**: This open-ended question allows you to explore other design possibilities, such as using composition over inheritance or applying another pattern like the Strategy or Decorator pattern. You are also asked to list any resources or research you conducted while considering alternative solutions.

### Summary of the Solution:

The solution provided gives detailed answers to each question:

- **Question 1**: Justifies the use of the Factory Method Pattern, which is sufficient for creating the different zombie types without the added complexity that might necessitate an Abstract Factory.

- **Question 2**: Presents a class diagram that models the Factory Method pattern, showing how different zombies are created using dedicated factories.

- **Question 3**: Maps each class in the diagram to the roles in the Factory Method pattern and explains the creation process, emphasizing the role of factories in producing specific zombies.

- **Question 4**: Suggests alternative class structures for representing the different zombies, considering their varying health attributes, and explores potential design patterns that could be applied.

---
## [Assignment 4](https://github.com/MarkShinozaki/CPTS487-SoftwareDesign-Architecture/tree/Assignments/Assignment%204)

This assignment is centered around the popular game Plants vs. Zombies, but with a focus on applying design patterns to model the behavior and interaction of different zombies and their accessories. The key design patterns involved are the Factory/Abstract Factory and Composite patterns. The assignment requires you to design a class structure, implement a simple demo game, and explore how changes in the game's mechanics impact your design.

### Detailed Breakdown of Each Task:

1. **Creational Pattern and Composite Pattern Implementation (10 points)**:

    - **Task**: Choose a creational design pattern (Factory, Abstract Factory, Builder) to create the different types of zombies: RegularZombie, ConeZombie, BucketZombie, and ScreenDoorZombie. Additionally, use the Composite pattern to model the zombie-related classes, particularly how zombies with accessories degrade into regular zombies when their accessories are destroyed.

    - **Deliverable**: A class diagram created using UML that shows how the creational and composite patterns are applied, including necessary attributes and operations like takeDamage(int d) and die().

2. **Class Diagram Match-Ups (10 points)**:

    - **Task**: Match the classes in your diagram with the roles in the pattern structures (e.g., ZombieFactory -> Creator, Zombie -> AbstractProduct). Ensure that the relationships between classes and their attributes/operations align with the patterns.

    - **Deliverable**: A list of these match-ups alongside your class diagram.

3. **Executable Demo Program (40 points)**:

    - **Task**: Write a simple demo game that simulates a Peashooter attacking an array of zombies. The game should allow the user to create different zombies, store them in an array, and simulate the attack process where zombies are damaged, accessories are destroyed, and zombies change types accordingly.

    - **Deliverable**: The program should run in a command-line interface, with options to create zombies, display their current state, and simulate the attack process. The game should automatically continue until all zombies are defeated.

4. **Impact of Changing Peashooter Damage (20 points)**:

    - **Task**: Consider what would change if the damage of the Peashooter is increased from 25 to 40. Implement a feature that allows the user to select a different damage value before the game begins. Additionally, incorporate "leftover damage" logic, where damage exceeding the accessory’s health is transferred to the zombie’s health.

    - **Deliverable**: An updated version of your program that includes these changes, along with a short explanation of how this impacts your design and implementation.

5. **Introducing a New Plant: Watermelon (20 points)**:

    - **Task**: Introduce a new plant, the Watermelon, which attacks differently from the Peashooter, particularly in how it affects ScreenDoorZombie. Explain how this new feature impacts your program design and whether the Composite pattern still works. You are not required to implement the change but should provide a detailed explanation.

    - **Deliverable**: A short written explanation discussing the necessary modifications to the design and how the new feature interacts with existing patterns.

### Summary of the Solution:

The provided solution would typically include:

- A UML diagram showing how the Factory and Composite patterns are applied to model the different types of zombies.
  
- A match-up of the classes in the diagram with the roles defined by the design patterns.
  
- An executable command-line program that simulates the game’s mechanics, including creating zombies, simulating attacks, and handling accessory degradation.
  
- An explanation of how changes in Peashooter damage affect the game logic, along with a modified program that accommodates user-selected damage values.
  
- A discussion on how introducing a Watermelon plant would impact the current design and any necessary adjustments.



---

## [Assignment 5](https://github.com/MarkShinozaki/CPTS487-SoftwareDesign-Architecture/tree/Assignments/Assignment%205)


This assignment is divided into two main parts: implementing the Command Design Pattern and discussing a Quality Attribute (QA) in the context of a software project. Below is a detailed explanation of each part of the assignment.

### Question 1: Implementing the Command Design Pattern (10 points)

#### Part A: Completing the Classes

- **Task**: You are provided with partial code that implements the Command Design Pattern. The key components include:

    - Command Interface: Defines a single method `execute()` which all command classes must implement.
    - Invoker Class (`Switch`): Stores and executes commands.
    - Receiver Class (`Light`): Contains the actual operations (turnOn and turnOff) that can be triggered by commands.

- Concrete Command Classes:
    - `FlipUpCommand`: Command to turn the light on.
    - `FlipDownCommand`: Command to turn the light off.

- Objective: You need to complete the `FlipUpCommand` and `FlipDownCommand` classes by implementing their `execute()` methods. The `FlipUpCommand` should call `turnOn()` on the `Light` instance, and the `FlipDownCommand` should call `turnOff()`.

#### Part B: Writing a Test Program

- **Task**: Write a test program (or main function) that:

    - Creates a `Light` object.
    - Uses `FlipUpCommand` to turn the light on.
    - Uses `FlipDownCommand` to turn the light off.
    - Executes these commands using the Switch class.
      
- **Objective**: Demonstrate how the Command Pattern can be used to decouple the request for an action (turning the light on/off) from the actual implementation of the action.

### Question 2: Quality Attribute (QA) in a Software Project (20 points)

#### Part A: Project Description

- **Task**: Briefly describe the largest software project you have been involved with. This could be from a senior design project, an internship, or a significant course project.

#### Part B: Selecting and Explaining a Quality Attribute

- **Task**: Choose one Quality Attribute (Availability, Performance, Security, Testability) from the lesson videos that is most relevant to your project. Explain why this QA is important for the project.

#### Part C: Tactics to Address the Quality Attribute

- **Task**: Refer to the corresponding chapter in the [BASS] textbook that covers the tactics for achieving the QA you selected. Write about what you or your team did in the project that aligns with one of these tactics.

    - **Example**: If you choose Performance, you might discuss tactics like "Control Resource Demand" or "Manage Resources" and explain specific measures your team took to implement these tactics in your project.
      
- **Objective**: The goal is to connect theoretical concepts from the course to real-world applications, demonstrating your understanding of how quality attributes can be practically addressed in software development.

#### Summary:
- **Question 1** focuses on the practical implementation of the Command Design Pattern, reinforcing your understanding of how to structure code in a way that separates concerns and promotes flexibility.

- **Question 2** requires you to reflect on a real project experience, analyzing how quality attributes were or could be managed, thus bridging the gap between theory and practice.



---
## [Assignment 6](https://github.com/MarkShinozaki/CPTS487-SoftwareDesign-Architecture/tree/Assignments/Assignment%206)

Assignment 6 continues the exploration of design patterns using the Plants vs. Zombies game as a context. The focus is on using the Decorator and Observer patterns, alongside a creational pattern (Factory or Builder) to design a flexible system for simulating the game. Below is a breakdown of the tasks involved in this assignment:

### Task Breakdown:

1. Creational Pattern and Decorator Pattern Implementation (10 points):

- **Task**: You are required to use a creational pattern (Factory/Abstract Factory/Builder) to create four types of zombies: RegularZombie, ConeZombie, BucketZombie, and ScreenDoorZombie. Then, use the Decorator Pattern to model the zombie-related classes.

- **Deliverable**:
    - A class diagram that connects the creational pattern with the Decorator pattern, showing necessary attributes and operations, such as takeDamage(int d), die(), and possibly a bool isMetal attribute.
    - The diagram should clearly match the components of the patterns to your classes (e.g., which class acts as the decorator, the concrete decorator, etc.).
      
2. Executable Demo Program (80 points):

    - **Part A (10 points)**: The program should start by creating zombies using the chosen creational pattern, similar to Assignment 4, but now organized following the Decorator pattern.
      
    - **Part B (30 points)**: Implement the "Demo gameplay" feature where users can choose from three plants (Peashooter, Watermelon, Magnet-shroom) to attack zombies. The attacks should be simulated using command-line output, updating the array of zombies and their health values after each attack.

    - **Part C (10 points)**: Integrate the provided `GameObjectManager` (GOM) and `GameEventManager` (GEM) classes into your program. These manage the game objects and handle attack events (collisions) between plants and zombies.

    - **Part D (30 points)**: Implement the Observer Pattern to ensure that the `GameObjectManager` updates the list of zombies when a zombie dies. You need to correctly identify the observer and observable classes and implement the pattern according to the behavior sequence described in the lecture.

3. Comparison of Composite and Decorator Patterns (10 points):

    - **Task**: Compare the Composite and Decorator patterns, discussing which one is more suitable for this assignment. You need to provide reasoning based on your design and the requirements of the game simulation.

    - **Deliverable**: A brief written explanation comparing the two patterns and justifying your choice.


#### Key Concepts Covered:
- **Decorator Pattern**: Used to add responsibilities to objects dynamically, particularly useful in modeling the zombies with different accessories.

- **Observer Pattern**: Implements a subscription mechanism to allow multiple objects to listen and react to events, crucial for updating the game state when a zombie dies.

- **Factory/Builder Pattern**: Provides a way to create complex objects (zombies) without exposing the instantiation logic, making the code more modular and easier to maintain.

#### Summary:

Assignment 6 is designed to test your ability to apply multiple design patterns in a cohesive manner to solve a problem. You’ll need to demonstrate a deep understanding of the Decorator and Observer patterns, along with a chosen creational pattern, by creating a functioning demo game and discussing the patterns' effectiveness. The tasks are both practical (writing code) and theoretical (comparing patterns), making this a comprehensive exercise in software design.




















