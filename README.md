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



---
## [Assignment 4](https://github.com/MarkShinozaki/CPTS487-SoftwareDesign-Architecture/tree/Assignments/Assignment%204)

---
## [Assignment 5](https://github.com/MarkShinozaki/CPTS487-SoftwareDesign-Architecture/tree/Assignments/Assignment%205)



---
## [Assignment 6](https://github.com/MarkShinozaki/CPTS487-SoftwareDesign-Architecture/tree/Assignments/Assignment%206)
