# Diagnóstico inicial

Solo, sin documentación, sin IA y sin autocompletado asistido. ~2 h. No hay que contestarle a nadie: es para decidir por dónde arrancar.

**Cómo puntuar cada ítem:** S = lo hice o expliqué sin dudar · D = con dudas o incompleto · N = no pude.
**Regla:** en un bloque, 2 o más N en "Explicar", o una N en "Codear" → ese bloque arranca por su módulo puente (`temario.md`).

## Bloque 1 — C# y .NET (~30 min)

**Explicar en voz alta (2 min cada uno):**
1. Value type vs reference type, y qué pasa al pasar cada uno a un método.
2. Qué es un delegate y cómo se relaciona con `Func`, `Action` y una lambda.
3. Ejecución diferida en LINQ.
4. `IEnumerable` vs `IQueryable`.
5. Para qué existe `IDisposable` y qué hace `using`.

**Codear (20 min, app de consola):** a partir de una lista de pedidos en memoria (cliente, fecha, monto, estado), obtener con LINQ los 3 clientes con mayor total en pedidos completados del último mes, de mayor a menor.

## Bloque 2 — Async (~25 min)

**Explicar:**
1. Qué hace `await`: ¿bloquea el hilo?
2. Cuándo y por qué se produce un deadlock al usar `.Result`.
3. Para qué sirve un `CancellationToken`.
4. Por qué evitar `async void`.
5. `Task.WhenAll` vs `await` dentro de un bucle.

**Codear (15 min):** simular 5 llamadas lentas con duraciones distintas, ejecutarlas en paralelo con un tope total de 2 segundos y cancelar las que no terminaron.

## Bloque 3 — ASP.NET Core y REST (~35 min)

**Explicar:**
1. Qué es el pipeline de middleware y por qué importa el orden.
2. Lifetimes singleton, scoped y transient, y qué pasa si un singleton recibe un servicio scoped.
3. Options pattern.
4. Cómo validar la entrada y cómo devolver los errores (códigos, ProblemDetails).
5. Idempotencia: PUT vs POST.

**Codear (25 min):** minimal API con un listado paginado (GET) y un alta con validación (POST), sobre un servicio en memoria inyectado por DI.

## Bloque 4 — SQL y EF Core (~30 min)

**SQL (15 min, escrito):** tablas `Clubs(Id, Name)` y `Tournaments(Id, ClubId, StartsAt, Price)`.
1. Cada club con su cantidad de torneos del próximo mes, incluidos los que tienen 0.
2. Precio promedio por club.
3. El torneo más caro de cada club.

**Explicar:**
1. Qué es el change tracker.
2. Cuándo usar `AsNoTracking`.
3. Qué es el problema N+1 y cómo se detecta.
4. Qué garantiza `SaveChanges` en cuanto a transacciones.
5. Concurrencia optimista.

## Resultado

| Bloque | Explicar (S/D/N) | Codear (S/D/N) | ¿Puente? |
|---|---|---|---|
| 1 | | | |
| 2 | | | |
| 3 | | | |
| 4 | | | |
