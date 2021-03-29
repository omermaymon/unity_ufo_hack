using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Rocket_player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    private int count;
    public Text countText;
    public Text winText;
    public GameObject animatino;
    private int scene;
    
    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        updateCountText();
        winText.text = "";
        scene = SceneManager.GetActiveScene().buildIndex;
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if (moveVertical > 0) {   
            rb2d.AddForce(transform.right * speed);
        } else if (moveVertical < 0)
        {
            rb2d.velocity = rb2d.velocity /= new Vector2 ((float) 1.05, (float) 1.05); 
        }
        if (moveHorizontal != 0)
        {
            transform.Rotate(new Vector3(0, 0, -5) * moveHorizontal);
        } else
        {
            rb2d.freezeRotation = true;
        }
       


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
            
        } else if (count >= 15 && scene == 2)
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

        if (scene == 1)
        {
            
            winText.text = "YOU HAVE NO CHANCE";
            yield return new WaitForSeconds(i);
            SceneManager.LoadScene(sceneBuildIndex: 2);
        } else if (scene == 2)
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
            StartCoroutine(waitBeforeFinish(-1)); // plaster achush
        }
        

    }

}



