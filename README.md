# KNILA IT SOLUTIONS

This project demonstrates the implementation of a simple authentication system using **.NET Core** (Backend) and **React.js** (Frontend). It includes the following features:

- JWT Authentication for secure API access
- Dependency Injection for better testability and decoupling
- Entity Framework For Database Connectivity
- Mocking of services using MOQ
- Unit Testing with xUnit
- Responsive React.js frontend with Bootstrap components
- React Bootstarp for Styling Components

Steps to Run the Project

- Clone the Repo to your local machine
- Navigate to "ContactMangementServices" Folder Update the App Setting Connection String enter your server name and database name in package manager console enter "Add-Migration initialtest" Then enter "UPDATE-DATABASE"and Start the API Services
- Navigate to "contactmanagementapp" Folder and Install the Dependencies Using "npm i" in Terminal
- Then Start your Front End App Using "npm start" in in Terminal
- If you are unable to login Please check the Services port and add that port in the constant file "contactmanagementapp->src->config->apiconfig.js" for Example Default setting is "const baseUrl = "https://localhost:7177/api/";" if your services is running on "http://localhost:5258" change the baseUrl to "http://localhost:5258" Please Ensure that your Services is Run Make secure any ssl protocol error check whether your services is running in https or http and make the following in baseURL
