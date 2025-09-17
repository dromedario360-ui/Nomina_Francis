using System;
using System.Collections.Generic;


public interface IEmpleado
{
    string Nombre { get; set; }
    string Apellido { get; set; }
    string Cedula { get; set; }

    decimal CalcularPago(); 
}

)
public abstract class EmpleadoBase : IEmpleado
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Cedula { get; set; }

    public abstract decimal CalcularPago();
}


public class EmpleadoAsalariado : EmpleadoBase
{
    public decimal SalarioSemanal { get; set; }

    public override decimal CalcularPago()
    {
        return SalarioSemanal;
    }
}

// Empleado por Horas
public class EmpleadoPorHoras : EmpleadoBase
{
    public decimal SueldoPorHora { get; set; }
    public int HorasTrabajadas { get; set; }

    public override decimal CalcularPago()
    {
        if (HorasTrabajadas <= 40)
            return SueldoPorHora * HorasTrabajadas;
        else
            return (SueldoPorHora * 40) + (SueldoPorHora * 1.5m * (HorasTrabajadas - 40));
    }
}


public class EmpleadoPorComision : EmpleadoBase
{
    public decimal VentasBrutas { get; set; }
    public decimal TarifaComision { get; set; }

    public override decimal CalcularPago()
    {
        return VentasBrutas * TarifaComision;
    }
}


public class EmpleadoAsalariadoPorComision : EmpleadoBase
{
    public decimal VentasBrutas { get; set; }
    public decimal TarifaComision { get; set; }
    public decimal SalarioBase { get; set; }

    public override decimal CalcularPago()
    {
        return (VentasBrutas * TarifaComision) + SalarioBase + (SalarioBase * 0.10m);
    }
}


public class Program
{
    public static void Main()
    {
        List<IEmpleado> empleados = new List<IEmpleado>
        {
            new EmpleadoAsalariado { Nombre = "Juan", Apellido = "Perez", Cedula = "001-1234567-8", SalarioSemanal = 500 },
            new EmpleadoPorHoras { Nombre = "Maria", Apellido = "Lopez", Cedula = "002-2345678-9", SueldoPorHora = 200, HorasTrabajadas = 45 },
            new EmpleadoPorComision { Nombre = "Carlos", Apellido = "Diaz", Cedula = "003-3456789-0", VentasBrutas = 10000, TarifaComision = 0.10m },
            new EmpleadoAsalariadoPorComision { Nombre = "Ana", Apellido = "Gomez", Cedula = "004-4567890-1", VentasBrutas = 20000, TarifaComision = 0.05m, SalarioBase = 5000 }
        };

        foreach (var empleado in empleados)
        {
            Console.WriteLine($"{empleado.Nombre} {empleado.Apellido} ({empleado.Cedula}) - Pago Semanal: {empleado.CalcularPago():C}");
        }
    }
}

