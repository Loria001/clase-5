using System;
using System.Globalization;

class Program
{
    static int[] numeroFactura = new int[15];
    static int[] numeroPlaca = new int[15];
    static DateTime[] fecha = new DateTime[15];
    static TimeSpan[] hora = new TimeSpan[15];
    static int[] tipoVehiculo = new int[15];
    static int[] numeroCaseta = new int[15];
    static double[] montoPagar = new double[15];
    static double[] pagaCon = new double[15];
    static double[] vuelto = new double[15];

    static int vehiculosRegistrados = 0;
    static int facturaActual = 0;

    static void Main()
    {
        int opcion;
        do
        {
            Console.WriteLine("Menú Principal del Sistema:");
            Console.WriteLine("1. Inicializar Vectores");
            Console.WriteLine("2. Ingresar Paso Vehicular");
            Console.WriteLine("3. Consulta de vehículos por número de placa");
            Console.WriteLine("4. Modificar Datos vehículos por número de placa");
            Console.WriteLine("5. Reporte Todos los datos de los vectores");
            Console.WriteLine("6. Salir");

            Console.Write("Seleccione una opción: ");
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        InicializarVectores();
                        break;
                    case 2:
                        IngresarPasoVehicular();
                        break;
                    case 3:
                        ConsultarPorNumeroPlaca();
                        break;
                    case 4:
                        ModificarPorNumeroPlaca();
                        break;
                    case 5:
                        ReporteTodosLosDatos();
                        break;
                    case 6:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ingrese un número válido.");
            }
        } while (opcion != 6);
    }

    static void InicializarVectores()
    {
        Console.Clear();
        for (int i = 0; i < 15; i++)
        {
            numeroFactura[i] = 0;
            numeroPlaca[i] = 0;
            fecha[i] = DateTime.MinValue;
            hora[i] = TimeSpan.MinValue;
            tipoVehiculo[i] = 0;
            numeroCaseta[i] = 0;
            montoPagar[i] = 0;
            pagaCon[i] = 0;
            vuelto[i] = 0;
        }

        vehiculosRegistrados = 0;
        facturaActual = 0;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Vectores inicializados correctamente.");
        Console.ResetColor();


    }

    static void IngresarPasoVehicular()
    {
        if (vehiculosRegistrados < 15)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("REGISTRAR FLUJO VEHICULAR\n");

                numeroFactura[vehiculosRegistrados] = facturaActual++;
                Console.WriteLine("Numero Factura: " + numeroFactura[vehiculosRegistrados]);

                Console.Write("Numero PLACA: ");
                numeroPlaca[vehiculosRegistrados] = int.Parse(Console.ReadLine());

                Console.Write("Fecha (dd/MM/yyyy): ");
                string fechaInput = Console.ReadLine();
                if (DateTime.TryParseExact(fechaInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaPago))
                {
                    fecha[vehiculosRegistrados] = fechaPago;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Formato de fecha incorrecto. Intente nuevamente.");
                    Console.ResetColor();
                    continue;
                }

               Console.Write("Hora (hh:mm): ");
string horaInput = Console.ReadLine();
if (DateTime.TryParseExact($"{fechaInput} {horaInput}", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaHoraPago))
{
    fecha[vehiculosRegistrados] = fechaHoraPago.Date;
    hora[vehiculosRegistrados] = fechaHoraPago.TimeOfDay;
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Formato de fecha u hora incorrecto. Intente nuevamente.");
    Console.ResetColor();
    continue;
}
                Console.Clear();
                Console.WriteLine("Tipo de vehículo:");
                Console.WriteLine("1. Moto");
                Console.WriteLine("2. Vehículo Liviano");
                Console.WriteLine("3. Camión o Pesado");
                Console.WriteLine("4. Autobús");
                Console.Write("Seleccione el tipo de vehículo: ");
                tipoVehiculo[vehiculosRegistrados] = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Numero caseta:");
                Console.WriteLine("1. Caseta 1");
                Console.WriteLine("2. Caseta 2");
                Console.WriteLine("3. Caseta 3");
                Console.Write("Seleccione el número de caseta: ");
                numeroCaseta[vehiculosRegistrados] = int.Parse(Console.ReadLine());

                switch (tipoVehiculo[vehiculosRegistrados])
                {
                    case 1:
                        montoPagar[vehiculosRegistrados] = 500;
                        break;
                    case 2:
                        montoPagar[vehiculosRegistrados] = 700;
                        break;
                    case 3:
                        montoPagar[vehiculosRegistrados] = 2700;
                        break;
                    case 4:
                        montoPagar[vehiculosRegistrados] = 3700;
                        break;
                    default:
                        Console.WriteLine("Tipo de vehículo no válido. Monto a pagar no asignado.");
                        break;
                }

                Console.Write("Monto a pagar: " + montoPagar[vehiculosRegistrados] + "\n");

                Console.Write("Paga con: ");
                pagaCon[vehiculosRegistrados] = double.Parse(Console.ReadLine());

                vuelto[vehiculosRegistrados] = pagaCon[vehiculosRegistrados] - montoPagar[vehiculosRegistrados];
                Console.Write("Vuelto: " + vuelto[vehiculosRegistrados] + "");

                vehiculosRegistrados++;

                Console.Write("Desea continuar (S/N)? ");
                char continuar = Console.ReadLine().ToUpper()[0];

                if (continuar != 'S')
                {
                    Console.Clear();
                    Console.WriteLine("Registro de vehículos completado.");
                    break; 
                }
                else if (vehiculosRegistrados >= 15)
                {
                    Console.WriteLine("Se ha alcanzado el límite máximo de vehículos registrados.");
                    break; 
                }

            } while (true);
        }
    }
    

    static void ConsultarPorNumeroPlaca()
    {
        Console.Clear();
        Console.Write("Ingrese el número de placa a consultar: ");
        int placaConsulta = int.Parse(Console.ReadLine());

        bool encontrado = false;
        for (int i = 0; i < vehiculosRegistrados; i++)
        {
            if (numeroPlaca[i] == placaConsulta)
            {
                Console.WriteLine("\nDatos del vehículo con número de placa " + placaConsulta + ":");
                Console.WriteLine("Número Factura: " + numeroFactura[i]);
                Console.WriteLine("Fecha: " + fecha[i]);
                Console.WriteLine("Hora: " + hora[i]);
                Console.WriteLine("Tipo de Vehículo: " + tipoVehiculo[i]);
                Console.WriteLine("Número de Caseta: " + numeroCaseta[i]);
                Console.WriteLine("Monto a Pagar: " + montoPagar[i]);
                Console.WriteLine("Paga con: " + pagaCon[i]);
                Console.WriteLine("Vuelto: " + vuelto[i]);
                Console.WriteLine();

                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Vehículo con número de placa " + placaConsulta + " no encontrado.");
        }
    }

    static void ModificarPorNumeroPlaca()
    {
        Console.Clear();
        Console.Write("Ingrese el número de placa a modificar: ");
        int placaModificar;

        if (int.TryParse(Console.ReadLine(), out placaModificar))
        {
            bool encontrado = false;
            int indiceModificar = -1;

            for (int i = 0; i < vehiculosRegistrados; i++)
            {
                if (numeroPlaca[i] == placaModificar)
                {
                    Console.Clear();
                    Console.WriteLine("Datos del vehículo con número de placa " + placaModificar + ":");
                    Console.WriteLine("Número Factura: " + numeroFactura[i]);
                    Console.WriteLine("Fecha: " + fecha[i].ToString("dd/MM/yyyy"));
                    Console.WriteLine("Hora: " + hora[i].ToString(@"hh\:mm"));
                    Console.WriteLine("Tipo de Vehículo: " + tipoVehiculo[i]);
                    Console.WriteLine("Número de Caseta: " + numeroCaseta[i]);
                    Console.WriteLine("Monto a Pagar: " + montoPagar[i]);
                    Console.WriteLine("Paga con: " + pagaCon[i]);
                    Console.WriteLine("Vuelto: " + vuelto[i]);
                    Console.WriteLine();

                    indiceModificar = i;
                    encontrado = true;
                    break;
                }
            }

            if (encontrado)
            {
                Console.WriteLine("Seleccione el dato a modificar:");
                Console.WriteLine("1. Fecha");
                Console.WriteLine("2. Hora");
                Console.WriteLine("3. Tipo de Vehículo");
                Console.WriteLine("4. Número de Caseta");
                Console.WriteLine("5. Monto a Pagar");
                Console.WriteLine("6. Paga con");
                Console.WriteLine("7. Vuelto");
                Console.WriteLine("8. Salir");

                Console.Write("Seleccione una opción: ");
                int opcionModificar;

                if (int.TryParse(Console.ReadLine(), out opcionModificar))
                {
                    switch (opcionModificar)
                    {
                        case 1:
                            Console.Write("Nueva Fecha (dd/MM/yyyy): ");
                            string nuevaFechaInput = Console.ReadLine();
                            if (DateTime.TryParseExact(nuevaFechaInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime nuevaFecha))
                            {
                                fecha[indiceModificar] = nuevaFecha;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Formato de fecha incorrecto. No se realizó la modificación.");
                                Console.ResetColor();
                            }
                            break;
                        case 2:
                            Console.Write("Nueva Hora (hh:mm): ");
                            string nuevaHoraInput = Console.ReadLine();
                            if (TimeSpan.TryParseExact(nuevaHoraInput, @"hh\:mm", CultureInfo.InvariantCulture, out TimeSpan nuevaHora))
                            {
                                hora[indiceModificar] = nuevaHora;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Formato de hora incorrecto. No se realizó la modificación.");
                                Console.ResetColor();
                            }
                            break;
                        case 3:
                            Console.WriteLine("Nuevo Tipo de Vehículo:");
                            Console.WriteLine("1. Moto");
                            Console.WriteLine("2. Vehículo Liviano");
                            Console.WriteLine("3. Camión o Pesado");
                            Console.WriteLine("4. Autobús");
                            Console.Write("Seleccione el nuevo tipo de vehículo: ");
                            tipoVehiculo[indiceModificar] = int.Parse(Console.ReadLine());
                            break;
                        case 4:
                            Console.WriteLine("Nuevo Número de Caseta:");
                            Console.WriteLine("1. Caseta 1");
                            Console.WriteLine("2. Caseta 2");
                            Console.WriteLine("3. Caseta 3");
                            Console.Write("Seleccione el nuevo número de caseta: ");
                            numeroCaseta[indiceModificar] = int.Parse(Console.ReadLine());
                            break;
                        case 5:
                            Console.Write("Nuevo Monto a Pagar: ");
                            montoPagar[indiceModificar] = double.Parse(Console.ReadLine());
                            break;
                        case 6:
                            Console.Write("Nuevo Paga con: ");
                            pagaCon[indiceModificar] = double.Parse(Console.ReadLine());
                            break;
                        case 7:
                            Console.Write("Nuevo Vuelto: ");
                            vuelto[indiceModificar] = double.Parse(Console.ReadLine());
                            break;
                        case 8:
                            Console.WriteLine("Saliendo de la modificación...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Saliendo de la modificación...");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ingrese un número válido. Saliendo de la modificación...");
                }
            }
            else
            {
                Console.WriteLine("Vehículo con número de placa " + placaModificar + " no encontrado. Saliendo de la modificación...");
            }
        }
        else
        {
            Console.WriteLine("Ingrese un número de placa válido. Saliendo de la modificación...");
        }
    }

    static void ReporteTodosLosDatos()
    {
        Console.WriteLine("  Título del Reporte");
        Console.WriteLine("N factura\tPlaca\t\t\ttipo de vehículo\tcaseta\tmonto Pagar\tpaga con\tvuelto");
        Console.WriteLine("=============================================================================");
        for (int i = 0; i < vehiculosRegistrados; i++)
        {
            Console.WriteLine($"{numeroFactura[i]}               {numeroPlaca[i]}                {tipoVehiculo[i]}                     {numeroCaseta[i]}                    {montoPagar[i]}               {pagaCon[i]}               {vuelto[i]}");
        }
        Console.WriteLine("=============================================================================");
        Console.WriteLine($"Cantidad de vehículos: {vehiculosRegistrados}\t\ttotal: {CalcularTotalMontoPagar()}");
        Console.WriteLine("=============================================================================");
        Console.WriteLine("                                <<<Pulse tecla para regresar >>>");
        Console.ReadKey();
    }

    static double CalcularTotalMontoPagar()
    {
        double total = 0;
        for (int i = 0; i < vehiculosRegistrados; i++)
        {
            total += montoPagar[i];
        }
        return total;
    }
}
