using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    public int lines;
    public int placeholder;
    public int phase;
    public Material ice;
    List<string> blank;
    List<string> Titus = null;
    List<string> Exit = null;

    void Start()
    {
        placeholder = 0;
        phase = 0;
        
        if (name.Equals("Titus"))
        {
            Titus = new List<string>()
            {
                "Hello! I'm Titus, the Tutorial Master.",
                "We can't cross until the river's frozen.",
                "Start by fixing that generator."
            };
            blank = Titus;
            lines = Titus.Count;
        }
        if (name.Equals("Exit"))
        {
            Exit = new List<string>() 
            {
                "Exit -->"
            };
        }
    }

    void Update()
    {
        if (name.Equals("Titus"))
        {
            if (placeholder >= lines && phase == 0)
            {
                transform.GetChild(1).GetChild(4).gameObject.SetActive(true);
            }
            if (phase > 0)
            {
                Titus = new List<string>()
                {
                    "Oh my goodness, you broke it!!",
                    ":(",
                    ":(((",
                    "...",
                    ":(((((((((((((((((((((((((",
                    "... just get out of my sight."
                };
                blank = Titus;
                lines = Titus.Count;
                transform.GetChild(2).gameObject.GetComponent<BoxCollider>().isTrigger = false;
                transform.GetChild(2).gameObject.GetComponent<MeshRenderer>().material = ice;
            }
        }
    }

    public void Step()
    {
        if (placeholder == lines)
        {
            return;
        }
        Text line = transform.GetChild(1).GetChild(3).GetComponent<Text>();
        line.text = blank[placeholder];
        placeholder++;
    }
}
