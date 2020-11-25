using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{

    public IActor actorInZone;

    private bool m_PlayerInZone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (m_PlayerInZone)
            return;
        m_PlayerInZone = true;
        actorInZone = other.gameObject.GetComponent<PlayerController>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (m_PlayerInZone)
        {
            m_PlayerInZone = false;
            actorInZone = null;
            
        }
            
    }
}
