dotnet dev-certs https --check --verbose
dotnet dev-certs https --clean
dotnet dev-certs https --check --verbose
dotnet dev-certs https -ep ${HOME}/.aspnet/https/elementary-school.pfx -p my_password_1234
dotnet dev-certs https --trust
dotnet dev-certs https --check --verbose