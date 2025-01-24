using Ingredient;
using System.Collections.Generic;
using UnityEngine;

namespace Sandwich
{
    /// <summary>
    /// This class for manage the Sandwich Maker Planes
    /// </summary>
    public class SandwichMakerPlane : MonoBehaviour
    {
        [SerializeField] private LayerMask ingredientLayers;
        [SerializeField] private SandwichItem sandwich;
        [SerializeField] private List<IngredientItem> ingredientItems;

        private void Awake()
        {
            sandwich = new SandwichItem();
            //ingredientItems = new List<IngredientItem>();
        }

        public void PositionOnSandwichMakerPlane(IngredientItem ingredient)//sets ingredient's position on the plane
        {
            if (ingredientItems.Count > 0)
            {
                IngredientItem lastIngredient = ingredientItems[ingredientItems.Count - 1];

                Vector3 newPosition = lastIngredient.transform.position;
                newPosition.y += lastIngredient.Height / 2 + ingredient.Height / 2;//set the new ingredient's position on top of the last ingredient

                ingredient.transform.SetPositionAndRotation(newPosition, transform.transform.rotation);
            }
            else
            {
                ingredient.transform.SetPositionAndRotation(transform.position, transform.rotation);
            }
        }

        public void AddIngredientToPlane(IngredientItem ingredient)
        {
            if ((ingredientLayers.value & (1 << ingredient.gameObject.layer)) != 0)
            {
                //IngredientItem ingredientItem = ưngredient.gameObject.GetComponent<IngredientItem>();

                ingredient.onThatSandwichMakerPlane = this;

                SandwichManager.Instance.AddIngredient(sandwich, ingredient.ScriptableIngredientItem);

                ingredientItems.Add(ingredient);

                SandwichManager.Instance.PrintIngredients(sandwich);
            }
        }

        public void RemoveIngredientFromPlane(IngredientItem ingredient)
        {
            if ((ingredientLayers.value & (1 << ingredient.gameObject.layer)) != 0)
            {
                //IngredientItem ingredientItem = ingredient.gameObject.GetComponent<IngredientItem>();

                SandwichManager.Instance.RemoveIngredient(sandwich, ingredient.ScriptableIngredientItem);

                ingredientItems.Remove(ingredient);

                SandwichManager.Instance.PrintIngredients(sandwich);
            }
        }
    }
}