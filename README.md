
# _Animal Shelter Project_

#### _This demonstrates beginner level C# with ASP.Net Core and JWT authentication._

#### By _**Matthew**_

## Description

_A page demonstrates basic C# with Asp.Net Core._
_A Factory app with many to many relationships_
     
## Setup/Installation Requirements
* Install dotnet core from https://dotnet.microsoft.com/download
* Install MySql. Consult https://www.learnhowtoprogram.com/fidgetech-3-c-and-net/3-0-lessons-1-5-getting-started-with-c/3-0-0-04-installing-and-configuring-mysql
* Clone/download the repo
* Navigate to the AnimalShelterAPI.Solution folder
* Navigate to the AnimalShelterAPI folder 
* Open your terminal
* Enter the following commands into the terminal
* enter `dotnet restore`
* enter `dotnet ef database update`
* Open the appsettings.json file
* Edit the Password property to a selected password
* This will be the default users password which enable Posting, Deleting, and Updating animals.
* Your username will be User1
* Edit the Jwt:Key property from "ThisismySecretKey" to a selected password at least 16 characters in length in the appsetting.json
* This will ensure that the JWT tokens produced by the server are secure.
* enter `dotnet run` to open the program
* Congratulations you should have the API running.
* You can make calls to the api with Postman or you can use the client web api which I will explain how to use in the next steps.
* To use the client web api read on.
* From the root folder of the AnimalShelterProject navigate to AnimalShelterClient.Solution
* Then navigate to AnimalShelterClient
* open your terminal and enter dotnet restore `dotnet restore`
* enter `dotnet run` to start the program
* Open the program by going to http://localhost:80 in your browser
* remember that the api app must be running at the same time as the client app in order for the client app to work.


## Unsecured Api Routes - See the Secured API routes section for more routes
You must be running the api app to access these routes. If you are using the client app all of the routes are automatically handled for you.

Index route: To access a list of all animals in the database
http://localhost:5000/api/animals as a GET request in postman.

GET route: To access a single animal item by id.
Hint: {id} = the id of the animal item you wish to see.
http://localhost:5000/api/animals/{id} as a GET request in postman.

## Login route and preparation for the secured routes
These API routes are only for those who have the password
http://localhost:5000/api/security/login as a POST request in postman
In the body of the post request (or use the client web app if you don't know how to do this) include a JSON object that contains User1 as the user and the password you chose while setting up the api.

for example
{
  "Username": "User1",
  "Password": "<The password you chose>"
}

The login route will return a JWT token. This JWT token will only last 2 hours
according to the apps default configuration.

In order to make use of the JWT token to access secure routes. follow these instructions
Enter the login token into the header of the request in postman according to these steps.
* Create a key called `Authorization`.
* The value of that key should be `header <cookiefromloginrequest>` 
* so header then space then paste the cookie value you received from the login request

## Secured API routes
* See the previous sections for login instructions
POST route: Create a new animal entitity in the database
http://localhost:5000/api/animals/ as a POST request in postman.
Include in the body of the request a JSON object that includes the name of the animal and the type of animal it is.

for example
{
  "name": "todo",
  "animalType": "Dog"
}

PUT route: Edit an animal entity:
http://localhost:5000/api/animals/{id} as a PUT request in postman
Include in the body of the put request a JSON object that includes the id of the animal to be editied as well as the name and animaltype properties. Modify the fields as you see fit.

for example
{
  "animalId":1
  "name": "todo",
  "animalType": "Dog"
}

DELETE route: Remove an animal entity from the database.
http://localhost:5000/api/animals/{id} as a DELETE request in postman


## Understanding JWT token
A JWT token, or JSON Web Token, allow the ability to secure a web application without creating any records on the server.
In general a server creates the token when a user provides password and user credentials to the server. 
Then all requests to the server which require authorization will check the JWT token and checks if that token is a valid token and has the correct expiration date and user info as well as any other info that is needed.
A user can not falsify a token because a token is created with a hash algorithm and thus any modifications to the token will not be verifiable on the server.

If you use the client app tokens are handled automatically and you will not need to understand how they work.

If you are accessing the API app from Postman you must understand how to extract the JWT token from a login response and place it in the header. I have provided instructions on how to do this in the API routes sections of this file. If you don't understand these instructions no worries, you can still use the client app.

## Known Bugs

_I don't think there are any bugs but please tell me if you see any._

## Support and contact details

_Open a Github issue if you see a problem or have questions_

## Technologies Used

_This is a C#, Asp.Net Core, Entity, and Razor thing._

### License

*Feel free to use this code as you please*

Copyright (c) 2020 **_Matthew_**