FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["ResourceBookingBackend.sln", "./"]
COPY ["ResourceBooking.API/ResourceBooking.API.csproj", "ResourceBooking.API/"]
COPY ["ResourceBooking.Data/ResourceBooking.Data.csproj", "ResourceBooking.Data/"]
COPY ["ResourceBooking.Services/ResourceBooking.Services.csproj", "ResourceBooking.Services/"]

RUN dotnet restore "ResourceBookingBackend.sln"

COPY . .
WORKDIR /src/ResourceBooking.API
RUN dotnet publish "ResourceBooking.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ResourceBooking.API.dll"]
