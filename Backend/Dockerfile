FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["NuGet.Config", "."]
COPY ["src/Nthware.SDS.Web.Host/Nthware.SDS.Web.Host.csproj", "src/Nthware.SDS.Web.Host/"]
COPY ["src/Nthware.SDS.Application/Nthware.SDS.Application.csproj", "src/Nthware.SDS.Application/"]
COPY ["src/Nthware.SDS.EntityFrameworkCore/Nthware.SDS.EntityFrameworkCore.csproj", "src/Nthware.SDS.EntityFrameworkCore/"]
COPY ["src/Nthware.SDS.Core/Nthware.SDS.Core.csproj", "src/Nthware.SDS.Core/"]
COPY ["src/Nthware.SDS.Web.Core/Nthware.SDS.Web.Core.csproj", "src/Nthware.SDS.Web.Core/"]

RUN dotnet restore "src/Nthware.SDS.Web.Host/Nthware.SDS.Web.Host.csproj"

COPY . .
WORKDIR /src/src/Nthware.SDS.Web.Host
RUN dotnet build "Nthware.SDS.Web.Host.csproj" -c "$BUILD_CONFIGURATION" -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
WORKDIR /src/src/Nthware.SDS.Web.Host
RUN dotnet publish "Nthware.SDS.Web.Host.csproj" -c "$BUILD_CONFIGURATION" -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nthware.SDS.Web.Host.dll"]