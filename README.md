# app_awsDotNetCoreStringSortApi
## AWS Lambda Function application

With this application I have built a natural string sorting algorithm, using .NET Core served via an AWS Serverless Application (SAM). A basic React user interface handles user input and application state.

With this application I have implemented IComparer to handle the sorting logic, comparing chunks of alpha and numeric values in order to achieve a natural sort order.

Whilst this functionality could be achieved with JavaScript alone, I wanted to demonstrate knowledge of IComparer and the .NET Core framework along with AWS Lambda.

A lot of research was undertaken for this application, with many permutations in order to overcome this simple, yet complex task. Made for a very enjoyable project!

- Portfolio Repository (https://github.com/fsereno/portfolio)

- IComparer (https://docs.microsoft.com/en-us/dotnet/api/system.collections.icomparer?view=netcore-3.1)

### Project commands ###

Build solution
```
    dotnet build project
```

Execute unit tests
```
    dotnet test test
```