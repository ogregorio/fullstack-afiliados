FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FullstackAfiliados.Api/FullstackAfiliados.Api.csproj", "FullstackAfiliados.Api/"]
RUN dotnet restore "FullstackAfiliados.Api/FullstackAfiliados.Api.csproj"
COPY . .
WORKDIR "/src/FullstackAfiliados.Api"
RUN dotnet build "FullstackAfiliados.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FullstackAfiliados.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FullstackAfiliados.Api.dll"]
