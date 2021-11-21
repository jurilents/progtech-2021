# First stage
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

# Copy csproj and restore as distinct layers
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./ElementarySchool.Web.csproj"
RUN dotnet build "ElementarySchool.Web.csproj" -c Release -o /app/build

# Copy everything else and build website
FROM build AS publish
RUN dotnet publish "ElementarySchool.Web.csproj" -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ElementarySchool.Web.dll"]