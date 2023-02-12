# Back NetCore Api

## Deployment

Para iniciar el proyecto deben agregar su conexion a la BD PostgreSQL en  src\Api.Xilia.ApiService\appsettings . 
Ej:



```bash
   "ConnectionStrings": {
    "BaseDbContextConnectionString": "Server=localhost;Port=5432;Database=nombrebd;User Id=postgres;Password=contraseña;Integrated Security=true;Pooling=true;"
  }
```

luego deben correr las migraciones estando en la capa de dominio

```bash
  update-database
```

![](demoBack.gif)
