//-------------------------------------------------------------------------------
// <copyright file="Step.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------------
using System.Collections;
namespace Full_GRASP_And_SOLID.Library
{
    public class ProductionCost
    {
        public double productionCost = 0;
        public ProductionCost(Recipe recipe, double productionCost)
        {
            this.productionCost = productionCost;
            double productCost = 0;
            double equipmentCost = 0;
            ArrayList recipeSteps = recipe.GetSteps();

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
    }
}