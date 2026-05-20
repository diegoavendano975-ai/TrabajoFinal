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


