FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY pokedexApi/pokedexApi.csproj ./pokedexApi/
COPY pokedexBusiness/pokedexBusiness.csproj ./pokedexBusiness/
COPY pokedexData/pokedexData.csproj ./pokedexData/

WORKDIR /app/pokedexApi
RUN dotnet restore

WORKDIR /app
COPY pokedexApi/. ./pokedexApi/
COPY pokedexBusiness/. ./pokedexBusiness/
COPY pokedexData/. ./pokedexData/

FROM build AS publish
RUN dotnet publish "pokedexApi/pokedexApi.csproj" -c Release -o /out

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy-chiseled-composite AS base
WORKDIR /app
COPY --from=publish  /out .
CMD ["dotnet", "./pokedexApi.dll"]