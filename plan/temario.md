# Temario por prioridad

Criterio de prioridad: peso en los requisitos del puesto, frecuencia en técnicas .NET senior (estimación de Claude, se ajusta cuando se conozca el formato) y costo de quedar mal. Reparto aproximado del tiempo: 55% núcleo, 30% alto, 15% bonus y transversal.

## Bloques

| # | Nivel | Bloque | Contenido |
|---|---|---|---|
| 1 | Núcleo | C# y .NET | Value vs reference types, `struct`/`class`/`record`, nullable, generics y restricciones, delegates/`Func`/`Action`/eventos, colecciones y su complejidad, LINQ y ejecución diferida, `IEnumerable` vs `IQueryable`, excepciones, `IDisposable`/`using`, GC básico, .NET Framework vs .NET moderno |
| 2 | Núcleo | Async y concurrencia | `Task`, `async/await` por dentro (state machine), contexto de sincronización, `ConfigureAwait`, deadlocks, `async void`, `ValueTask`, `CancellationToken`, `WhenAll`/`WhenAny`, thread pool, condiciones de carrera, `lock`/`SemaphoreSlim`, colecciones concurrentes, cuándo no usar async |
| 3 | Núcleo | ASP.NET Core y REST | Host y `Program.cs`, pipeline de middleware, DI y lifetimes (y la dependencia cautiva), configuración y options pattern, minimal APIs vs controllers, model binding y validación, filtros, manejo de errores y ProblemDetails, autenticación/autorización con JWT, diseño REST (verbos, idempotencia, códigos, paginación, versionado) |
| 4 | Núcleo | SQL y EF Core | Joins, agregaciones, subconsultas, window functions básicas, índices y planes, transacciones y niveles de aislamiento; `DbContext` y su vida, change tracker, `AsNoTracking`, N+1 e `Include`, proyecciones, migraciones, concurrencia optimista, SQL crudo y cuándo usarlo |
| 5 | Alto | Arquitectura distribuida | Monolito vs monolito modular vs microservicios, bounded contexts, base por servicio, síncrono vs asíncrono, colas y topics, at-least-once, idempotencia, outbox, sagas, consistencia eventual, retry/circuit breaker, API gateway, tracing distribuido |
| 6 | Alto | Azure | App Service vs Functions vs Container Apps, triggers y bindings, Azure SQL vs Cosmos DB (modelo, partición, consistencia, costo), Storage (blob, queue, table), Service Bus, Key Vault e identidades administradas, Azure DevOps (repos, pipelines YAML) |
| 7 | Alto | Testing y calidad | Unit vs integración vs e2e, xUnit, test doubles (mock, stub, fake), `WebApplicationFactory`, Testcontainers, qué testear, code review, SOLID con criterio, seguridad básica (OWASP en APIs) |
| 8 | Bonus | Docker, Kubernetes, observabilidad | Imagen vs contenedor, Dockerfile multi-stage, conceptos de Kubernetes (pod, deployment, service, probes), logging estructurado, métricas y trazas, Application Insights; temario de AZ-204 como checklist (sin rendir la certificación) |
| 9 | Relato | Git, integraciones, IA | Solo armar historias con evidencia propia |
| 10 | Transversal | IA para codificar | Especificación y tests antes de pedir código, revisión crítica de lo generado con lo aprendido en cada bloque, registro de errores de la IA (APIs inventadas, deadlocks, N+1, lifetimes, validaciones faltantes, secretos), cuándo no usarla |

**Bloque 6, subtema:** integrar IA en una aplicación (Azure OpenAI, `Microsoft.Extensions.AI`, costos, errores, datos sensibles). Es distinto del bloque 10: uno es llamar a un modelo desde .NET; el otro, usar un asistente para escribir código.

## IA para codificar (bloque 10)

- **Zona sin IA:** ejercicios, katas, gates, simulacros y todo el bloque en curso. Asistente desactivado en esas carpetas.
- **Zona con IA:** carpeta `ia/`, solo sobre temas con gate aprobado. Una sesión de ~1 h después de cada gate del núcleo.
- **Por qué este orden:** generar con IA algo que todavía no se sabe escribir da la ilusión de entenderlo al revisarlo. Escribirlo primero es lo que fija el aprendizaje.
- **Registro:** cada error de la IA detectado se anota en `avance.md` (bug, cómo se detectó, qué concepto aplica). Es material para la entrevista.
- **Riesgo:** si la técnica prohíbe IA, lo que cuenta es lo hecho a mano; este bloque no reemplaza nada del núcleo.

**Transversal:** pensar en voz alta, inglés técnico, live coding (aclarar requisitos, casos borde, complejidad, probar).

## Prerrequisitos y módulos puente

Si fallan dos o más prerrequisitos de un bloque, primero se hace el puente (1-2 h).

| Bloque | Prerrequisitos | Puente |
|---|---|---|
| 1 (LINQ) | Generics, `IEnumerable`, delegates | Generics y delegates |
| 2 | Delegates y lambdas, qué es un `Task`, hilo vs thread pool | Delegates, `Func`/`Action`, `Task` básico |
| 3 | Interfaces, generics, ciclo de vida de objetos, HTTP básico | Interfaces y DI en una consola |
| 4 | LINQ, `IQueryable`, SQL básico | SQL puro antes del ORM |
| 5 | REST, async, transacciones en una base | REST y transacciones ACID |
| 6 | Async, DI, serialización JSON | Async y DI |
| 6 (Cosmos) | Documento vs relacional, qué es particionar | Modelo de documentos |

## Criterio de salida de cada bloque (gate)

Los tres, por rendimiento y no por "lo leí":

1. Explicar en voz alta, sin mirar, en 2 minutos, cada tema del bloque, incluido por qué la alternativa no sirve.
2. Resolver desde cero un ejercicio del bloque, con tiempo límite y sin ayuda.
3. Resolver las contra-preguntas típicas, que llegan días después de la explicación.

## Reglas de retroceso

- Dos fallas del gate en el mismo tema → volver a su prerrequisito.
- Si un bloque consume más del 150% del tiempo asignado → seguir adelante y marcarlo como brecha declarada, con una respuesta honesta preparada ("lo conozco conceptualmente, no lo usé en producción").
- Si falta tiempo, se recorta de abajo hacia arriba: bonus → detalle de Azure → proyecto. El núcleo no se recorta.

## Formato de la técnica (a confirmar en el screening)

- Práctico (endpoint, SQL, refactor): el plan queda como está.
- Algorítmico: se suma estructuras de datos y Azure pasa a conceptual.
- Sin live coding: más peso a diseño y arquitectura.
