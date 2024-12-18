# Step 1: Use the official .NET SDK image as a base
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the project files into the container
COPY . .

# Restore dependencies (this will download all necessary packages)
RUN dotnet restore TpFonction/TpFonction.csproj
RUN dotnet restore TpFonctionTest.nunit/TpFonctionTest.nunit.csproj

# Build the application (release version)
RUN dotnet build TpFonction/TpFonction.csproj --configuration Release

# Step 2: Run unit tests
RUN dotnet test TpFonctionTest.nunit/TpFonctionTest.nunit.csproj --no-build --verbosity normal

# Step 3: Publish the application
RUN dotnet publish TpFonction/TpFonction.csproj --configuration Release --output /app/publish

# Step 4: Final image with runtime (you can use a lighter image to reduce size)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final

# Set the working directory
WORKDIR /app

# Copy the build output from the previous stage
COPY --from=build /app/publish .

# Specify the entry point for the application
ENTRYPOINT ["dotnet", "TpFonction.dll"]
