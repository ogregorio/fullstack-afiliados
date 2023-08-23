# Define the base image to start from
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

# Set the working directory inside the container
WORKDIR /app

# Expose ports 80 and 443 to the outside world
EXPOSE 80
EXPOSE 443

# Define the base image for building
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory inside the container for building
WORKDIR /src

# Copy project files into the container
COPY ["FullstackAfiliados.Api/FullstackAfiliados.Api.csproj", "FullstackAfiliados.Api/"]
COPY ["FullstackAfiliados.Application/FullstackAfiliados.Application.csproj", "FullstackAfiliados.Application/"]
COPY ["FullstackAfiliados.Domain/FullstackAfiliados.Domain.csproj", "FullstackAfiliados.Domain/"]
COPY ["FullstackAfiliados.Infra.Data/FullstackAfiliados.Infra.Data.csproj", "FullstackAfiliados.Infra.Data/"]
COPY ["FullstackAfiliados.Infra.CrossCutting.Commons/FullstackAfiliados.Infra.CrossCutting.Commons.csproj", "FullstackAfiliados.Infra.CrossCutting.Commons/"]
COPY ["FullstackAfiliados.Infra.CrossCutting.IoC/FullstackAfiliados.Infra.CrossCutting.IoC.csproj", "FullstackAfiliados.Infra.IoC/"]
COPY ["FullstackAfiliados.Infra.CrossCutting.Auth/FullstackAfiliados.Infra.CrossCutting.Auth.csproj", "FullstackAfiliados.Infra.CrossCutting.Auth/"]

# Restore project dependencies
RUN dotnet restore "FullstackAfiliados.Api/FullstackAfiliados.Api.csproj"

# Copy the rest of the project files into the container
COPY . .

# Set the working directory for the API inside the container
WORKDIR "/src/FullstackAfiliados.Api"

# Set environment variables used by the application
ENV DATABASE_HOST $DATABASE_HOST
ENV DATABASE_USER $DATABASE_USER
ENV DATABASE_PORT $DATABASE_PORT
ENV SYSTEM_USERNAME $SYSTEM_USERNAME
ENV SYSTEM_PASSWORD $SYSTEM_PASSWORD
ENV DATABASE_PASSWORD $DATABASE_PASSWORD
ENV ASPNETCORE_URLS $ASPNETCORE_URLS
ENV ASPNETCORE_ENVIRONMENT $ASPNETCORE_ENVIRONMENT
ENV JWT_SECRET $JWT_SECRET

# Build the project
RUN dotnet build "FullstackAfiliados.Api.csproj" -c Release -o /app/build

# Define the publish stage
FROM build AS publish
RUN dotnet publish "FullstackAfiliados.Api.csproj" -c Release -o /app/publish

# Define the final image to be used for running the application
FROM base AS final

# Set the working directory inside the container
WORKDIR /app

# Copy the published files from the publish stage into the final container
COPY --from=publish /app/publish .

# Define the entry command for the container, which starts the application
ENTRYPOINT ["dotnet", "FullstackAfiliados.Api.dll"]
