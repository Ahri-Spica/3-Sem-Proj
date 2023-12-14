#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Tsp.Api/Tsp.Api.csproj", "Tsp.Api/"]
COPY ["Tsp.Application/Tsp.Application.csproj", "Tsp.Application/"]
COPY ["Tsp.Domain/Tsp.Domain.csproj", "Tsp.Domain/"]
COPY ["Tsp.Infrastructure/Tsp.Infrastructure.csproj", "Tsp.Infrastructure/"]
RUN dotnet restore "Tsp.Api/Tsp.Api.csproj"
COPY . .
WORKDIR "/src/Tsp.Api"
RUN dotnet build "Tsp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tsp.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tsp.Api.dll"]