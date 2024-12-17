# smart-test


DotNet version: 8.0.206

### Configuración inicial

Replace the database connnection string in the file *appsettings.Development.json* locate in the path `.\Api`

```
"ConnectionStrings": {
    "ConnectionDb": "Nueva_Cadena_Conexion"
  }
```

### Ejecutar migraciones
In the console line get inside in the folder a the same level of the project `.\`  and execute the next command:
```
backend>dotnet ef database update -s Api -p Persistence
```
If the database connection is successful the tables should be created that were defined by the migrations.

### Ejecutar aplicación
In the command line get inside the folder `.\Api` of the project and execute the next command:
```
backend>dotnet run
```
The application run en the port `7036`

### Endpoints
The folder `Endpoints` containts a Postman collection of the endpoints created in the project
