# Travel API

#### C# Building an API Project, 30 March 2020
 
#### By **_Jieun Kang_**
---

## Description
An API that allows users to GET and POST reviews about various travel destinations around the world. 

---

## Specifications : user sotries
* As a user, I want to GET and POST reviews about travel destinations.
* As a user, I want to GET reviews by country or city.
* As a user, I want to see the most popular travel destinations by number of reviews or by overall rating.
* As a user, I want to PUT and DELETE reviews, but only if I wrote them. (Start by requiring a user_name param to match the user_name of the author on the message. You can always try authentication later.)
* As a user, I want to look up random destinations just for fun.
* Further Exploration 
  * Token-Basked Authentication and Authorization (JWT)
  * API Versioning
  * Using Swagger for Documentaion
---

## Setup/Installation 
### :small_orange_diamond: Installing C# and .NET

* _Download on Mac [.NET Core SDK (Software Development Kit)](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-2.2.106-macos-x64-installer)_
* _Download on Windows [64-bit .NET Core SDK (Software Development Kit)](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-2.2.203-windows-x64-installer)_

### :small_orange_diamond: Run this project

1. Clone this project
    * `$ git clone https://github.com/jieunkang-101/TravelApiCall`
2. go to the project folder
    * `$ cd TravelApiCall`
    * `$ cd TravelApi`
3. Restore all dependencies
    * `$ dotnet restore` 
4. Re-create the database    
    * `$ dotnet ef database update` 
5. Conpile and Run this application    
    * `$ dotnet build` 
    * `$ dotnet run` 
---

## Technologies Used

* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
* [.NET](https://dotnet.microsoft.com/)
* [ASP.NET Core MVC 2.2](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-2.2)
* [Entity Framework Core](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-2.2)
* [Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-2.2&tabs=visual-studio)
* [RestSharp API](http://restsharp.org/)
* [Newtonsoft.Json](https://www.newtonsoft.com/json)
* [Swagger](https://swagger.io/)
* [Bootstrap v4.4](https://getbootstrap.com/docs/4.4/getting-started/introduction/)
---

### License
*This webpage is licensed under the [MIT](https://en.wikipedia.org/wiki/MIT_License) license*
Copyright (c) 2020 **_Jieun Kang_**