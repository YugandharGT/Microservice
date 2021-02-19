https://app.vsaex.visualstudio.com/me?mkt=en-US
References - https://www.tutorialspoint.com/object_oriented_analysis_design/ooad_uml_behavioural_diagrams.htm


Behavioral UML:
Sequence Diagram - https://app.creately.com/diagram/3Ib5hBJwoV9/edit
Use Case Diagram -
Activity Diagram -

Structural UML:
Component Diagram -
Class Diagram - 

http://localhost:52794/api/Restaurant/items?pageIndex=0&pageSize=4

Docker CMDs: c5549d4c5716
Note: Names are camelcase
1. docker pull {technology:version} e.g: docker pull microsoft/aspnetcore:2.0.0
2. docker pull {technology-build:version} e.g: microsoft/aspnetcore-build2.0.0
3. D:\Technology\Dotnet-Projects\VS19\Microservice\OrderMyFood\src\Services\RestaurantSearchApi
docker build -t {userdefined name} e.g:  docker build -t aspnetcoreapp . 


image: aspnetcoreapp
  build:
    context: .\src\Services\RestaurantSearchApi
	dockerfile: Dockerfile
  environment: 
      - ASPNETCORE_ENVIRONMENT=Development 
  container_name: RestaurantApi
    ports:
      - "5200:80"
    networks:
      - frontend 
    depends_on:
      - tokenserver




output:
PS C:\WINDOWS\system32> cd D:\Technology\Dotnet-Projects\VS19\Microservice\OrderMyFood
PS D:\Technology\Dotnet-Projects\VS19\Microservice\OrderMyFood> docker-compose build
mssqlserver uses an image, skipping
Building tokenserver
Step 1/11 : FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build-env
2.1: Pulling from dotnet/core/sdk
62239e9aa1a3: Pull complete                                                                                             35b1d061871c: Pull complete                                                                                             305fb6e3e382: Pull complete                                                                                             302d5f7d6434: Pull complete                                                                                             49c3849faefe: Pull complete                                                                                             9ac0aace5c0a: Pull complete                                                                                             9bdca2161138: Pull complete                                                                                             Digest: sha256:8bb207493e4e79ad5a7ed5f3c834f4792d6013100f89889126344c3543d98584
Status: Downloaded newer image for mcr.microsoft.com/dotnet/core/sdk:2.1
 ---> 66e64eba2805
Step 2/11 : WORKDIR /app
 ---> Running in 51e3b7a5e339
Removing intermediate container 51e3b7a5e339
 ---> 214ffd356d6f
Step 3/11 : COPY *.csproj ./
 ---> 126c1d800365
Step 4/11 : RUN dotnet restore
 ---> Running in 717340abc6e5
C:\Program Files\dotnet\sdk\2.1.812\Sdks\Microsoft.NET.Sdk\targets\Microsoft.NET.ObsoleteReferences.targets(33,5): warning NETSDK1059: The tool 'Microsoft.EntityFrameworkCore.Tools.DotNet' is now included in the .NET Core SDK. Information on resolving this warning is available at (https://aka.ms/dotnetclitools-in-box). [C:\app\TokenApi.csproj]
  Retrying 'FindPackagesByIdAsync' for source 'https://api.nuget.org/v3-flatcontainer/microsoft.visualstudio.web.codegeneration.design/index.json'.
  A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond
  Retrying 'FindPackagesByIdAsync' for source 'https://api.nuget.org/v3-flatcontainer/microsoft.visualstudio.web.codegeneration.design/index.json'.
  A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond
  Failed to download package 'IdentityServer4.2.0.0' from 'https://api.nuget.org/v3-flatcontainer/identityserver4/2.0.0/identityserver4.2.0.0.nupkg'.
  The download of 'https://api.nuget.org/v3-flatcontainer/identityserver4/2.0.0/identityserver4.2.0.0.nupkg' timed out because no data was received for 60000ms.
    Exception of type 'System.TimeoutException' was thrown.
C:\Program Files\dotnet\sdk\2.1.812\NuGet.targets(123,5): error : Failed to retrieve information about 'Microsoft.VisualStudio.Web.CodeGeneration.Design' from remote source 'https://api.nuget.org/v3-flatcontainer/microsoft.visualstudio.web.codegeneration.design/index.json'. [C:\app\TokenApi.csproj]
C:\Program Files\dotnet\sdk\2.1.812\NuGet.targets(123,5): error :   A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond [C:\app\TokenApi.csproj]
ERROR: Service 'tokenserver' failed to build : The command 'cmd /S /C dotnet restore' returned a non-zero code: 1

CONTAINER ID   IMAGE          COMMAND                  CREATED          STATUS                      PORTS     NAMES
717340abc6e5   126c1d800365   "cmd /S /C dotnet re…"   14 minutes ago   Exited (1) 11 minutes ago             suspicious_bell