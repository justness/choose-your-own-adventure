using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public GameObject NPC;

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void Touch()
    {
        NPC.GetComponent<NPCController>().placeholder = 0;
        NPC.GetComponent<NPCController>().phase++;
        tag = "Untagged";
        transform.GetChild(1).gameObject.SetActive(true);
    }
}
