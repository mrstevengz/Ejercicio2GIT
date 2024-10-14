﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2GIT
{
    public class Producto
    {
        public string Nombre; //Definicion de variables
        public double Precio;
        public int Cantidad;

        public Producto(string nombre, double precio, int cantidad)
        {
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }
    }

    internal class Programa
    {
        static void Main() //Creacion del menu
        {
            List<Producto> inventario = new List<Producto>();
            while (true)
            {
                Console.WriteLine("Seleccione una opción: ");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Actualizar el stock");
                Console.WriteLine("3. Calcular valor de inventario");
                Console.WriteLine("4. Salir");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarProducto(ref inventario);
                        break;
                    case 2:
                        ActualizarStock(ref inventario);
                        break;
                    case 3:
                        double valorTotal = CalcularValorTotal(ref inventario);
                        Console.WriteLine("El valor total del inventario es: " + valorTotal);
                        break;
                    case 4: return;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
            }
        }
        public static void AgregarProducto(ref List<Producto> inventario) //Agregar productos 
        {
            Console.WriteLine("Ingrese el nombre del producto: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el precio del producto: ");
            double precio = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Ingrese la cantidad del producto: ");
            int cantidad = Convert.ToInt32(Console.ReadLine());

            inventario.Add(new Producto(nombre, precio, cantidad));
            Console.WriteLine($"Producto {nombre} agregado al inventario");
        }
        public static void ActualizarStock(ref List<Producto> inventario)
        {
            Console.WriteLine("Ingrese el nombre del producto para actualizar el stock: ");
            string nombre = Console.ReadLine();
            foreach (var producto in inventario)
            {
                if (producto.Nombre == nombre)
                {
                    Console.WriteLine("Ingrese la cantidad a agregar: ");
                    int cantidad = Convert.ToInt32(Console.ReadLine());
                    producto.Cantidad += cantidad;
                    Console.WriteLine($"Stock actualizado para {nombre}");
                    return;
                }
            }
            Console.WriteLine($"Producto {nombre} no encontrado en el inventario");
        }

        public static double CalcularValorTotal(ref List<Producto> inventario) // asignacion de valores calcular valor total
        {
            double valorTotal = 0;
            foreach (var producto in inventario)
            {
                valorTotal += producto.Precio * producto.Cantidad;
            }
            return valorTotal;
        }
    }
}
