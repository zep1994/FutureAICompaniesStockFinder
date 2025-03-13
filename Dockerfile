# Use the .NET SDK for development to enable hot reload and debugging
FROM mcr.microsoft.com/dotnet/sdk:9.0
WORKDIR /app

# Copy the project file and restore dependencies (cache-friendly)
COPY WebScraperAPI/WebScraperAPI.csproj ./WebScraperAPI/
RUN dotnet restore WebScraperAPI/WebScraperAPI.csproj

# Copy the rest of the application source code
COPY . .

# Set the working directory to your project folder
WORKDIR /app/WebScraperAPI

# Expose port 80 (or any port you plan to use)
EXPOSE 80

# Set the environment to Development
ENV ASPNETCORE_ENVIRONMENT=Development

# Use dotnet watch to run the application with hot reload
CMD ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:80"]
