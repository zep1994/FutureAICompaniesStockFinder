# Use official .NET SDK to build the API
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy project files and restore dependencies
COPY *.sln ./
COPY WebScraperAPI/*.csproj ./WebScraperAPI/
RUN dotnet restore WebScraperAPI/WebScraperAPI.csproj

# Copy everything and build the app
COPY WebScraperAPI/. ./WebScraperAPI/
WORKDIR /app/WebScraperAPI
RUN dotnet publish -c Release -o /publish

# Use ASP.NET runtime to run the API
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "WebScraperAPI.dll"]
