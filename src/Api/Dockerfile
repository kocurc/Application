# https://mcr.microsoft.com/en-us/artifact/mar/dotnet/sdk/tag/9.0
FROM mcr.microsoft.com/dotnet/sdk@sha256:123b43e4d9775451d8ed63af324a42132707b4edb14770bcdf5c85cf55bc45f1 AS build

WORKDIR /src

COPY Directory.Build.props ./
COPY Directory.Build.targets ./
COPY global.json ./
COPY src/Api/Api.csproj Api/
COPY src/CleanArchitecture/Domain/Domain.csproj CleanArchitecture/Domain/
COPY src/CleanArchitecture/Infrastructure/Infrastructure.csproj CleanArchitecture/Infrastructure/
COPY src/CleanArchitecture/Application/Application.csproj CleanArchitecture/Application/

# Download NuGet packages. It creates obj folder with project.assets.json with the list of downloaded dependencies
RUN dotnet restore Api/Api.csproj

COPY src/Api/ Api/
COPY src/CleanArchitecture/ CleanArchitecture/

WORKDIR /src/Api

RUN dotnet publish --configuration Release --output /publish

# RUNTIME STAGE, It creates new file system that weighs less than previous stage
# https://mcr.microsoft.com/en-us/artifact/mar/dotnet/aspnet/tag/9.0
FROM mcr.microsoft.com/dotnet/aspnet@sha256:366204b1d249aa2615f4942c8549677a1f3e6231829f274aa8829fc048f38d8c AS final

WORKDIR /

COPY --from=build /publish ./

EXPOSE 5000

ENTRYPOINT [ "dotnet", "Api.dll" ]
