FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /

# Copy csproj and restore as distinct layers
COPY ./server/BitBoard.sln .
COPY ./server/BitBoard.Web/BitBoard.Web.csproj ./
RUN dotnet restore BitBoard.Web.csproj

# Copy everything else and build website
COPY ./server/BitBoard.Web/. ./
WORKDIR /
RUN dotnet publish BitBoard.Web.csproj -c release -o /DockerOutput/Website --no-restore

# Final stage / image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /DockerOutput/Website
COPY --from=build /DockerOutput/Website ./
ENTRYPOINT ["dotnet", "BitBoard.Web.dll"]