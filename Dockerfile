FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Blockchain.Api/Blockchain.Api.csproj", "app/"]
COPY ["src/Blockchain.Core/Blockchain.Core.csproj", "app/"]
COPY ["src/Blockchain.Domain/Blockchain.Domain.csproj", "app/"]
COPY ["src/Blockchain.Infrastructure/Blockchain.Infrastructure.csproj", "app/"]
RUN dotnet restore "app/Blockchain.Api.csproj"
RUN dotnet restore "app/Blockchain.Core.csproj"
RUN dotnet restore "app/Blockchain.Domain.csproj"
RUN dotnet restore "app/Blockchain.Infrastructure.csproj"
COPY . .
WORKDIR /src/src/Blockchain.Api
RUN dotnet build "Blockchain.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Blockchain.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blockchain.Api.dll"]