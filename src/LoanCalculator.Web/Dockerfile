FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/LoanCalculator.Web/LoanCalculator.Web.csproj", "src/LoanCalculator.Web/"]
RUN dotnet restore "src/LoanCalculator.Web/LoanCalculator.Web.csproj"
COPY . .
WORKDIR "/src/src/LoanCalculator.Web"
RUN dotnet build "LoanCalculator.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LoanCalculator.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LoanCalculator.Web.dll"]
