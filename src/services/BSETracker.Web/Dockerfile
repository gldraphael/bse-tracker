FROM microsoft/dotnet:2.1.2-aspnetcore-runtime-alpine AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1.400-sdk-alpine AS build
WORKDIR /src
COPY docker-compose.dcproj .
COPY global.json .
COPY bse-tracker.sln .
COPY src/BSETracker.Web/BSETracker.Web.csproj src/BSETracker.Web/
RUN dotnet restore -nowarn:msb3202,nu1503 bse-tracker.sln
COPY . .
WORKDIR /src/src/BSETracker.Web
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BSETracker.Web.dll"]
