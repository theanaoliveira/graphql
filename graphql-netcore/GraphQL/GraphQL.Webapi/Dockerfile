FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["GraphQL.Webapi/GraphQL.Webapi.csproj", "GraphQL.Webapi/"]
RUN dotnet restore "GraphQL.Webapi/GraphQL.Webapi.csproj"
COPY . .
WORKDIR "/src/GraphQL.Webapi"
RUN dotnet build "GraphQL.Webapi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "GraphQL.Webapi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GraphQL.Webapi.dll"]
