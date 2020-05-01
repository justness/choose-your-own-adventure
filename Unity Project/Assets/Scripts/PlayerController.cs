using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Interact interact;
    public bool mobile;
    public Light main;

    void Start()
    {
        mobile = true;
    }

    void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            Restart();
        }
        if (mobile)
        {
            if (Input.GetKey("w"))
            {
                this.transform.Translate(0f, 0f, speed);
            }
            if (Input.GetKey("a"))
            {
                this.transform.Translate(-speed, 0f, 0f);
            }
            if (Input.GetKey("s"))
            {
                this.transform.Translate(0f, 0f, -speed);
            }
            if (Input.GetKey("d"))
            {
                this.transform.Translate(speed, 0f, 0f);
            }
        }
        if (transform.position.y < 0)
        {
            main.intensity = main.intensity - 0.008f;
            mobile = false;
            if (main.intensity == 0)
            {
                Restart();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            Debug.Log("Colliding with " + other.gameObject + ".");
            //Give a cue.
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown("space"))
        {
            interact.Act(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (transform.GetChild(0).gameObject.activeSelf)
        {
            interact.StopAct();
        }
    }
}
