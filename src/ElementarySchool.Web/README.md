# Elementary School

## Get started with docker container

1. `docker build --pull -t elementary-school . `
2. `docker run --rm -it -p 8000:80 elementary-school --name elementary-school`

> 1. `dotnet dev-certs https --check --verbose`
> 2. `dotnet dev-certs https --clean`
> 3. `dotnet dev-certs https --check --verbose`
> 4. `dotnet dev-certs https -ep ${HOME}/.aspnet/https/elementary-school.pfx -p my_password_1234`
> 5. `dotnet dev-certs https --trust`
> 6. `dotnet dev-certs https --check --verbose`

HTTPS
5. `docker run --rm -it -p 8000:80 -p 8001:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=8001 -e ASPNETCORE_Kestrel__Certificates__Default__Password="my_password_1234" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/elementary-school.pfx -v ${HOME}/.aspnet/https:/https/ elementary-school`