# eximicion

# Backend de INAISO - Guía de Uso

## Requisitos Previos

Antes de comenzar, asegúrate de tener instalado lo siguiente:


1. **Git:** Se debe tener Git instalado para poder clonar el repositorio desde github, el link es el siguiente: https://git-scm.com/downloads

2. **Editor de Código:** Se debe utilizar un editor de código. La aplicación fue desarrollada en VS Code.

## Instrucciones de Uso

### 1. Clonar el Repositorio

Primero, clona este repositorio en tu máquina local utilizando el siguiente comando de Git:

```bash
git clone https://github.com/GSGEdgardo/eximicion.git
```

### 2. Se debe ingresar al repositorio 
correr en la consola el comando: "cd BackendINAISO"

### 3. Se deben restaurar las dependencias

Para eso se debe ejecutar el comando 'dotnet restore'

### 4. Base de datos

La aplicación está utilizando SQLite, la conexión Default está en el appsettings.json y la base de datos se llama "miBaseDeDatos.db"
aquí es como se ve:  "DefaultConnection": "Data Source=miBaseDeDatos.db"

### 5. Aplicar migraciones

Se deben aplicar las migraciones con el comando: 'dotnet ef database update'
Con esto se aplicarán todos los datos semilla y las configuraciones de la base de datos

### 6. Ejecutar la aplicación

La aplicación está construida en .NET, como ya se ejecutó las dependencias con el 'dotnet restore' ahora solo queda utilizar 'dotnet run' para poder ejecutar la aplicación.

### 7. Como utilizar los endpoints

La aplicación al ejecutarse soltará cuatro bloques de información en la consola, en el primero de ellos aparece el localhost el cual es http://localhost:5099, para poder utilizarlo se puede:

-> Usar herramientas como Postman y utilizar el localhost junto a la petición, por ejemplo: http://localhost:5099/api/Reservas/reporteReservasPorUsuario 

-> Ir a un sitio web y colocar: "http://localhost:5099/swagger/index.html" ahí aparecerán los endpoints

### 8. Que es cada endpoint

Si se está utilizando Postman el endpoint que cumple con la petición de la prueba 

"INAISO desea construir una aplicación web que le permita tener una administración de usuarios
(Entiéndase a administración por la gestión de crear, editar, actualizar y eliminar registros). La aplicación
se centra en la reserva de productos de software por temporada. Es decir, un usuario puede reservar una
aplicación “a”, “b”,o “c” por un determinado tiempo. INAISO necesita tener un reporte de las reservas por
meses, o años que ha realizado cada usuario para cada aplicación. Su desarrollo se debe basar en el
módulo de administración de usuarios y la generación del reporte de la cantidad de reservas de
aplicaciones por cada usuario. Usted debe crear datos semilla manual o automáticamente que le permita
almacenar todos los datos asociados para cumplir con lo requerido."

Se interpretó como:

-> Generación del reporte de la cantidad de reservas de aplicaciones por CADA usuario

también se implementó algo similar pero en vez de cada usuario, se hizo un endpoint que a cada aplicación le despliegue los usuarios que lo han reservado.

Estos dos endpoints son los siguientes:

/api/Reservas/reporteReservasPorUsuario

y

/api/Reservas/reporteReservasPorAplicacion

(para poder utilizarlos en Postman no olvidar incluir http://localhost:5099 y especificar que son peticiones GET)


Esas son las peticiones de la prueba, PERO, se pidió también que se pudiera gestionar a los usuarios, para esto se implementó un CRUD,
o sea, se implementaron los siguientes endpoints PARA EL USUARIO:

*** NO OLVIDAR INCLUIR http://localhost:5099 y luego colocar el siguiente texto***

1. /api/Usuarios (petición de tipo GET)

2. /api/Usuarios (petición de tipo POST)

3. /api/Usuarios/{id} (petición de tipo GET, el id es para obtener un usuario específico buscado por su id)

4. /api/Usuarios/{id} (petición de tipo PUT, el id es para obtener un usuario específico buscado por su id)

5. /api/Usuarios/{id} (petición de tipo DELETE, el id es para obtener un usuario específico buscado por su id)

Eso es todo para probar las peticiones por backend, La aplicación lamentablemente no tiene frontend porque no me alcanzó el tiempo, pero el backend debería estar en orden en su gran mayoría