
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DandDCompany.csproj", "."]
RUN dotnet restore "./DandDCompany.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "DandDCompany.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DandDCompany.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DandDCompany.dll"]