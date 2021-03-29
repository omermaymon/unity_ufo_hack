using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fire_script : MonoBehaviour
{
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().enabled = false;
      


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            GetComponent<Renderer>().enabled = true;
        } else
        {
            GetComponent<Renderer>().enabled = false;
        }
          //GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
            


       
        

    }
}
