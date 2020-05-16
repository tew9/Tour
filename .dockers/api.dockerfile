FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app
COPY . .

RUN dotnet build 
RUN dotnet publish -c Release -o out **/Tour.WebApi.csproj

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /www
COPY --from=build /app/out/ .
CMD ["dotnet", "Tour.WebApi.dll"]
