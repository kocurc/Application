# BUILD STAGE WITH .NET 9.0
FROM mcr.microsoft.com/dotnet/sdk@sha256:9b0a4330cb3dac23ebd6df76ab4211ec5903907ad2c1ccde16a010bf25f8dfde  AS build
WORKDIR /blazor

COPY ApplicationBlazor.csproj ./
# Download NuGet packages. It creates obj folder with project.assets.json with the list of downloaded depenedencies
RUN dotnet restore

COPY . ./
RUN dotnet publish --configuration Release --output ./publish

# RUNTIME STAGE, It creates new file system that weighs less than previous stage
FROM nginx:alpine@sha256:65645c7bb6a0661892a8b03b89d0743208a18dd2f3f17a54ef4b76fb8e2f2a10 as final
COPY --from=build ./publish/wwwroot /usr/share/nginx/html
EXPOSE 80
