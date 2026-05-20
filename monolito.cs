using System;

class Program
{
    // Constantes de negocio
    const double RECARGO_HORAS_EXTRA = 1.5;
    const double FACTOR_PAGO_NETO = 0.92;

    static void Main()
    {
        int totalEmpleados = LeerCantidadEmpleados();
        ProcesarLoteEmpleados(totalEmpleados);
    }

    /// <summary>
    /// Solicita la cantidad de empleados a procesar.
    /// </summary>
    /// <returns>Cantidad de empleados.</returns>
    static int LeerCantidadEmpleados()
    {
        Console.Write("¿Cuántos empleados desea procesar?: ");
        return int.Parse(Console.ReadLine());
    }

    /// <summary>
    /// Procesa todos los empleados del lote y genera el consolidado final.
    /// </summary>
    /// <param name="totalEmpleados">Cantidad de empleados a procesar.</param>
    static void ProcesarLoteEmpleados(int totalEmpleados)
    {
        int cantidadExitos = 0;
        int cantidadErrores = 0;

        double acumuladoSalarioBruto = 0;
        double acumuladoSalarioNeto = 0;

        for (int indiceEmpleado = 1; indiceEmpleado <= totalEmpleados; indiceEmpleado++)
        {
            bool procesoExitoso = TryProcesarEmpleado(
                indiceEmpleado,
                out double salarioBruto,
                out double salarioNeto,
                out string mensajeError);

            if (procesoExitoso)
            {
                cantidadExitos++;

                acumuladoSalarioBruto += salarioBruto;
                acumuladoSalarioNeto += salarioNeto;

                MostrarResultadoEmpleado(
                    indiceEmpleado,
                    salarioBruto,
                    salarioNeto);
            }
            else
            {
                cantidadErrores++;

                MostrarErrorEmpleado(
                    indiceEmpleado,
                    mensajeError);
            }

            MostrarResumenLote(
                cantidadExitos,
                cantidadErrores);
        }

        MostrarConsolidadoFinal(
            totalEmpleados,
            cantidadExitos,
            cantidadErrores,
            acumuladoSalarioBruto,
            acumuladoSalarioNeto);
    }

    /// <summary>
    /// Procesa un empleado individual.
    /// </summary>
    /// <param name="indiceEmpleado">Número del empleado.</param>
    /// <param name="salarioBruto">Salario bruto calculado.</param>
    /// <param name="salarioNeto">Salario neto calculado.</param>
    /// <param name="mensajeError">Mensaje de error si ocurre un problema.</param>
    /// <returns>True si el empleado fue procesado correctamente.</returns>
    static bool TryProcesarEmpleado(
        int indiceEmpleado,
        out double salarioBruto,
        out double salarioNeto,
        out string mensajeError)
    {
        salarioBruto = 0;
        salarioNeto = 0;
        mensajeError = "";

        try
        {
            Console.Write($"Empleado {indiceEmpleado} horas normales: ");
            double horasNormales = double.Parse(Console.ReadLine());

            Console.Write($"Empleado {indiceEmpleado} tarifa: ");
            double tarifaHora = double.Parse(Console.ReadLine());

            Console.Write($"Empleado {indiceEmpleado} horas extra: ");
            double horasExtra = double.Parse(Console.ReadLine());

            if (!DatosEmpleadoValidos(
                    horasNormales,
                    tarifaHora,
                    horasExtra))
            {
                mensajeError = "Datos inválidos";
                return false;
            }

            if (horasExtra > 0)
            {
                salarioBruto = CalcularSalarioBruto(
                    horasNormales,
                    horasExtra,
                    tarifaHora);
            }
            else
            {
                salarioBruto = CalcularSalarioBruto(
                    horasNormales,
                    tarifaHora);
            }

            salarioNeto = CalcularSalarioNeto(
                salarioBruto);

            return true;
        }
        catch
        {
            mensajeError = "Entrada inválida";
            return false;
        }
    }

    /// <summary>
    /// Valida los datos ingresados para un empleado.
    /// </summary>
    static bool DatosEmpleadoValidos(
        double horasNormales,
        double tarifaHora,
        double horasExtra)
    {
        return horasNormales > 0
            && tarifaHora > 0
            && horasExtra >= 0;
    }

    /// <summary>
    /// Calcula salario bruto sin horas extra.
    /// </summary>
    static double CalcularSalarioBruto(
        double horasNormales,
        double tarifaHora)
    {
        return horasNormales * tarifaHora;
    }

    /// <summary>
    /// Calcula salario bruto incluyendo horas extra.
    /// </summary>
    static double CalcularSalarioBruto(
        double horasNormales,
        double horasExtra,
        double tarifaHora)
    {
        double pagoBase =
            horasNormales * tarifaHora;

        double pagoHorasExtra =
            horasExtra * tarifaHora * RECARGO_HORAS_EXTRA;

        return pagoBase + pagoHorasExtra;
    }

    /// <summary>
    /// Calcula el salario neto.
    /// </summary>
    static double CalcularSalarioNeto(
        double salarioBruto)
    {
        return salarioBruto * FACTOR_PAGO_NETO;
    }

    /// <summary>
    /// Muestra el resultado exitoso de un empleado.
    /// </summary>
    static void MostrarResultadoEmpleado(
        int indiceEmpleado,
        double salarioBruto,
        double salarioNeto)
    {
        Console.WriteLine(
            $"Empleado {indiceEmpleado} procesado correctamente");

        Console.WriteLine(
            $"Salario bruto: {salarioBruto:C}");

        Console.WriteLine(
            $"Salario neto: {salarioNeto:C}");
    }

    /// <summary>
    /// Muestra un error de procesamiento.
    /// </summary>
    static void MostrarErrorEmpleado(
        int indiceEmpleado,
        string mensajeError)
    {
        Console.WriteLine(
            $"Empleado {indiceEmpleado} ERROR");

        Console.WriteLine(
            mensajeError);
    }

    /// <summary>
    /// Muestra el resumen parcial del lote.
    /// </summary>
    static void MostrarResumenLote(
        int cantidadExitos,
        int cantidadErrores)
    {
        Console.WriteLine("---------------------------");
        Console.WriteLine($"Procesados OK: {cantidadExitos}");
        Console.WriteLine($"Errores: {cantidadErrores}");
        Console.WriteLine("---------------------------");
    }

    /// <summary>
    /// Muestra el consolidado final del procesamiento.
    /// </summary>
    static void MostrarConsolidadoFinal(
        int totalEmpleados,
        int cantidadExitos,
        int cantidadErrores,
        double acumuladoBruto,
        double acumuladoNeto)
    {
        Console.WriteLine();
        Console.WriteLine("===== CONSOLIDADO FINAL =====");

        Console.WriteLine($"Total empleados: {totalEmpleados}");
        Console.WriteLine($"Procesados correctamente: {cantidadExitos}");
        Console.WriteLine($"Errores encontrados: {cantidadErrores}");
        Console.WriteLine($"Total salarios brutos: {acumuladoBruto:C}");
        Console.WriteLine($"Total salarios netos: {acumuladoNeto:C}");
    }
}
