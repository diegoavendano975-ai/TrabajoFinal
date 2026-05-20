# TrabajoFinal
Proyecto: Sistema de Procesamiento de Pagos de Empleados

# Integrantes

Diego Andrés Avendaño Zambrano

# Descripción

Aplicación desarrollada en C# para procesar el pago de empleados mediante una arquitectura modular. El sistema solicita horas trabajadas, tarifa por hora y horas extra, valida los datos ingresados, calcula salario bruto y salario neto, registra errores sin detener la ejecución y genera un consolidado final del lote procesado.

Durante la Unidad 3 se refactorizó el código original monolítico aplicando principios de modularidad, separación de responsabilidades, patrón Try, sobrecarga de métodos y mejora de legibilidad.

# Objetivos de la Refactorización:

Eliminar código monolítico en Main.

Separar interfaz de usuario, lógica de negocio y orquestación.

Aplicar funciones con responsabilidad única.

Implementar validaciones mediante patrón Try.

Aplicar sobrecarga para cálculo de salario bruto.

Mejorar nombres de variables y funciones.

Eliminar números mágicos mediante constantes.

# Arquitectura del Programa

## Arquitectura del Programa


```text
Main()
│
└── ProcesarLoteEmpleados()
    │
    ├── TryProcesarEmpleado()
    │   │
    │   ├── DatosEmpleadoValidos()
    │   ├── CalcularSalarioBruto()
    │   └── CalcularSalarioNeto()
    │
    ├── MostrarResultadoEmpleado()
    ├── MostrarErrorEmpleado()
    ├── MostrarResumenLote()
    └── MostrarConsolidadoFinal()
```
# Funciones Principales

| Función                  | Responsabilidad                     |
| ------------------------ | ----------------------------------- |
| Main                     | Iniciar el programa                 |
| ProcesarLoteEmpleados    | Coordinar el procesamiento del lote |
| TryProcesarEmpleado      | Validar y calcular un empleado      |
| DatosEmpleadoValidos     | Verificar reglas de validación      |
| CalcularSalarioBruto     | Calcular salario bruto              |
| CalcularSalarioNeto      | Calcular salario neto               |
| MostrarResultadoEmpleado | Mostrar resultados individuales     |
| MostrarErrorEmpleado     | Mostrar errores de validación       |
| MostrarResumenLote       | Mostrar avance parcial              |
| MostrarConsolidadoFinal  | Mostrar resumen final               |

# Sobrecarga Implementada

## Sin horas extra

```csharp
static double CalcularSalarioNeto(double salarioBruto)
{
    return salarioBruto * FACTOR_PAGO_NETO;
}
```

## Con horas extra

```csharp
static double CalcularSalarioBruto(
    double horasNormales,
    double horasExtra,
    double tarifaHora)
```
La segunda versión calcula el recargo de horas extra utilizando un factor de 1.5.

# Casos de Prueba
| ID | Entrada                         | Esperado                     | Resultado |
| -- | ------------------------------- | ---------------------------- | --------- |
| T1 | horas=40, tarifa=15000          | bruto=600000, neto=552000    | Correcto  |
| T2 | horas=0, tarifa=15000           | rechazo con mensaje claro    | Correcto  |
| T3 | horas=-3, tarifa=20000          | rechazo sin detener programa | Correcto  |
| T4 | horas=40, extra=8, tarifa=15000 | bruto=780000                 | Correcto  |
| T5 | válido, inválido, válido        | éxitos=2, errores=1          | Correcto  |

## Tecnologías Utilizadas
C#

.NET

Consola

Git

GitHub

# Ejemplo de Uso

## Entrada:
```text
¿Cuántos empleados desea procesar?: 1

Empleado 1 horas normales: 40
Empleado 1 tarifa: 15000
Empleado 1 horas extra: 8
```

## Salida:
```text
Empleado 1 procesado correctamente

Salario bruto: $780,000.00
Salario neto: $717,600.00
```

# Reflexión Técnica

La refactorización permitió transformar un programa monolítico en una solución modular y mantenible. Se separaron las responsabilidades de lectura, validación, cálculo y presentación de resultados, facilitando la comprensión y reutilización del código. El patrón Try mejoró el manejo de errores sin interrumpir el procesamiento del lote completo, mientras que la sobrecarga permitió reutilizar el cálculo del salario bruto para diferentes escenarios. El resultado es un sistema más claro, escalable y alineado con las buenas prácticas de desarrollo de software.
