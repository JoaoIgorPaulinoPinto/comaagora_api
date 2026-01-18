# 1. Estágio de Execução (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# 2. Estágio de Compilação (SDK)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia o arquivo de projeto usando o caminho relativo à raiz do repositório
COPY ["Comaagora_API/Comaagora_API.csproj", "Comaagora_API/"]
RUN dotnet restore "Comaagora_API/Comaagora_API.csproj"

# Copia todo o conteúdo do repositório para o container
COPY . .

# ENTRA na pasta onde o arquivo .csproj realmente está para buildar
WORKDIR "/src/Comaagora_API"
RUN dotnet build "Comaagora_API.csproj" -c $BUILD_CONFIGURATION -o /app/build /p:EnableSourceControlManagerQueries=false

# 3. Estágio de Publicação
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Comaagora_API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false /p:EnableSourceControlManagerQueries=false

# 4. Estágio Final (Imagem leve para produção)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Comaagora_API.dll"]