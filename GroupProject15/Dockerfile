#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["GroupProject15/GroupProject15.csproj", "GroupProject15/"]
RUN dotnet restore "GroupProject15/GroupProject15.csproj"
COPY . .
WORKDIR "/src/GroupProject15"
RUN dotnet build "GroupProject15.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GroupProject15.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GroupProject15.dll"]
