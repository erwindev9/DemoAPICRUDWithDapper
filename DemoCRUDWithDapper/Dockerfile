FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["DemoCRUDWithDapper.csproj", "."]
RUN dotnet restore "./DemoCRUDWithDapper.csproj"

COPY . .
RUN dotnet publish "DemoCRUDWithDapper.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "DemoCRUDWithDapper.dll"]