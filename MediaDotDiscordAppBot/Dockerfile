FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MediaDotDiscordAppBot.csproj", "./"]
RUN dotnet restore "MediaDotDiscordAppBot.csproj"
COPY . .
RUN dotnet build "MediaDotDiscordAppBot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MediaDotDiscordAppBot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MediaDotDiscordAppBot.dll"]
