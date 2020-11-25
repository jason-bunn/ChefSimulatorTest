using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IActor
{
    [Header("Round Variables")]
    public float initialTimePerRound = 120f;
    public int scoreForCorrectOrder = 200;
    public int penaltyForIncorrectOrder = -150;

    [Header("Player UI Text")]
    public Text[] playerScores;
    public Text[] playerTimes;
    public GameObject[] playerInventory;
    public GameObject[] playerPlateIcons;

    [Header("Players")]
    public PlayerController player1;
    public PlayerController player2;

    [Header("Prefabs")]
    public GameObject inventoryPrefab;

    private float[] playerTimeLeft;

    private float timeAtStart;

    // Start is called before the first frame update
    void Start()
    {
        GameEventManager.Initialize();
        GameEventManager.Subscribe("Player_1_PickupIngredient", this);
        GameEventManager.Subscribe("Player_2_PickupIngredient", this);

        playerTimeLeft = new float[] { 0, 0 };
        StartRound();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimeLeft();
    }

    public void StartRound()
    {
        timeAtStart = Time.time;
        for (int i = 0; i < playerTimeLeft.Length; i++)
        {
            playerTimes[i].text = initialTimePerRound.ToString();
            playerTimeLeft[i] = initialTimePerRound;
        }
    }

    private void UpdateTimeLeft()
    {
        for (int i = 0; i < playerTimeLeft.Length; i++)
        {
            playerTimeLeft[i] -= Time.deltaTime;
            playerTimes[i].text = Mathf.RoundToInt(playerTimeLeft[i]).ToString();
        }
    }

    public void ReceiveAction(string eventName, IActor actor)
    {
        switch(eventName)
        {
            case "Player_1_PickupIngredient":
                PlayerInventory inv = player1.GetComponent<PlayerInventory>();
                
                if(inv.GetInventory().Count < inv.itemMax)
                {
                    inv.PickupIngredient((Ingredient)actor);
                    SpawnInventoryItem(0, ((Ingredient)actor).ToString());
                }
                break;
            case "Player_2_PickupIngredient":
                PlayerInventory inv2 = player2.GetComponent<PlayerInventory>();
                
                if (inv2.GetInventory().Count < inv2.itemMax)
                {
                    inv2.PickupIngredient((Ingredient)actor);
                    SpawnInventoryItem(1, ((Ingredient)actor).ToString());
                }
                break;
            default:
                Debug.LogWarning("Invalid event name passed to GameManager");
                break;
        }
    }

    public void EmitAction(string name, IActor actor)
    {
        throw new System.NotImplementedException();
    }

    private void SpawnInventoryItem(int playerIndex, string name)
    {
        GameObject item = Instantiate(inventoryPrefab, playerInventory[playerIndex].transform);
        Text itemName = item.transform.Find("Text").GetComponent<Text>();
        itemName.text = name;
    }

    private void RemoveInventoryItem(int playerIndex, string name)
    {

    }

    public string GetName()
    {
        return "GameManager";
    }
}
