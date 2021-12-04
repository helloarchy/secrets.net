FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["Secrets.Test/Secrets.Test.csproj", "Secrets.Test/"]
RUN dotnet restore "Secrets.Test/Secrets.Test.csproj"
COPY . .
WORKDIR "/src/Secrets.Test"
RUN dotnet build "Secrets.Test.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Secrets.Test.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Secrets.Test.dll"]
