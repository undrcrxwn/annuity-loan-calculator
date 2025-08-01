﻿FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY /src .
RUN dotnet restore "LoanCalculator.Web/LoanCalculator.Web.csproj"
RUN dotnet publish "LoanCalculator.Web/LoanCalculator.Web.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "LoanCalculator.Web.dll"]