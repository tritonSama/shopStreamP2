# from mcr.microsoft.com/dotnet/sdk:6.0 as build

# workdir /app 


# copy *.sln ./
# copy shopAPI/*.csproj shopApi/
# copy shopBL/*.csproj shopBL/
# copy shopDL/*.csproj shopDL/
# copy shopModel/*.csproj shopModel/
# copy shopTest/*.csproj shopTest/

# copy . ./

# run dotnet build

# run dotnet publish -c Release -o publish  

# from mcr.microsoft.com/dotnet/aspnet:6.0 as runtime


# workdir /app copy --from=build /app/publish ./
# cmd ["dotnet", "shopApi.dll"]

# expose 80

# # docker build -t tritonsama/[Your App Name]:[Current version] .
# # docker run -d -p 5000:80 -t [PUT Image name here]


from mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
workdir /app
copy / publish./


#Entrypoint to set that PokeApi.dll assembly will be our default entrypoint
entrypoint ["dotnet", "PokeApi.dll"]

#Expose to port 5000
expose 5000

#Changes the port from the runtime image to listen to 5000 (since by default it uses port 80)
env ASPNETCORE_URLS=http://+:5000
