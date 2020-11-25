using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SaladIngredient
{
    A = 1,
    B,
    C,
    D,
    E,
    F
}

public class Ingredient : MonoBehaviour, IActor
{

    public string ingredientName;

    public float timeToPrep;

    public TriggerZone myZone;

    public void EmitAction(IActor actor)
    {
        throw new System.NotImplementedException();
    }

    public void ReceiveAction(IActor actor)
    {
        throw new System.NotImplementedException();
    }

    private void Start()
    {
        timeToPrep = Random.Range(0.5f, 3f);
    }



}


