# Proyecto: backend de Comunidad Pádel desde cero

Objetivo: aprender .NET a nivel semi senior construyendo una API real, y practicar live coding de endpoints. Solo backend; el front no se toca.

## Reglas

- El dominio se toma del Comunidad Pádel existente, pero **el código se escribe de cero**. No se abre el código viejo mientras se programa: la especificación está acá.
- Cada concepto entra cuando el proyecto lo necesita. Explicación a fondo con ejemplos, después el endpoint.
- **IA (Claude Code):** solo en los pasos marcados con 🤖, y siempre después de haber hecho a mano uno equivalente. Se le pide, se revisa y se anotan sus errores en `avance.md`.
- Al inicio de cada sesión, 3-4 preguntas rápidas de fundamentos.

## Dominio reducido

| Entidad | Datos principales |
|---|---|
| Zona | Nombre, slug, orden |
| Localidad | Nombre, slug, zona |
| Club | Nombre, slug, dirección, localidad, zona, activo |
| Organizador | Nombre, slug |
| Categoría | Nombre, orden |
| Publicación | Tipo (torneo / cancha abierta), club, organizador, inicio, fin opcional, precio, cupo, estado (borrador / publicada / oculta) |

**Regla de negocio central:** la vigencia de una publicación se calcula al consultar (no con un proceso programado), en un único lugar del dominio, con tests unitarios.

## Orden de construcción

| # | Endpoint o paso | Conceptos |
|---|---|---|
| 1 | `GET /api/health` + middlewares de logging y API key | Host, `Program.cs`, pipeline, orden de middlewares |
| 2 | `GET /api/zones` (datos en memoria) | DI, interfaces, lifetimes, dependencia cautiva |
| 3 | `GET /api/clubs?zone=&page=&pageSize=` | Binding de query, paginación, LINQ |
| 4 | `GET /api/clubs/{slug}` | Parámetros de ruta, `Results` (200/404), DTOs |
| 5 | `POST /api/clubs` | Binding del body, validación, ProblemDetails, 201 + `Location` |
| 6 | `PUT /api/clubs/{id}` | Idempotencia, 400 / 404 / 409 |
| 7 | `DELETE /api/clubs/{id}` | Baja lógica, 204 |
| 8 | 🤖 CRUD de organizadores con Claude Code | Pedir, revisar, corregir |
| 9 | SQL puro: consultas sobre el esquema | Joins, agregaciones, índices, transacciones |
| 10 | Pasar todo a EF Core + SQL Server en Docker | `DbContext`, migraciones, change tracker, `AsNoTracking` |
| 11 | `GET /api/publications?zone=&type=&from=` | `IQueryable`, proyección a DTO, `Include` y N+1, paginación |
| 12 | `GET /api/publications/{slug}` | Vigencia calculada en el dominio + tests unitarios |
| 13 | `POST /api/publications` | Reglas de negocio, validación cruzada, patrón Result |
| 14 | `POST /api/publications/{id}/publish` y `/unpublish` | Estados, concurrencia optimista (`RowVersion`), 409 |
| 15 | Manejo global de errores | `IExceptionHandler`, ProblemDetails, logging |
| 16 | Configuración | Options pattern, `appsettings`, ambientes |
| 17 | Endpoints de admin protegidos | Autenticación JWT, autorización |
| 18 | Tests de integración | `WebApplicationFactory`, Testcontainers |
| 19 | 🤖 Endpoints de categorías y localidades con Claude Code | Revisión crítica |
| 20 | Docker + deploy a Azure | Dockerfile multi-stage, App Service o Container Apps, Application Insights |
