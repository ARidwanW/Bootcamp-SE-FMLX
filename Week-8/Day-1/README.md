## WebAPI
`dotnet new webapi`

## Test API:
- Swagger (internal project WebAPI)
- Postman (Extension VSCode, software)
- THunderClient (Extension VSCode)

## appsettings.json:
- Configuration
- ConnectionString
- Credential

## Http Response:
- 200-299 OK
- 300-399 Redirect
- 400-499 Client Error
- 500-599 Server Error

## Http Request:
- GET   : Request Data
- POST  : Send Data
- PUT   : Change Data
- DELETE    : Remove Data

## EndPoint:
- Category
    - GET       = localhost:port/api/category
    - POST      = localhost:port/api/category or /{id}
    - PUT       = localhost:port/api/category
    - DELETE    = localhost:port/api/category/{id}

## DTO : Data Transfer Object
```class User
{
    id
    name
    email
    password
    address
    motherName
    ktp
}
```
Just need name and email to request
```
class UserRequest
{
    name
    email
}
```
Just need id name email address to response
```
class UserResponse
{
    id
    name
    email
    address
}
```

## AUTOMAPPER
1. Install NuGet Package
    1. Automapper
    2. Automapper.DependencyInjection
2. Create class inheri from Profile
3. Create the constructor
4. Fill it with `CreateMap<TSource,TTarget>`;
5. Controller make private variable of composisition of IMapper with its contructor
6. Inject from Program.cs - `builder.Services.AddAutoMapper(typeof(NameofClassAutoMapper));`
7. Example to use
    1. `Category category = _map.Map<Category>(datasSource);`
    2. `List<Category> categories = _map.Map<List<Category>>(dataSource);`

## Clean Architecture (N-Tier)
### Project:
1. API project = dotnet new webapi (webAPI)
2. Application project = dotnet new classlib (React, Vue, Vanilla)
3. Model project = dotnet new classlib (Model, Entity, DTOs)
4. Persistence project = dotnet new classlib (DbContext)
5. Utilities project = dotnet new classlib (Mapper, Extension Method)

API --> Application, Utilities, Persistence, Model
Persistence --> Model