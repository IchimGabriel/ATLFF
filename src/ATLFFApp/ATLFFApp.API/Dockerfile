FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["ATLFFApp.API/ATLFFApp.API.csproj", "ATLFFApp.API/"]
RUN dotnet restore "ATLFFApp.API/ATLFFApp.API.csproj"
COPY . .
WORKDIR "/src/ATLFFApp.API"
RUN dotnet build "ATLFFApp.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ATLFFApp.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ATLFFApp.API.dll"]