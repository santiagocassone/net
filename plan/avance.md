# Avance

Se lee primero al retomar. Lo actualiza Claude al cerrar cada sesión, reemplazando lo que cambió.

## Forma de trabajo (desde 4/11)

Simplificada a pedido de Santi: un tema por vez, explicado a fondo con ejemplos; práctica solo donde suma (ASP.NET Core, SQL, EF); al inicio de cada sesión 3-4 preguntas rápidas de temas anteriores; sin hablar de gates ni bloques con Santi. Dos líneas en paralelo: fundamentos de C#/.NET (huecos) y temas senior de la JD. El seguimiento interno sigue en esta tabla.

## Cambio de enfoque (5/11)

Objetivo: semi senior. Prioridad: formación. Práctica construyendo el backend de Comunidad Pádel desde cero (ver `proyecto.md`), con unos 10-20 endpoints. Sin front. Double Nines nunca llamó para la técnica: sin fecha.

## Estado

| # | Bloque | Estado | Gate | Notas |
|---|---|---|---|---|
| 1 | C# y .NET | Gate en curso | Parte 1 (1/11): aprobados value/reference, `throw`, nullable, `override`/`new`, `HashSet`/`List`. A repasar y reprobar: delegate (tipo vs variable), ejecución diferida (no es exclusiva de `IQueryable`), records (compara por valor, `with`, cuándo no usarlos), `IDisposable` (no libera memoria: recursos externos), encapsulamiento (no lo definió), `where T` (restringe, no agrega), .NET Framework vs moderno (no es "un contenedor"; faltó soporte, LTS, su migración). Parte 2 (1/11): no aprobada, resuelta con ayuda en casi todos los puntos (conversión `IList`→`IReadOnlyCollection`, `Dictionary`/`Values`, restricción adaptada del ejemplo, `SelectMany`, `try` único, consulta sin enumerar). Repetir el mismo ejercicio desde cero, sin ayuda y con tiempo. Nueva evaluación (2/11): aprobados delegate, ejecución diferida, `IDisposable`, encapsulamiento/abstracción. Siguen marcados: records (`with`, inmutabilidad superficial), `using` (corre aun con excepción), `where T` (lado del que llama, error al compilar, ejemplo), Framework vs moderno (mantenimiento, LTS, su migración). Parte 2 variante (2/11, `Gate1b.cs`): estructura sin ayuda (encapsulamiento, restricción, store, `with`, `try` separados); ayuda en APIs (`TryGetValue`, indexador, `Take`, patrón de `Sum`) y en una decisión de diseño (`HashSet` vs `Dictionary`). Corregidos `Take` y `Total` → parte 2 cerrada (2/11). Parte 3 (2/11), 9 preguntas del entrevistador: Q6 ✅; Q1, Q2, Q3, Q4, Q7, Q9 ⚠️; Q5, Q10 ❌. **Gate 1 no aprobado**: falla la profundidad en las repreguntas. Repasar: igualdad de records con listas, `TIME_WAIT`/DNS/`IHttpClientFactory`, salida del `for` (333), clase abstracta vs interfaz (estado, constructores, protected), variable `IEnumerable` sobre `DbSet` (todo en memoria), boxing, excepciones vs flujo de negocio (patrón Result), qué se rompe al migrar de Framework, O(n²) y `Equals`/`GetHashCode` | LINQ agrupación/agregación: ejercicio aprobado (29/10). `IEnumerable` vs `IQueryable` y ejecución diferida: ejercicio hecho (29/10), punto 3 incompleto. Delegates/`Func`/`Action`: ejercicio hecho (29/10); el `Action` que guarda en lista no capturaba una lista externa. Closures (`for` vs `foreach`): entendido (29/10). Value vs reference: las 4 predicciones correctas (29/10). Records y nullable: correcto (29/10), faltó anotar predicción del `ToString` y la advertencia del compilador. `IDisposable`/`using`: aprobado (31/10). Excepciones: aprobado (31/10). Framework vs .NET moderno: explicado (31/10); pendiente opcional, escribir la historia de su migración a .NET 8. Mini diagnóstico POO (1/11): polimorfismo e interfaz vs abstracta S con matices; encapsulamiento D (lo confunde con abstracción); `new` N; composición D (falta el porqué); abstracción N → estudiado (1/11): `override` vs `new` predicho bien; encapsulamiento bien armado, con la condición del cupo invertida y una `Exception` genérica. Colecciones y complejidad: aprobado (1/11), tras corregir el `HashSet` vacío y la `List` en vez de `HashSet`. Falta: restricciones de genéricos, después gate 1 |
| 2 | Async y concurrencia | Cerrado en lo conceptual (4/11): `ConfigureAwait` y `ValueTask` explicados, sin ejercicio a pedido de Santi | — | Puente: hilo, pool, bloquear vs no bloquear, `Task`, continuación, contexto y deadlock, entendidos. Experimento con 1.000 tareas salteado. `CancellationToken` + `WhenAll`: implementación correcta (31/10), predicción incompleta (tiempo total y "Cancelado"). `async void`: explicado, ejercicio descartado por Santi; retener la regla de una línea. Hallazgo: `DelayMethod` sin `await` y `CallDelay` llamando a `SleepMethod`. Concurrencia (31/10): race condition vista en ejecución, `Interlocked` y `lock` correctos, `SemaphoreSlim` bien armado (corrigió la trampa de closure en el `for`). Sigue: `ConfigureAwait`, `ValueTask`, colecciones concurrentes en práctica |
| 3 | ASP.NET Core y REST | En curso (4/11) | — | Arranca por options pattern y validación/errores |
| 3b | Diseño: SOLID y patrones | Pendiente | — | Agregado el 31/10 |
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

## Checklist antes de la técnica

- [ ] Asistente de IA del editor (Copilot / IntelliCode, completado de líneas): decidir si va prendido o apagado según las reglas del formato. Por defecto, apagado si comparto pantalla en live coding y no aclararon que se permite IA.

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
- `using` = `try/finally` que llama a `Dispose()` siempre, aun con excepción.
- Encapsulamiento = proteger el estado (invariantes); abstracción = mostrar lo esencial. `override` respeta el objeto real; `new` se resuelve por el tipo de la variable.
- `List.Contains` es O(n); `HashSet`/`Dictionary` buscan en O(1) por hash. Buscar en una `List` dentro de un bucle es el error de rendimiento clásico.
- Esperar I/O no requiere hilo: la red y la base trabajan; el SO avisa y recién ahí se pide un hilo para la continuación.
- `async void` solo en event handlers: no se puede esperar y sus excepciones no se capturan.
- Cancelación cooperativa: el token hay que pasarlo hasta el fondo; si nadie lo mira, nada se cancela.
- Herramienta más chica: un número → `Interlocked`; varios datos sin `await` → `lock`; con `await` o máximo N → `SemaphoreSlim`. Todo esto vale para un solo proceso; con varias réplicas, coordinar en la base o en Redis.
- `HttpClient` por pedido → cada `Dispose` deja el puerto en `TIME_WAIT` → se agotan los puertos locales. Un único cliente eterno → no ve cambios de DNS. Solución: `IHttpClientFactory`.

## Registro de sesiones

- 2026-10-28: plan armado (temario, calendario, método, especialistas). Se suma el bloque 10 (IA para codificar) y el subtema de integrar IA en aplicaciones dentro del bloque 6.
