FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY Adapters/Drivers/DotLanches.Api/*.csproj ./Adapters/Drivers/DotLanches.Api/
COPY Adapters/Drivens/DotLanches.Infra/*.csproj ./Adapters/Drivers/DotLanches.Infra/
COPY Core/DotLanches.Application/*.csproj ./Core/DotLanches.Application/
COPY Core/DotLanches.Domain/*.csproj ./Core/DotLanches.Domain/
RUN dotnet restore "Adapters/Drivers/DotLanches.Api/DotLanches.Api.csproj"
COPY . .
RUN dotnet publish "Adapters/Drivers/DotLanches.Api/DotLanches.Api.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "DotLanches.Api.dll"]
