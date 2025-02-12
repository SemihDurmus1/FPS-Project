using Sandwich;
using UnityEngine;

namespace Ingredient
{
    public class IngredientItem : GrabbableObjectBase
    {
        [SerializeField] private ScriptableIngredientItem scriptableIngredientItem;
        public ScriptableIngredientItem ScriptableIngredientItem => scriptableIngredientItem;

        public SandwichMakerPlane placedSandwichPlane;
    }
}