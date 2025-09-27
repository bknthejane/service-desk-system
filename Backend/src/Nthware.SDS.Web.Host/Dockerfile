FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/Nthware.SDS.Web.Host/Nthware.SDS.Web.Host.csproj", "src/Nthware.SDS.Web.Host/"]
COPY ["src/Nthware.SDS.Web.Core/Nthware.SDS.Web.Core.csproj", "src/Nthware.SDS.Web.Core/"]
COPY ["src/Nthware.SDS.Application/Nthware.SDS.Application.csproj", "src/Nthware.SDS.Application/"]
COPY ["src/Nthware.SDS.Core/Nthware.SDS.Core.csproj", "src/Nthware.SDS.Core/"]
COPY ["src/Nthware.SDS.EntityFrameworkCore/Nthware.SDS.EntityFrameworkCore.csproj", "src/Nthware.SDS.EntityFrameworkCore/"]
WORKDIR "/src/src/Nthware.SDS.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/Nthware.SDS.Web.Host", "src/Nthware.SDS.Web.Host"]
COPY ["src/Nthware.SDS.Web.Core", "src/Nthware.SDS.Web.Core"]
COPY ["src/Nthware.SDS.Application", "src/Nthware.SDS.Application"]
COPY ["src/Nthware.SDS.Core", "src/Nthware.SDS.Core"]
COPY ["src/Nthware.SDS.EntityFrameworkCore", "src/Nthware.SDS.EntityFrameworkCore"]
WORKDIR "/src/src/Nthware.SDS.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "Nthware.SDS.Web.Host.dll"]
