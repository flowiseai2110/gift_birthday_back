#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WEB.API.ECOMMERCE/WEB.API.ECOMMERCE.csproj", "WEB.API.ECOMMERCE/"]
COPY ["Web.Api.Domain/Web.Api.Domain.csproj", "Web.Api.Domain/"]
COPY ["Web.Api.Dto/Web.Api.Dto.csproj", "Web.Api.Dto/"]
COPY ["Web.Api.Infraestructure/Web.Api.Infraestructure.csproj", "Web.Api.Infraestructure/"]
COPY ["Web.Api.Interface/Web.Api.Interface.csproj", "Web.Api.Interface/"]
COPY ["Web.Api.Persistence/Web.Api.Persistence.csproj", "Web.Api.Persistence/"]
COPY ["Web.Api.UseCases/Web.Api.UseCases.csproj", "Web.Api.UseCases/"]

RUN dotnet restore "./WEB.API.ECOMMERCE/WEB.API.ECOMMERCE.csproj"
RUN dotnet restore "./Web.Api.Domain/Web.Api.Domain.csproj"
RUN dotnet restore "./Web.Api.Dto/Web.Api.Dto.csproj"
RUN dotnet restore "./Web.Api.Infraestructure/Web.Api.Infraestructure.csproj"
RUN dotnet restore "./Web.Api.Interface/Web.Api.Interface.csproj"
RUN dotnet restore "./Web.Api.Persistence/Web.Api.Persistence.csproj"
RUN dotnet restore "./Web.Api.UseCases/Web.Api.UseCases.csproj"

COPY . .
WORKDIR "/src/WEB.API.ECOMMERCE/"
RUN dotnet build "./WEB.API.ECOMMERCE.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WEB.API.ECOMMERCE.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WEB.API.ECOMMERCE.dll"]