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

# Copia apenas o projeto primeiro para aproveitar o cache das camadas
COPY ["Comaagora_API.csproj", "./"]
RUN dotnet restore "Comaagora_API.csproj"

# Copia o restante dos arquivos
COPY . .

# Remove a pasta .github para evitar que o compilador tente ler o YAML
RUN rm -rf .github

# Build com a flag para ignorar erros de Git (Invalid reference)
RUN dotnet build "Comaagora_API.csproj" -c $BUILD_CONFIGURATION -o /app/build /p:EnableSourceControlManagerQueries=false

# Estágio de Publicação
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
# O comando abaixo gera os arquivos finais para rodar a API
RUN dotnet publish "Comaagora_API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false /p:EnableSourceControlManagerQueries=false

# Estágio Final
FROM base AS final
WORKDIR /app
# Copia apenas o que foi publicado (arquivos leves)
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Comaagora_API.dll"]