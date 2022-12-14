#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5000
EXPOSE 5001
ENV ASPNETCORE_URLS=http://+:5001


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BackendApi/BackendApi.csproj", "BackendApi/"]
RUN dotnet restore "BackendApi/BackendApi.csproj"
COPY . .
WORKDIR "/src/BackendApi"
RUN dotnet build "BackendApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackendApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackendApi.dll"]