using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject[] players;
    public int character;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        character = PlayerPrefs.GetInt("character");
        offset = transform.position - players[character].transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = players[character].transform.position + offset;
        
    }
}
