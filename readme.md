# General

To generate client project for API (could be usefull usually for microservices) first run on the API project folder:

1. `dotnet new tool-manifest`
2. `dotnet tool update SwashBuckle.AspNetCore.Cli --ignore-failed-sources -v m -interactive`

