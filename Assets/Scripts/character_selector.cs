using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_selector : MonoBehaviour
{
    int character;
    public GameObject[] characters;
    // Start is called before the first frame update
    void Start()
    {
        characters[0].SetActive(false);
        characters[1].SetActive(false);
        character = PlayerPrefs.GetInt("character");
        characters[character].SetActive(true);
        
    }

    // Update is called once per frame
   
}
