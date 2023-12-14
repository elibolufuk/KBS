#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/CreditAppSys/Web/KBS.CreditAppSys.Web.Api/KBS.CreditAppSys.Web.Api.csproj", "src/CreditAppSys/Web/KBS.CreditAppSys.Web.Api/"]
COPY ["src/CreditAppSys/Source/KBS.CreditAppSys.Persistence/KBS.CreditAppSys.Persistence.csproj", "src/CreditAppSys/Source/KBS.CreditAppSys.Persistence/"]
COPY ["src/CreditAppSys/Source/KBS.CreditAppSys.Application/KBS.CreditAppSys.Application.csproj", "src/CreditAppSys/Source/KBS.CreditAppSys.Application/"]
COPY ["src/CreditAppSys/Source/KBS.CreditAppSys.Domain/KBS.CreditAppSys.Domain.csproj", "src/CreditAppSys/Source/KBS.CreditAppSys.Domain/"]
RUN dotnet restore "./src/CreditAppSys/Web/KBS.CreditAppSys.Web.Api/./KBS.CreditAppSys.Web.Api.csproj"
COPY . .
WORKDIR "/src/src/CreditAppSys/Web/KBS.CreditAppSys.Web.Api"
RUN dotnet build "./KBS.CreditAppSys.Web.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./KBS.CreditAppSys.Web.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KBS.CreditAppSys.Web.Api.dll"]