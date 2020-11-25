using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{

    public SaladIngredient[] order;

    private void OnEnable()
    {
        GenerateOrder();
    }

    private void GenerateOrder()
    {
        int numItems = Random.Range(1, 4);
        order = new SaladIngredient[numItems];
        for(int i = 0; i < numItems; i++)
        {
            int randomIngredient = Random.Range(1, 7);
            order[i] = (SaladIngredient)randomIngredient;
        }
    }

    public SaladIngredient[] GetOrder()
    {
        return order;
    }
}
