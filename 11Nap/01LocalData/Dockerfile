FROM microsoft/dotnet:sdk AS buildenv
WORKDIR /app

COPY *.csproj ./

RUN dotnet restore

COPY . ./

RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app

COPY --from=buildenv /app/out .

ENTRYPOINT ["dotnet", "01LocalData.dll"]