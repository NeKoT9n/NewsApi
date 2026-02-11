FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NewsApi/NewsApi.csproj", "NewsApi/"]
COPY ["NewsApi.DataAccess/NewsApi.DataAccess.csproj", "NewsApi.DataAccess/"]
COPY ["NewsApi.Domain/NewsApi.Domain.csproj", "NewsApi.Domain/"]
COPY ["NewsApi.Application/NewsApi.Application.csproj", "NewsApi.Application/"]
RUN dotnet restore "NewsApi/NewsApi.csproj"
COPY . .
WORKDIR "/src/NewsApi"
RUN dotnet build "./NewsApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NewsApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NewsApi.dll"]
