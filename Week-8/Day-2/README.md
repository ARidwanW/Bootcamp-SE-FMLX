## MVC:
`dotnet new mvc`

## Clean Architecture (N-Tier)
### Project:
* **WebMVC**
1. API project = dotnet new webapi (webAPI)
2. Application project = dotnet new classlib (React, Vue, Vanilla)

* **WebMVC.Models**
3. Model project = dotnet new classlib (Model, Entity, DTOs)

* **WebMVC.Persistence**
4. Persistence project = dotnet new classlib (DbContext)

5. Utilities project = dotnet new classlib (Mapper, Extension Method)

API --> Application, Utilities, Persistence, Model
Persistence --> Model

## If using Clean Architecture
# to migrations
* **In root folder**
`dotnet ef migrations add "Message" -p ./WebMVC.Persistence -s ./WebMVC`

* **In Persistence folder**
`dotnet ef migrations add "Message" -s ../WebMVC`