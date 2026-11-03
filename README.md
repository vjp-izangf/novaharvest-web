# novaharvest-web
# NovaHarvest

## 1. Arranque del proyecto

### Requisitos previos

Para ejecutar el proyecto es necesario tener instalado:

- Docker Desktop.
- .NET SDK 10.0.

### Arrancar con Docker

Desde la carpeta raíz del proyecto, ejecutar:

```bash
docker compose up -d --build
```

Este comando construye las imágenes y arranca los contenedores de nginx y ASP.NET Core.

Para comprobar que los contenedores están funcionando:

```bash
docker compose ps
```

Para acceder a la aplicación desde el navegador:

http://localhost:8080

### Parar el proyecto

Para detener los contenedores:

```bash
docker compose down
```

### Ejecutar sin Docker

Para ejecutar el backend directamente con .NET, entrar en la carpeta `backend` y ejecutar:

```bash
dotnet run --project NovaHarvest.Web
```

La aplicación mostrará en la consola la dirección local donde está funcionando.

Se puede acceder a esa dirección directamente desde el navegador, sin pasar por nginx.

## 2. Arquitectura

El proyecto NovaHarvest utiliza una arquitectura cliente-servidor formada por tres componentes:

- **Navegador:** es el cliente desde el que el usuario accede a la página web.
- **Web (nginx):** recibe las peticiones del navegador y las reenvía al backend mediante un proxy inverso.
- **Backend (ASP.NET Core):** procesa las peticiones y genera las páginas HTML mediante código C# utilizando Kestrel. También sirve los archivos estáticos, como los estilos CSS y las imágenes.

### Diagrama de arquitectura

```text
        NAVEGADOR
     localhost:8080
            |
            | HTTP
            v
      WEB (NGINX)
       Puerto 80
            |
            | HTTP
            | backend:8080
            v
  BACKEND (ASP.NET CORE)
       Puerto 8080
       Kestrel (C#)
            |
            v
     HTML, CSS e imágenes
            |
            v
      NGINX → NAVEGADOR
```

### Recorrido de una petición

1. El usuario accede a `http://localhost:8080` desde el navegador.
2. La petición llega al contenedor web, donde funciona nginx.
3. Nginx reenvía la petición al backend utilizando la dirección `http://backend:8080`.
4. ASP.NET Core recibe la petición y genera la página HTML correspondiente.
5. El backend devuelve la respuesta a nginx.
6. Nginx entrega la respuesta al navegador y el usuario puede visualizar la página.

### Funcionamiento de los archivos estáticos

Los archivos estáticos, como CSS e imágenes, también son servidos por la aplicación ASP.NET Core.

De esta manera, la aplicación funciona igual tanto si se accede directamente al backend como si se accede a través de nginx.