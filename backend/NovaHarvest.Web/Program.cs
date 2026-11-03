var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapStaticAssets();


app.MapGet("/", () => Results.Content(
    $"""
    <!DOCTYPE html>
    <html lang="es">
    <head>
        <meta charset="UTF-8">
        <title>NovaHarvest - Inicio</title>
        <link rel="stylesheet" href="/css/site.css">
    </head>
    <body>
        <header>
            <img src="/img/logo.jpg" alt="NovaHarvest">
            <h2>NovaHarvest</h2>
            <nav>
                <a href="/">Inicio</a>
                <a href="/about">Acerca de</a>
                <a href="/status">Estado</a>
            </nav>
        </header>

        <main>
            <h1>Inicio</h1>
            <p>NovaHarvest es un proyecto que busca mejorar la gestión agrícola mediante la tecnología.</p>
            <p>Su objetivo es ayudar a los agricultores a controlar sus cultivos y aprovechar mejor los recursos.</p>
            <p>Está pensado para facilitar el trabajo diario y mejorar la producción.</p>
        </main>

        <footer>
            NovaHarvest · IES Valle del Jerte · {DateTime.Now.Year}
        </footer>
    </body>
    </html>
    """,
    "text/html"));

app.MapGet("/about", () => Results.Content(
    $"""
    <!DOCTYPE html>
    <html lang="es">
    <head>
        <meta charset="UTF-8">
        <title>NovaHarvest - Acerca de</title>
        <link rel="stylesheet" href="/css/site.css">
    </head>
    <body>
        <header>
            <img src="/img/logo.jpg" alt="NovaHarvest">
            <h2>NovaHarvest</h2>
            <nav>
                <a href="/">Inicio</a>
                <a href="/about">Acerca de</a>
                <a href="/status">Estado</a>
            </nav>
        </header>

        <main>
            <h1>Acerca de</h1>
            <p>Proyecto: NovaHarvest</p>
            <p>Centro: IES Valle del Jerte</p>
            <p>Autor: Izan González Franco</p>
            <p>Versión: 0.1.0</p>
        </main>

        <footer>
            NovaHarvest · IES Valle del Jerte · {DateTime.Now.Year}
        </footer>
    </body>
    </html>
    """,
    "text/html"));

app.MapGet("/status", () => Results.Content(
    $"""
    <!DOCTYPE html>
    <html lang="es">
    <head>
        <meta charset="UTF-8">
        <title>NovaHarvest - Estado del servidor</title>
        <link rel="stylesheet" href="/css/site.css">
    </head>
    <body>
        <header>
            <img src="/img/logo.jpg" alt="NovaHarvest">
            <h2>NovaHarvest</h2>
            <nav>
                <a href="/">Inicio</a>
                <a href="/about">Acerca de</a>
                <a href="/status">Estado</a>
            </nav>
        </header>

        <main>
            <h1>Estado del servidor</h1>
            <p>Fecha y hora del servidor: {DateTime.Now:dd/MM/yyyy HH:mm:ss}</p>
            <p>Página generada por ASP.NET Core (Kestrel)</p>
        </main>

        <footer>
            NovaHarvest · IES Valle del Jerte · {DateTime.Now.Year}
        </footer>
    </body>
    </html>
    """,
    "text/html"));

app.Run();
