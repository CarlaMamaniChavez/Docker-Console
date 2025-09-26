FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /App

COPY *.csproj ./
RUN dotnet restore "DotNet.Docker.csproj"

COPY . ./
RUN dotnet publish "DotNet.Docker.csproj" -c Release -o /App/out

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /App
COPY --from=build /App/out .
ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]
