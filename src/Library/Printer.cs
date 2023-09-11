//-------------------------------------------------------------------------------
// <copyright file="Step.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace Full_GRASP_And_SOLID.Library
{
    public class Printer
    {
        public static void Print(Recipe recipe)
        {
            ArrayList recipeSteps = recipe.GetSteps();
            Console.WriteLine($"Receta de {recipe.FinalProduct.Description}:");
            foreach (Step step in recipe.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
        }
    }
}

/* Aplico el principio de responsabilidad única ya que no es responsabilidad de la receta saber imprimirse
además así la clase de Recipe se puede reutilizar en caso de querer imprimir la receta en otro lado o escribirla en un archivo*/