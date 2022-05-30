FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UnitTesting/UnitTesting.csproj", "UnitTesting/"]
RUN dotnet restore "UnitTesting/UnitTesting.csproj"
COPY . .
WORKDIR "/src/UnitTesting"
RUN dotnet build "UnitTesting.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UnitTesting.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UnitTesting.dll"]
