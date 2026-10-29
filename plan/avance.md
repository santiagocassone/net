# Avance

Se lee primero al retomar. Lo actualiza Claude al cerrar cada sesión, reemplazando lo que cambió.

## Estado

| # | Bloque | Estado | Gate | Notas |
|---|---|---|---|---|
| 1 | C# y .NET | En curso | — | LINQ agrupación/agregación: ejercicio aprobado (29/10). `IEnumerable` vs `IQueryable` y ejecución diferida: ejercicio hecho (29/10), punto 3 incompleto. Delegates/`Func`/`Action`: ejercicio hecho (29/10); el `Action` que guarda en lista no capturaba una lista externa. Closures (`for` vs `foreach`): entendido (29/10). Value vs reference: las 4 predicciones correctas (29/10) |
| 2 | Async y concurrencia | Puente | — | Arranca por hilo, thread pool, `Task`, continuación y contexto |
| 3 | ASP.NET Core y REST | Pendiente | — | Arranca por options pattern y validación/errores |
| 4 | SQL y EF Core | Puente | — | Arranca por SQL puro |
| 5 | Arquitectura distribuida | Pendiente | — | |
| 6 | Azure | Pendiente | — | |
| 7 | Testing y calidad | Pendiente | — | |
| 8 | Docker, Kubernetes, observabilidad | Pendiente | — | |
| 10 | IA para codificar | Pendiente | — | Solo sobre temas con gate aprobado |

Estados: Pendiente · En curso · Puente · Gate aprobado · Brecha declarada.

## Diagnóstico

En curso (2026-10-28). Resultados parciales:

- **Bloque 1:** autoevaluado sin dudas, salvo ítem 4 (`IEnumerable` vs `IQueryable`) D. Ítems 1 y 2 tuvieron dudas puntuales durante el diagnóstico (qué clasifican value/reference types; si `Func`/`Action` son genéricos). Sin puente; el gate valida las S autoevaluadas.
- **Bloque 2:** ítem 1 (`await`) S, con el matiz de que devuelve el control a quien llama. Ítem 2 (deadlock con `.Result`) N: no se entendió el mecanismo aun con explicación. Ítem 4 (`async void`) N. Ítems 3 y 5: S autoevaluadas. Ejercicio de código: en curso (consultó qué APIs usar → al menos D); lo evalúa Claude al terminar. Dos N → **el bloque 2 arranca por el puente**: hilo, thread pool, `Task`, continuación y contexto de sincronización, desde la base.
- **Bloque 3:** ítems 1 (pipeline), 2 (lifetimes) y 5 (idempotencia) S autoevaluadas. Ítem 3 (options pattern) N e ítem 4 (validación y errores, ProblemDetails) N. Ejercicio de código: N (no lo pudo hacer). Sin puente (el puente definido, interfaces y DI, no cubre estas brechas): **el bloque 3 arranca por options pattern y validación/errores desde la base**, y por armar una minimal API desde cero.
- **Bloque 4:** todo S autoevaluado (SQL y EF Core).
- **Código revisado por Claude (`net/Program.cs`):**
    - Bloque 1, LINQ: **N**. El filtro de fecha está invertido, no agrupa por cliente ni suma, y no limita a 3. Monto en `double`. Datos con 3 clientes.
    - Bloque 2, async: **N**. El token no llega a ninguna tarea, así que no hay cancelación ni tope de 2 s; no se maneja la cancelación.
    - Bloque 4, SQL: **N**. Consulta 1: `SUM(Id)` no cuenta, `HAVING` sobre una columna no agrupada y el filtro anula el `LEFT JOIN`. Consulta 2: correcta salvo agrupar por nombre. Consulta 3: agrupa por torneo, devuelve todos.
    - El proyecto no compila (SQL dentro del `.cs`). `.vs/` y `obj/` están commiteados.
- **Hallazgo principal:** la autoevaluación sobreestima. Bloques 1 y 4 se marcaron S y el código mostró N. Las S autoevaluadas necesitan validación externa.
- **Decisión:** bloque 1 arranca por LINQ con agrupación y agregación; bloque 4 arranca por el puente de SQL puro.

## Brechas declaradas

Ninguna.

## Errores de la IA detectados

Ninguno todavía. Formato: bug · cómo se detectó · concepto que aplica.

## Por confirmar

- Fecha del screening.
- Formato de la técnica.
- Fecha de la técnica (regla en `calendario.md`).

## Temas postergados a propósito

- Árboles de expresión: se ven en el bloque 4 (EF Core), mirando el SQL generado.
- Events: prioridad baja para backend; repaso breve al final del bloque 1 si sobra tiempo.

## Para la recuperación espaciada

- Ejecución diferida: cada recorrido vuelve a ejecutar la consulta (con una base, otra consulta).
- Materializar antes de tiempo (`ToList()` antes del `Where`) trae toda la tabla a memoria.
- Si necesitás las filas, materializá una vez y reusá; si solo necesitás un número (`Count`, `Any`), pedíselo a la base.
- `Func` devuelve un valor (el último tipo es el de retorno); `Action` no devuelve nada.
- Pasar una lambda = pasar el "qué"; el que la recibe decide "cuándo" y con qué datos (`Where`, `MapGet`, middleware, `Configure`).
- `<T>` después del nombre del método declara el tipo genérico; el resto de la firma lo usa.
- Closure = función + variables capturadas; captura la variable, no su valor, y le extiende la vida.
- Trampa: en `for` hay una sola variable para todas las vueltas; en `foreach` (desde C# 5), una por vuelta.

## Registro de sesiones

- 2026-10-28: plan armado (temario, calendario, método, especialistas). Se suma el bloque 10 (IA para codificar) y el subtema de integrar IA en aplicaciones dentro del bloque 6.
