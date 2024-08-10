# Import build statement environment variables
ARG IMAGE__BUILD_SOURCE=mcr.microsoft.com/dotnet/sdk
ARG IMAGE__BUILD_VERSION=8.0
ARG IMAGE__RUNTIME_SOURCE=mcr.microsoft.com/dotnet/aspnet
ARG IMAGE__RUNTIME_VERSION=8.0

# Create build environment container
FROM ${IMAGE__BUILD_SOURCE}:${IMAGE__BUILD_VERSION} AS build-env
WORKDIR /app

# Copy solution and project files to build environment
COPY ./*.sln ./

# Copy Platform, Services, and Views projects
COPY ./src/Platform/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p src/Platform/${file%.*}/ && mv $file src/Platform/${file%.*}/; done

COPY ./src/Services/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p src/Services/${file%.*}/ && mv $file src/Services/${file%.*}/; done


COPY ./src/Views/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p src/Views/${file%.*}/ && mv $file src/Views/${file%.*}/; done

# Copy everything else
COPY . ./

# Restore solution as distinct layers
RUN dotnet restore

# Build the application
RUN dotnet publish -c Release --no-restore --property:PublishDir=/app/out

# Create runtime environment container
FROM ${IMAGE__RUNTIME_SOURCE}:${IMAGE__RUNTIME_VERSION}
WORKDIR /app

# Copy output of build environment to runtime environment
COPY --from=build-env /app/out ./