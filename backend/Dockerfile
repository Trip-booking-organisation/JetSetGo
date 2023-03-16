FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["JetSetGo.Api/JetSetGo.Api.csproj", "JetSetGo.Api/"]
COPY ["JetSetGo.Application/JetSetGo.Application.csproj", "JetSetGo.Application/"]
COPY ["JetSetGo.Domain/JetSetGo.Domain.csproj", "JetSetGo.Domain/"]
COPY ["JetSetGo.Infrastructure/JetSetGo.Infrastructure.csproj", "JetSetGo.Infrastructure/"]
RUN dotnet restore "JetSetGo.Api/JetSetGo.Api.csproj"
COPY . .
WORKDIR "/src/JetSetGo.Api"
RUN dotnet build "JetSetGo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JetSetGo.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JetSetGo.Api.dll"]
