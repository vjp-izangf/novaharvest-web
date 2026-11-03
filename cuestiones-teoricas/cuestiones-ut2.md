# Cuestiones teóricas UT2 – NovaHarvest

## 1. ¿Qué modelo de arquitectura utiliza nuestra aplicación? ¿Qué función tiene el cliente y qué función tiene el servidor?

Nuestra aplicación utiliza el modelo cliente-servidor. El cliente es el navegador, desde donde el usuario accede a la web. El servidor utiliza nginx y ASP.NET Core para recibir las peticiones y devolver las páginas. Por ejemplo, si añadimos reservas, el servidor comprobaría si quedan plazas antes de confirmarlas.

## 2. ¿Qué diferencia hay entre una página estática y una dinámica? ¿Qué dos páginas dinámicas podríamos añadir?

Una página estática muestra siempre el mismo contenido, mientras que una dinámica puede cambiar según los datos. En nuestro proyecto, `/status` es dinámica porque muestra la fecha y la hora actuales. En el futuro podríamos añadir una página para consultar reservas y otra para ver el stock de los productos.

## 3. Explica qué ocurre cuando un usuario accede a `/status`. ¿Qué diferencias hay entre CGI y un módulo integrado?

Al entrar en `/status`, el navegador envía una petición a nginx, que la pasa al backend. Kestrel ejecuta el código C#, obtiene la hora actual y devuelve el HTML al navegador. CGI ejecuta un programa externo para atender la petición, mientras que un módulo integrado funciona dentro del propio servidor.

## 4. Compara la cabecera Server utilizando Docker y dotnet run. ¿Qué ocurre si detenemos el backend?

Podemos comprobarlo con `curl -I`. Al utilizar Docker, lo normal es que aparezca nginx, y al ejecutar directamente la aplicación, Kestrel. Si detenemos el backend con `docker compose stop backend`, las páginas dejan de funcionar y nginx devuelve un error 502. El backend no tiene un puerto publicado porque se comunica directamente con nginx dentro de Docker.

## 5. ¿Por qué nginx no sirve directamente el CSS y el logo? ¿Qué otras funciones podría realizar?

nginx no sirve directamente estos archivos porque en nuestra configuración reenvía todas las peticiones al backend. Es ASP.NET Core quien entrega el CSS y el logo. nginx también podría gestionar conexiones HTTPS o repartir las peticiones entre varios servidores.

## 6. Si utilizáramos otra tecnología para el servidor, ¿qué archivos tendríamos que modificar y cuáles se mantendrían?

Tendríamos que cambiar el código del backend y su Dockerfile. También podríamos modificar la configuración de nginx y Docker Compose si cambiaran los puertos. Los archivos CSS, las imágenes y gran parte del HTML podrían mantenerse.

## 7. Copia un fragmento de código de Program.cs e identifica dos problemas de generar HTML mediante cadenas de texto.

Un ejemplo de nuestro código es:

```csharp
app.MapGet("/status", () => Results.Content(
    $"""
    <h1>Estado de NovaHarvest</h1>
    <p>Fecha y hora: {DateTime.Now:dd/MM/yyyy HH:mm:ss}</p>
    <p>Página generada por ASP.NET Core (Kestrel)</p>
    """,
    "text/html"));
```

Un problema es que podemos cometer errores al escribir las etiquetas HTML dentro del código C#. Otro es que tenemos que repetir partes comunes, como la cabecera y el menú, en cada página, haciendo que el código sea más largo.

## 8. ¿Cuántas imágenes y contenedores utiliza el proyecto? ¿Qué diferencia hay entre ellos? ¿Por qué no incluimos el SDK en la imagen final?

Utilizamos dos imágenes principales, una para nginx y otra para el backend. Al ejecutar Docker Compose se crean dos contenedores. La imagen es la plantilla y el contenedor es la aplicación funcionando. No incluimos el SDK en la imagen final porque solo lo necesitamos para compilar, no para ejecutar la aplicación. Sin `.dockerignore`, Docker podría copiar archivos innecesarios y hacer la construcción más lenta.

## 9. Indica las herramientas utilizadas en el proyecto y qué problema resuelve cada una.

| Herramienta | Función |
|---|---|
| C# | Programar el backend. |
| ASP.NET Core | Crear la aplicación web. |
| Kestrel | Ejecutar el servidor. |
| HTML | Crear la estructura de las páginas. |
| CSS | Dar estilo a la web. |
| nginx | Recibir y reenviar peticiones. |
| Docker | Ejecutar la aplicación en contenedores. |
| Docker Compose | Arrancar los servicios juntos. |
| Visual Studio Code | Escribir el código. |
| Terminal | Ejecutar comandos. |
| curl | Comprobar las respuestas del servidor. |
| Git | Guardar los cambios del proyecto. |

## 10. Compara la hora que aparece en `/status` al ejecutar con Docker y con dotnet run. ¿Por qué puede haber diferencias?

Con `dotnet run` se utiliza la hora del ordenador, mientras que con Docker se utiliza la configuración horaria del contenedor. Si Docker utiliza UTC y el ordenador tiene la hora de España, puede haber una diferencia de una hora en invierno. Esto se debe a que España utiliza UTC+1 durante esa época.