# Avance

Se lee primero al retomar. Lo actualiza Claude al cerrar cada sesión, reemplazando lo que cambió.

## Estado

| # | Bloque | Estado | Gate | Notas |
|---|---|---|---|---|
| 1 | C# y .NET | Pendiente | — | |
| 2 | Async y concurrencia | Puente | — | Arranca por hilo, thread pool, `Task`, continuación y contexto |
| 3 | ASP.NET Core y REST | Pendiente | — | |
| 4 | SQL y EF Core | Pendiente | — | |
| 5 | Arquitectura distribuida | Pendiente | — | |
| 6 | Azure | Pendiente | — | |
| 7 | Testing y calidad | Pendiente | — | |
| 8 | Docker, Kubernetes, observabilidad | Pendiente | — | |
| 10 | IA para codificar | Pendiente | — | Solo sobre temas con gate aprobado |

Estados: Pendiente · En curso · Puente · Gate aprobado · Brecha declarada.

## Diagnóstico

En curso (2026-10-28). Resultados parciales:

- **Bloque 1:** autoevaluado sin dudas, salvo ítem 4 (`IEnumerable` vs `IQueryable`) D. Ítems 1 y 2 tuvieron dudas puntuales durante el diagnóstico (qué clasifican value/reference types; si `Func`/`Action` son genéricos). Sin puente; el gate valida las S autoevaluadas.
- **Bloque 2:** ítem 1 (`await`) S, con el matiz de que devuelve el control a quien llama. Ítem 2 (deadlock con `.Result`) N: no se entendió el mecanismo aun con explicación → **el bloque 2 arranca por el puente**: hilo, thread pool, `Task`, continuación y contexto de sincronización, desde la base.

## Brechas declaradas

Ninguna.

## Errores de la IA detectados

Ninguno todavía. Formato: bug · cómo se detectó · concepto que aplica.

## Por confirmar

- Fecha del screening.
- Formato de la técnica.
- Fecha de la técnica (regla en `calendario.md`).

## Registro de sesiones

- 2026-10-28: plan armado (temario, calendario, método, especialistas). Se suma el bloque 10 (IA para codificar) y el subtema de integrar IA en aplicaciones dentro del bloque 6.
