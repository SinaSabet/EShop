# از تصویر aspnet برای مرحله پایه استفاده کنید
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# از تصویر sdk برای مرحله ساخت استفاده کنید
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["/EShop.Api/EShop.Api.csproj", "EShop.Api/"]
COPY ["/EShop.Application/EShop.Application.csproj", "EShop.Application/"]
COPY ["/EShop.Domain/EShop.Domain.csproj", "EShop.Domain/"]
COPY ["/EShop.Infrastructure/EShop.Infrastructure.csproj", "EShop.Infrastructure/"]
RUN dotnet restore "EShop.Api/EShop.Api.csproj"
COPY . .
WORKDIR "/src/EShop.Api"
RUN dotnet build "./EShop.Api.csproj" -c %BUILD_CONFIGURATION% -o /app/build

# مرحله انتشار
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EShop.Api.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

# مرحله نهایی
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EShop.Api.dll"]
