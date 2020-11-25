using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    public Text plateText;
    public SaladIngredient[] order;

    public float maxWaitTime;

    private void OnEnable()
    {
        maxWaitTime = Random.Range(15.0f, 40.0f);
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

            plateText.text += order[i].ToString();
            if (i < numItems - 1)
                plateText.text += ",";
        }

        
    }

    public SaladIngredient[] GetOrder()
    {
        return order;
    }
}
