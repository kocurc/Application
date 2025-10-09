# https://mcr.microsoft.com/en-us/artifact/mar/dotnet/sdk/tags 10.0
FROM mcr.microsoft.com/dotnet/sdk@sha256:eee11b0bf11715710bbe8339b9641f0ef8b5d8a8e07f2d6ff3cd4361c1a4e5a7 AS build

WORKDIR /src

COPY src/Api/Api.csproj /Api
COPY src/CleanArchitecture/Domain/Domain.csproj CleanArchitecture/Domain
COPY src/CleanArchitecture/Infrastructure/Infrastructure.csproj CleanArchitecture/Inftrastructure
COPY src/CleanArchitecture/Application/Application.csproj CleanArchitecture/Application

# Download NuGet packages. It creates obj folder with project.assets.json with the list of downloaded dependencies
RUN dotnet restore Api/Api.csproj

COPY src/Api/ Api/
COPY src/CleanArchitecture/ CleanArchitecture/

WORKDIR src/Api

RUN dotnet publish --configuration Release --output /publish

# RUNTIME STAGE, It creates new file system that weighs less than previous stage
# https://mcr.microsoft.com/en-us/artifact/mar/dotnet/aspnet/tags 10.0
FROM mcr.microsoft.com/dotnet/aspnet@sha256:d9a0d4006dbbc14d877b00c5e7113b432bac6bca6d12816a6e8fd999bac72797 AS final

WORKDIR /

COPY --from=build /publish ./

EXPOSE 5000

ENTRYPOINT [ "dotnet", "Api.dll" ]
