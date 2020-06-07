FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as lelele
WORKDIR /app
COPY *.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish FluentValidationsApp.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=lelele /app/out .
ENV ASPNETCORE_URLS="http://*:4999"
ENV FluentDbCon="Data Source=.;Initial Catalog=FluentDB;Integrated Security=true;Connect Timeout=33"
ENV ASPNETCORE_ENVIRONMENT="DEVELOPMENT"
ENTRYPOINT ["dotnet","FluentValidationsApp.dll"]