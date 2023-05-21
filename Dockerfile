FROM mcr.microsoft.com/dotnet/sdk:7.0 AS StageLayer
WORKDIR /TestApp
COPY . .
WORKDIR /TestApp/TestApp.WebApi/
RUN dotnet publish "TestApp.WebApi.csproj" -c Release -r debian.10-x64 -o /out

FROM mcr.microsoft.com/dotnet/runtime:7.0
WORKDIR /app
COPY --from=StageLayer /out .
EXPOSE 80
ENTRYPOINT ["dotnet", "TestApp.WebApi.dll", "TestApp"]