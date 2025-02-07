FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build

WORKDIR /src

ARG BUILD_TAG=0.0.0
ARG BUILD_NUMBER=0

COPY ["Directory.Packages.props", "./"]
COPY ["Api/Host/*.csproj", "Host/"]
COPY ["Api/Services/Contracts/*.csproj", "Services/Contracts/"]
COPY ["Api/Services/Implimentation/*.csproj", "Services/Implimentation/"]
COPY ["Api/Repositories/Implimentation/*.csproj", "Repositories/Implimentation/"]
COPY ["Api/Repositories/Contracts/*.csproj", "Repositories/Contracts/"]

RUN dotnet restore "Host/Bjay.Api.Host.csproj"

COPY Api/ .
RUN dotnet publish "Host/Bjay.Api.Host.csproj" \
    -c Release \
    -o /app/publish \
    /p:Version="${BUILD_TAG}.${BUILD_NUMBER}"

FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine

WORKDIR /app

RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "Bjay.Api.Host.dll"]