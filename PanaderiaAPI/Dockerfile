FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["PanaderiaAPI.csproj", "./"]
RUN dotnet restore "PanaderiaAPI.csproj"
COPY . .
RUN dotnet publish "PanaderiaAPI.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PanaderiaAPI.dll"]