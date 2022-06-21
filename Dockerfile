from mcr.microsoft.com/dotnet/aspnet:6.0 as runtime

workdir /app
copy /publish ./

#Entrypoint to set that PokeApi.dll assembly will be our default entrypoint
entrypoint ["dotnet", "shopApi.dll"]

#Expose to port 5000
expose 5000

env ASPNETCORE_URL=http://+:5000

