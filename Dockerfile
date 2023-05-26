# Utiliza la imagen base de .NET Core
FROM mcr.microsoft.com/dotnet/sdk:7.0

# Copia los archivos del proyecto al contenedor
COPY . /app

# Establece el directorio de trabajo
WORKDIR /app

# Restaura las dependencias del proyecto
RUN dotnet restore

# Expone el puerto 5000 para el servidor web de ASP.NET
EXPOSE 5000

# Inicia la aplicación ASP.NET
CMD ["dotnet", "run"]
