FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BaseballHistory.API/BaseballHistory.API.csproj", "BaseballHistory.API/"]
RUN dotnet restore "BaseballHistory.API/BaseballHistory.API.csproj"
COPY . .
WORKDIR "/src/BaseballHistory.API"
RUN dotnet build "BaseballHistory.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BaseballHistory.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BaseballHistory.API.dll"]
