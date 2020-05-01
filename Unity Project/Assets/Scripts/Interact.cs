using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject interacting;
    public PlayerController pc;

    void Start()
    {
        interacting = null;
    }

    public void Act(GameObject gO)
    {
        interacting = gO;

        if (interacting.CompareTag("NPC"))
        {
            if (interacting.GetComponent<NPCController>().placeholder == 0 || interacting.GetComponent<NPCController>().placeholder == interacting.GetComponent<NPCController>().lines)
            {
                GameObject npcCam = interacting.transform.GetChild(0).gameObject;
                GameObject npcCanvas = interacting.transform.GetChild(1).gameObject;
                GameObject playCam = transform.GetChild(0).gameObject;
                npcCam.SetActive(!npcCam.activeSelf);
                npcCanvas.SetActive(!npcCanvas.activeSelf);
                playCam.SetActive(!npcCam.activeSelf);

                if (npcCam.activeSelf)
                {
                    transform.GetChild(1).gameObject.transform.position = gO.transform.position + (2 * Vector3.left) + (2 * Vector3.back);
                    pc.mobile = false;
                }
                if (playCam.activeSelf)
                {
                    transform.GetChild(1).gameObject.transform.position = transform.position;
                    pc.mobile = true;
                }
            }
            interacting.GetComponent<NPCController>().Step();
        }
        if (interacting.CompareTag("Object"))
        {
            interacting.GetComponent<ObjectController>().Touch();
        }
    }

    public void StopAct ()
    {
        interacting = null;
        transform.GetChild(0).gameObject.SetActive(true);
        pc.mobile = true;
    }
}
