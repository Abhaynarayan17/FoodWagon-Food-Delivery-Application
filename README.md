# FoodWagon
A comprehensive Food Delivery application using C# .NET for the backend, SQL Server for the database, HTML, CSS, and JavaScript for the frontend, and Angular for the single-page application framework. The application will support functionalities for both Restaurants and Customers, including
registration, login, menu management, order placement, and delivery tracking.

Sprint 1: User Registration, Authentication, and Menu Management
Restaurant Stories:
1. Restaurant Authentication:
As a Restaurant, I should be able to register, log in, and log out of the application.
2. Menu Management:
As a Restaurant, I should be able to perform CRUD (Create, Read, Update, Delete)
operations on the menu items.
3. Order Management:
As a Restaurant, I should be able to view and manage orders placed by Customers,
including updating order statuses (e.g., accepted, prepared, out for delivery).

Customer Stories:
1. Customer Registration and Authentication:
○ As a Customer, I should be able to register, log in, and log out of the application.
2. Restaurant Browsing and Menu Viewing:
○ As a Customer, I should be able to browse a list of available Restaurants.
○ As a Customer, I should be able to view the menu items offered by a selected Restaurant,
along with details such as price, description, and availability.
3. Order Placement:
○ As a Customer, I should be able to place an order by selecting items from a Restaurant's
menu and proceeding to checkout.
Instructions:
● Backend Development:
○ Develop the backend logic using ASP.NET Core to handle user authentication, menu
management, and order management.
○ Design the database schema to manage Restaurants, Customers, menu items, and
orders. Implement stored procedures for these functionalities.
SLK PreJoining Aug 24
○ Implement custom exceptions to handle errors such as invalid input during registration
or order placement.
○ Use appropriate design patterns like Repository Pattern and Factory Pattern for
organizing data access and business logic.
● Frontend Development:
○ Create responsive web pages for user registration, login, restaurant browsing, menu
viewing, and order placement using HTML, CSS, and JavaScript.
○ Use Angular to implement single-page application features such as routing, components,
and services for a smooth user experience.
● Testing:
○ Implement unit tests for user authentication, menu management, and order
management functionalities.
○ Perform UI testing to ensure that the frontend meets design requirements and functions
correctly.
● Documentation:
○ Create a schema diagram for the database tables involved in user management, menu
management, and order management.
○ Submit the SQL script for table creation, stored procedures, and any queries executed in
this sprint.
Sprint 2: Order Tracking and Delivery Management
Restaurant Stories:
1. Order Management:
○ As a Restaurant, I should be able to update the status of an order (e.g., order accepted,
food prepared, out for delivery).
2. Delivery Management:
○ As a Restaurant, I should be able to assign orders to delivery personnel and track the
status of deliveries.
Customer Stories:
1. Order Tracking:
○ As a Customer, I should be able to track the status of my order in real-time, including
seeing when the order is accepted, prepared, and out for delivery.
2. Error Handling and Enhancements:
○ Implement advanced error handling, including custom exceptions for order processing
and delivery tracking.
○ Optimize code using Lambda expressions where applicable, especially in filtering and
sorting operations.
