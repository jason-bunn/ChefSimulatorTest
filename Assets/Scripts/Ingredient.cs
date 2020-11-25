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

  
    public void EmitAction(string name, IActor actor)
    {
        GameEventManager.DispatchEvent(name, actor);
    }

    public string GetName()
    {
        return ingredientName;
    }

    public void ReceiveAction(string eventName, IActor actor)
    {
        if (myZone.actorInZone == null)
            return;
        EmitAction("Player_" + (((PlayerController)(actor)).playerNumber) + "_PickupIngredient", this);
    }

    private void Start()
    {
        ingredientName = gameObject.name;
        timeToPrep = Random.Range(0.5f, 3f);
        GameEventManager.Subscribe("Player_1_Action", this);
        GameEventManager.Subscribe("Player_2_Action", this);

    }



}


