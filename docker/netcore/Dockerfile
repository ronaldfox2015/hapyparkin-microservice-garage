FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copiar archivos del proyecto y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar y construir la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa de construcción final
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "NombreDeTuProyecto.dll"]