FROM microsoft/dotnet:2.1.2-aspnetcore-runtime-alpine AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1.400-sdk-alpine AS build
WORKDIR /src
COPY bse-tracker.sln .
COPY BSETracker.Web.csproj .
RUN dotnet restore -v quiet bse-tracker.sln
COPY . .
RUN dotnet build -c Release -o /app BSETracker.Web.csproj

FROM build AS publish
RUN dotnet publish -c Release -o /app -v quiet BSETracker.Web.csproj

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BSETracker.Web.dll"]
