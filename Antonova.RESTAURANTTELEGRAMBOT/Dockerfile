#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Antonova.Bot/Antonova.Bot.csproj", "Antonova.Bot/"]
COPY ["Antonova.Core/Antonova.Core.csproj", "Antonova.Core/"]
RUN dotnet restore "Antonova.Bot/Antonova.Bot.csproj"
COPY . .
WORKDIR "/src/Antonova.Bot"
RUN dotnet build "Antonova.Bot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Antonova.Bot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNET_URLS=http://*:$PORT dotnet Antonova.Bot.dll