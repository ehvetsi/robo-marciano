FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Robo.Api/Robo.Api.csproj", "src/Robo.Api/"]
RUN dotnet restore "src/Robo.Api/Robo.Api.csproj"
COPY . .
WORKDIR "/src/src/Robo.Api"
RUN dotnet build "Robo.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Robo.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Robo.Api.dll"]