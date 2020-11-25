using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int itemMax = 2;

    private List<Ingredient> ingredients;

    // Start is called before the first frame update
    void Start()
    {
        ingredients = new List<Ingredient>();
    }

    public void RemoveIngredient()
    {
        ingredients.RemoveAt(0);
    }

    public void PickupIngredient(Ingredient item)
    {
        if (ingredients.Count < itemMax)
            ingredients.Add(item);
    }

    public List<Ingredient> GetInventory()
    {
        return ingredients;
    }
}
