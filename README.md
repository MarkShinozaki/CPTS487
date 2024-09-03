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

#### [Assignment 2](https://github.com/MarkShinozaki/CPTS487-SoftwareDesign-Architecture/tree/Assignments/Assignment%202)







#### [Assignment 3](https://github.com/MarkShinozaki/CPTS487-SoftwareDesign-Architecture/tree/Assignments/Assignment%203)




#### [Assignment 4](https://github.com/MarkShinozaki/CPTS487-SoftwareDesign-Architecture/tree/Assignments/Assignment%204)


#### [Assignment 5](https://github.com/MarkShinozaki/CPTS487-SoftwareDesign-Architecture/tree/Assignments/Assignment%205)




#### [Assignment 6](https://github.com/MarkShinozaki/CPTS487-SoftwareDesign-Architecture/tree/Assignments/Assignment%206)
