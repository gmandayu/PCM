dotnet --info
dotnet build
dotnet dev-certs https --trust
dotnet publish -c Debug
