FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY . ./
RUN dotnet restore

RUN dotnet publish -c Release -o out

EXPOSE 5000

WORKDIR /app/src/Blockchain.Api/bin/Release/netcoreapp3.1/
ENTRYPOINT ["dotnet", "Blockchain.Api.dll"]