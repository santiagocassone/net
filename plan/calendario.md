# Calendario

## Disponibilidad (se repite)

- Lunes y viernes: no.
- Martes: casi todo el día (~5 h útiles).
- Miércoles y jueves: todo el día (~6 h útiles).
- Fines de semana alternados: uno con sábado desde el mediodía (~3,5 h) y domingo todo el día (~6 h); el siguiente, nada.

Horas útiles = trabajo profundo. Arriba de 5-6 h por día la retención cae; lo que sobre va a repaso liviano o a descanso. Los cortes de 4 días (viernes a lunes, fin de semana sin estudio) se compensan con 1 h de recuperación el martes siguiente.

| Semana | Días | Horas |
|---|---|---|
| 28/10 – 1/11 | mié, jue, sáb tarde, dom | ~21 |
| 3/11 – 5/11 | mar, mié, jue | ~17 |
| 10/11 – 15/11 | mar, mié, jue, sáb tarde, dom | ~26 |
| 17/11 – 19/11 | mar, mié, jue | ~17 |

## Plan por día

El plan se comprime si el diagnóstico o los gates salen bien, y suma puentes si no.

| Día | Foco | Cierre |
|---|---|---|
| Mié 28/10 | Preparación y simulacro de screening. Diagnóstico (si hay energía; si no, pasa al jueves a la tarde) | Pitch grabado |
| Jue 29/10 | Mañana sin estudio nuevo. Tarde: bloque 1 (colecciones, generics, delegates, LINQ) | Ejercicio con tiempo |
| Sáb 31/10 tarde | Bloque 1: records, nullable, `IDisposable`, excepciones, Framework vs .NET moderno | — |
| Dom 1/11 | Gate 1 y bloque 2 (primera parte) | Gate 1 |
| Mar 3/11 | Recuperación, bloque 2 (segunda parte) y gate 2 | Gate 2 |
| Mié 4/11 | Bloque 3: pipeline, DI, configuración, validación, errores | Endpoint desde cero |
| Jue 5/11 | Bloque 3: REST y JWT | Gate 3 |
| *Vie 6 – Lun 9* | *Corte* | |
| Mar 10/11 | Recuperación larga, SQL puro | Queries con tiempo |
| Mié 11/11 | EF Core | Ejercicios |
| Jue 12/11 | EF Core avanzado, simulacro endpoint + SQL | Gate 4 |
| Sáb 14/11 tarde | Bloque 5 conceptual | Diagrama explicado en voz alta |
| Dom 15/11 | Bloque 5 práctico mínimo: cola, Function, idempotencia, outbox | Mensaje de punta a punta |
| Mar 17/11 | Bloque 6 | Gates 5 y 6 |
| Mié 18/11 | Bloques 7 y 8 | Gates 7 y 8 |
| Jue 19/11 | Simulacro completo y lista de brechas | Brechas |

## Sesiones con IA (bloque 10)

Una sesión de ~1 h al día siguiente de aprobar cada gate del núcleo (1 a 4), al final de la jornada, nunca antes del trabajo a mano del día. Se reparte a lo largo del plan, no al final, porque también se puede evaluar en la técnica.

| Gate (fecha prevista) | Sesión con IA | Tema |
|---|---|---|
| 1, dom 1/11 | mar 3/11, al cierre | LINQ, delegates, records |
| 2, mar 3/11 | mié 4/11, al cierre | Async |
| 3, jue 5/11 | mar 10/11, al cierre | ASP.NET Core y REST |
| 4, jue 12/11 | sáb 14/11 | SQL y EF Core |

Si un gate se atrasa, su sesión con IA se corre con él. Si el formato de la técnica permite IA, el simulacro final incluye una parte con IA.

## Fecha de la técnica

- **Regla:** al pasar el gate 4, pedir la técnica para 7-10 días después.
- Pedirla un martes, miércoles o jueves (días disponibles, con repaso el día anterior). Evitar lunes y viernes, que vienen después de días sin estudio.
- Contra: si los gates salen rápido, Azure puede quedar solo en lo conceptual. Es aceptable por su prioridad.
