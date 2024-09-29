# Imagen base para el runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Imagen base para construir el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia de archivos de proyecto
COPY ["src/MySimpleLayeredApi.Api/MySimpleLayeredApi.Api.csproj", "MySimpleLayeredApi.Api/"]
COPY ["src/MySimpleLayeredApi.Entities/MySimpleLayeredApi.Entities.csproj", "MySimpleLayeredApi.Entities/"]
COPY ["src/MySimpleLayeredApi.Persistence/MySimpleLayeredApi.Persistence.csproj", "MySimpleLayeredApi.Persistence/"]

# Restauración de dependencias
RUN dotnet restore "MySimpleLayeredApi.Api/MySimpleLayeredApi.Api.csproj"

# Copia del resto del código
COPY ./src .

# Build del proyecto
WORKDIR "/src/MySimpleLayeredApi.Api"
RUN dotnet build "MySimpleLayeredApi.Api.csproj" -c Release -o /app/build

# Publicar el resultado
FROM build AS publish
RUN dotnet publish "MySimpleLayeredApi.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagen final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MySimpleLayeredApi.Api.dll"]