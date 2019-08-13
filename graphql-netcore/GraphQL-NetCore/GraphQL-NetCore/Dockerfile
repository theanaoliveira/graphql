FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["GraphQL-NetCore/GraphQL-NetCore.csproj", "GraphQL-NetCore/"]
RUN dotnet restore "GraphQL-NetCore/GraphQL-NetCore.csproj"
COPY . .
WORKDIR "/src/GraphQL-NetCore"
RUN dotnet build "GraphQL-NetCore.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "GraphQL-NetCore.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GraphQL-NetCore.dll"]
