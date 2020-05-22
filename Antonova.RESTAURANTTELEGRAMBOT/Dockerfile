FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Antonova.KennyWest/Antonova.KennyWest.csproj", "Antonova.KennyWest/"]
COPY ["Antonova.Core/Antonova.Core.csproj", "Antonova.Core/"]
RUN dotnet restore "Antonova.KennyWest/Antonova.KennyWest.csproj"
COPY . .
WORKDIR "/src/Antonova.KennyWest"
RUN dotnet build "Antonova.KennyWest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Antonova.KennyWest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Antonova.KennyWest.dll