//-------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;
using System.Linq;
using Full_GRASP_And_SOLID.Library;

namespace Full_GRASP_And_SOLID
{
    public class Program
    {
        private static ArrayList productCatalog = new ArrayList();
        private static ArrayList equipmentCatalog = new ArrayList();
        public double productionCost = 0;
        public double productCost = 0;
        public double equipmentCost = 0;

        public static void Main(string[] args)
        {
            PopulateCatalogs();

            Recipe recipe = new Recipe();
            recipe.FinalProduct = GetProduct("Café con leche");
            recipe.AddStep(new Step(GetProduct("Café"), 100, GetEquipment("Cafetera"), 120));
            recipe.AddStep(new Step(GetProduct("Leche"), 200, GetEquipment("Hervidor"), 60));
            Printer.Print(recipe);
        }

        private static void PopulateCatalogs()
        {
            AddProductToCatalog("Café", 100);
            AddProductToCatalog("Leche", 200);
            AddProductToCatalog("Café con leche", 300);

            AddEquipmentToCatalog("Cafetera", 1000);
            AddEquipmentToCatalog("Hervidor", 2000);
        }
        public void ProductionCost(Recipe recipe, double productionCost)
        {
            this.productionCost = productionCost;
            ArrayList recipeSteps = recipe.GetSteps();
        }
        public static double GetProductionCost(double productionCost, double productCost, double equipmentCost, ArrayList recipeSteps)
        {

            foreach (Step step in recipeSteps)
            {
                productCost += GetProduct(step.Input.Description).UnitCost * step.Quantity;
            }
            foreach (Step step in recipeSteps)
            {
                equipmentCost += GetEquipment(step.Equipment.Description).HourlyCost * step.Time;
            }
            productionCost = productCost + equipmentCost;
            return productionCost;
        }
        private static void AddProductToCatalog(string description, double unitCost)
        {
            productCatalog.Add(new Product(description, unitCost));
        }

        private static void AddEquipmentToCatalog(string description, double hourlyCost)
        {
            equipmentCatalog.Add(new Equipment(description, hourlyCost));
        }

        private static Product ProductAt(int index)
        {
            return productCatalog[index] as Product;
        }

        private static Equipment EquipmentAt(int index)
        {
            return equipmentCatalog[index] as Equipment;
        }

        private static Product GetProduct(string description)
        {
            var query = from Product product in productCatalog where product.Description == description select product;
            return query.FirstOrDefault();
        }

        private static Equipment GetEquipment(string description)
        {
            var query = from Equipment equipment in equipmentCatalog where equipment.Description == description select equipment;
            return query.FirstOrDefault();
        }
    }
}
