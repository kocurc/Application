# BUILD STAGE WITH .NET 9.0
FROM mcr.microsoft.com/dotnet/sdk@sha256:9b0a4330cb3dac23ebd6df76ab4211ec5903907ad2c1ccde16a010bf25f8dfde AS build
WORKDIR /api

COPY ApplicationApi.csproj ./
# Download NuGet packages. It creates obj folder with project.assets.json with the list of downloaded depenedencies
RUN dotnet restore

COPY . ./
RUN dotnet publish --configuration Release --output ./publish

# RUNTIME STAGE, It creates new file system that weighs less than previous stage
FROM mcr.microsoft.com/dotnet/aspnet@sha256:c3aee4ea4f51369d1f906b4dbd19b0f74fd34399e5ef59f91b70fcd332f36566 AS final
WORKDIR /api

COPY --from=build /api/publish ./
EXPOSE 5000
ENTRYPOINT [ "dotnet", "ApplicationApi.dll" ]
