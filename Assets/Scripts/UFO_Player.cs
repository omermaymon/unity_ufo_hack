using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UFO_Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    private int count;
    public Text countText;
    public Text winText;
    public int scene;
    public GameObject animatino;
    void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        updateCountText();
        winText.text = "";
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movment = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movment * speed);


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("PickUp"))
        {
            collision.gameObject.SetActive(false);
            count++;
            updateCountText();
        }
        
    }

    void updateCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 11 && scene == 1)
        {
            StartCoroutine(waitBeforeFinish(3));

        }
        else if (count >= 16 && scene == 2)
        {
            StartCoroutine(waitBeforeFinish(5));
        }
    }

    private IEnumerator waitBeforeFinish(int i)
    {
        if (i == -1)
        {

            this.gameObject.GetComponent<Renderer>().enabled = false;
            winText.text = " YOU PATHETHIC LOSER!";
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(sceneBuildIndex: 0);
            this.gameObject.GetComponent<Renderer>().enabled = true;
        }

        else if (scene == 1)
        {
            winText.text = "YOU HAVE NO CHANCE";
            yield return new WaitForSeconds(i);
            SceneManager.LoadScene(sceneBuildIndex: 2);
        }
        else if (scene == 2)
        {
            winText.text = "YOU HAVE NO LIFE";
            yield return new WaitForSeconds(i);
            SceneManager.LoadScene(sceneBuildIndex: 0);
        }
        yield return new WaitForSeconds(i);
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("spikes"))
        {
            Vector2 instantiatePoint = collision.GetContact(0).point;
            Instantiate(animatino, instantiatePoint, Quaternion.identity);
            //Destroy(gameObject);
            StartCoroutine(waitBeforeFinish(-1));

        }
    }
}



