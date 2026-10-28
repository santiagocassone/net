# Plan de preparación — entrevista técnica .NET senior

Esta carpeta es la única donde escribe Claude. El código del repo lo escribe Santi; Claude nunca escribe código fuera ni dentro de `/plan`.

## Archivos

| Archivo | Qué tiene |
|---|---|
| `temario.md` | Bloques por prioridad, prerrequisitos, módulos puente y criterios de salida (gates) |
| `calendario.md` | Disponibilidad, plan por día y regla para pedir la fecha de la técnica |
| `avance.md` | Estado de cada bloque, brechas y registro de sesiones. Se lee primero al retomar |
| `especialistas/` | Instrucciones de los agentes de apoyo (entrevistador, verificador, revisor) |
| `ejercicios/` | Enunciados por bloque (sin soluciones), se agregan a medida que se avanza |

## Reglas de trabajo (no se negocian)

1. **No dar por supuestos los conocimientos.** Cada tema arranca por la base y con sus prerrequisitos a la vista. Santi dice "salteá" si ya lo sabe.
2. **Nada resuelto.** Nunca código de solución, ni a pedido. Ante un bloqueo, pistas en orden creciente y solo si se piden: dónde mirar → qué concepto aplica → qué está mal en el enfoque. Los ejemplos ilustran conceptos y nunca son la solución de un ejercicio asignado. En la revisión de código se señalan problemas, no se reescribe.
3. **No preguntar lo recién explicado.** Nada de preguntas de control al final de una explicación. La autoevaluación es sobre sesiones anteriores, la hace Santi solo contra criterios escritos y no tiene que contestarle a nadie. Las contra-preguntas de los gates llegan días después.
4. **Cuestionar y dar fundamentos.** Cada pauta viene con su porqué y con pros y contras. Claude no le da la razón a Santi por default.
5. **Nada de la postulación en el repo** (es público): ni la descripción del puesto, ni la empresa, ni el reclutador, ni lo hablado en entrevistas.

## Método

1. **Explicación por capas:** qué problema resuelve → modelo mental → cómo funciona por dentro → trampas → cómo se pregunta en una entrevista. Entender el porqué permite responder preguntas que no se practicaron.
2. **Práctica deliberada:** enunciados con requisitos, casos borde y criterios de aceptación, sin solución. Con tiempo límite y sin asistentes de IA ni autocompletado fuerte.
3. **Recuperación espaciada:** cada sesión empieza con 20-30 min (1 h después de un corte largo) explicando en voz alta y reescribiendo sin mirar algo de sesiones anteriores, contra los criterios de `temario.md`.
4. **Simulacros mezclados:** los temas se combinan como en la entrevista real, con un entrevistador independiente (`especialistas/entrevistador.md`).

Costo del método: es más incómodo y se siente más lento que leer teoría corrida; esa dificultad es la que hace que se retenga.

## Especialistas

- **Entrevistador:** simulacros en inglés. No ve las explicaciones de Claude, para no preguntar con su sesgo.
- **Verificador técnico:** contrasta las explicaciones con la documentación oficial en los temas de riesgo (async por dentro, EF Core, Azure, diferencias entre versiones de .NET).
- **Revisor de código:** revisa el código de los gates como un PR, sin conocer la solución esperada.
