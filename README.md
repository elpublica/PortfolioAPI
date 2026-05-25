# Portfolio API - Sistema de Gestión de Proyectos

Esta es una **API REST** profesional desarrollada con **.NET 8**, diseñada para gestionar y exponer los proyectos realizados en mi portafolio. El sistema permite administrar información detallada sobre desarrollos de software, incluyendo áreas de aplicación, tecnologías utilizadas y enlaces de referencia.

## 🚀 Tecnologías Utilizadas

* **Framework:** .NET 8 (ASP.NET Core Web API)
* **ORM:** Entity Framework Core
* **Base de Datos:** SQL Server
* **Documentación:** Swagger / OpenAPI
* **Arquitectura:** MVC (Model-View-Controller)

## 🛠️ Funcionalidades

- [x] **CRUD Completo:** Creación, lectura, actualización y eliminación de proyectos.
- [x] **Gestión por Áreas:** Clasificación de proyectos (Almacén, Compras, Gaming, etc.).
- [x] **CORS Configurado:** Lista para consumir desde Frontends como Vue.js o React.
- [x] **Documentación Interactiva:** Swagger integrado para pruebas rápidas.

## 📖 Cómo ejecutar el proyecto

1. Clonar el repositorio.
2. Configurar la cadena de conexión en `appsettings.json`.
3. Ejecutar `dotnet ef database update` para crear la base de datos localmente.
4. Iniciar la aplicación y navegar a `/swagger` para probar los endpoints.

---
Desarrollado con enfoque en arquitectura limpia y buenas prácticas de desarrollo.
