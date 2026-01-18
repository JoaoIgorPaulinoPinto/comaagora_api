# Estágio de Execução (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Estágio de Compilação (SDK)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# AJUSTE AQUI: O caminho do arquivo .csproj em relação à raiz do repositório
COPY ["Comaagora_API/Comaagora_API.csproj", "Comaagora_API/"]
RUN dotnet restore "Comaagora_API/Comaagora_API.csproj"

# Copia tudo da raiz para dentro de /src no container
COPY . .

# Muda o diretório de trabalho para onde está o projeto antes do build
WORKDIR "/src/Comaagora_API"

RUN dotnet build "Comaagora_API.csproj" -c $BUILD_CONFIGURATION -o /app/build /p:EnableSourceControlManagerQueries=false

# Estágio de Publicação
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Comaagora_API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false /p:EnableSourceControlManagerQueries=false

# Estágio Final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Comaagora_API.dll"]