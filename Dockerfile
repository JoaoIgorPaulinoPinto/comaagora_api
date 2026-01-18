# Estágio de Execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Estágio de Compilação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# COPIA DIRETA: O arquivo está na raiz do contexto
COPY ["Comaagora_API.csproj", "./"]
RUN dotnet restore "Comaagora_API.csproj"

# Copia o restante (Program.cs, appsettings.json, pasta src, etc)
COPY . .

# Build direto no diretório atual
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