
A) Project Description 

- My senior design project involved developing a full-stack web application for inventory managment at Cashmere Food Bank. This application's primary goal is to streamline the process of tracking food items, thier quantities, and thier distribution, thus ensuring efficient operations and managment of important data. The application was designed to be intuitive and user-friendly.

B) Importance of Performance 

- Performance was a crucial quality attribute for our project becuase the system needed to handle multiple requests efficiently, especially during high traffic periods like when the food bank is experiencing high volumes of donations. On of the bigger issues the food bank has was statistical analysis tracking and user session activity tracking.

C) Tactics Employed 

- We implemented RBAC with session managment tracking since the food bank wanted to understand when items were being added and removed during which sessions. This ensured that active sessions were efficiently managed and that system resources were not tied up by idle users. Sessions were automatically timed out after a period of inactivity freeing up resources.
- Resource pooling, we used a firebase database which inherently manages connection pooling. This allowed us to handle multiple requests more efficiently, as the connections to the database were resued, reducing the overhead of establishing new connections for new operations.
