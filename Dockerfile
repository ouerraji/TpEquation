# Étape 1 : Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore TpFonction.sln

RUN dotnet build TpFonction/TpFonction.csproj --configuration Release

dotnet test TpFonctionTest.nunit/TpFonctionTest.nunitcsproj --no-build --verbosity normal

# Étape 2 : Publish
RUN dotnet publish TpFonction.sln --configuration Release --output /publish

# Étape 3 : Runtime
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "TpFonction.dll"]
