# use windows server 2022 .net core 7 base image
FROM mcr.microsoft.com/dotnet/sdk:7.0-windowsservercore-ltsc2022 AS build

# set working directory
WORKDIR /app

# build this project
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

# build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0-windowsservercore-ltsc2022 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "AzureRedisConsoleApp.dll"]








