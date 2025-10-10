# https://mcr.microsoft.com/en-us/artifact/mar/dotnet/sdk/tags 10.0
FROM mcr.microsoft.com/dotnet/sdk@sha256:eee11b0bf11715710bbe8339b9641f0ef8b5d8a8e07f2d6ff3cd4361c1a4e5a7 AS build

WORKDIR /src

COPY src/Blazor/Blazor.csproj Blazor/

# Download NuGet packages. It creates obj folder with project.assets.json with the list of downloaded dependencies
RUN dotnet restore Blazor/Blazor.csproj

COPY Directory.Build.props ./
COPY Directory.Build.targets ./
COPY src/Blazor/ Blazor/

WORKDIR /src/Blazor

RUN dotnet publish --configuration Release --output /publish

# RUNTIME STAGE, It creates new file system that weighs less than previous stage
# https://hub.docker.com/_/nginx stable-alpine
FROM nginx:alpine@sha256:91786fc3554a00f445f9639d4f21a8564b6fd4f1ad39d17ed32f00faae24bc7c AS final

COPY --from=build /src/Blazor/publish/wwwroot /usr/share/nginx/html

EXPOSE 80
