# API EXCHANGE CAMBIO DE DIVISAS
https://www.exchangerate-api.com/ 

# Comandos para .NET 
## Crear un nuevo proyecto de consola
dotnet new console -o App -n DotNet.Docker

## Compilar en Debug
dotnet build

## Ejecutar la app
dotnet run -- 100 EUR

## Publicar en Release
dotnet publish -c Release 
o 
dotnet publish DotNet.Docker.csproj -c Release

# Comandos para Docker
## Construir la imagen (usa el Dockerfile)
docker build -t dotnet-docker-app .

## Ejecutar la imagen como contenedor
docker run --rm dotnet-docker-app

## Ejecutar con argumentos (ejemplo: convertir 100 USD a EUR)
docker run --rm dotnet-docker-app 100 EUR

## Guardar la imagen en un archivo .tar
docker save -o dotnet-docker-app.tar dotnet-docker-app

## Cargar una imagen desde un archivo .tar
docker load -i dotnet-docker-app.tar
