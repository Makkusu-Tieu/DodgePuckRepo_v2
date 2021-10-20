using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float xRange;
    public float yRange;
    public GameObject Puck;
    public GameObject Blocky;
    public GameObject scoreText;
    public GameObject gameOverText;
    public GameObject highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Blocky, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);

        Instantiate(Puck, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);
    }

    private void LateUpdate()
    {
        if (transform.position.x > xRange)
        {
            transform.position = new Vector2(xRange, transform.position.y);
        }

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector2(-xRange, transform.position.y);
        }

        if (transform.position.y > yRange)
        {
            transform.position = new Vector2(transform.position.x, yRange);
        }
        
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector2(transform.position.x, -yRange);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        //Instantiate(Puck, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);


        GameObject[] puckArray;
        puckArray = GameObject.FindGameObjectsWithTag("Puck");
        Debug.Log("Puck Count: " + puckArray.Length);

        float moveHorizontal = (Input.GetAxisRaw("Horizontal"));

        float moveVertical = (Input.GetAxisRaw("Vertical"));

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        transform.Translate(movement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Blocky"))
        {
            Destroy(other.gameObject);
            Debug.Log("Hit Blocky");

            Instantiate(Blocky, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);
            
            Instantiate(Puck, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);

            scoreText.GetComponent<ScoreKeeper>().scoreValue += 5;
            scoreText.GetComponent<ScoreKeeper>().UpdateScore();

            scoreText.GetComponent<ScoreKeeper>().UpdateHighScore();
        }

        if (other.gameObject.CompareTag("Puck"))
        {
            Time.timeScale = 0;
            gameOverText.SetActive(true);
        }
    }

    public void NewGame()
    {
        Debug.Log("It's a new game!");
        
        GameObject[] allPucks = GameObject.FindGameObjectsWithTag("Puck");
        foreach (GameObject dude in allPucks)
            GameObject.Destroy(dude);

        GameObject[] allBlockys = GameObject.FindGameObjectsWithTag("Blocky");
        foreach (GameObject dude in allBlockys)
            GameObject.Destroy(dude);

        transform.position = new Vector2(0, 0);
        
        Instantiate(Blocky, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);
        Instantiate(Puck, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);
        
        gameOverText.SetActive(false);
        Time.timeScale = 1;

        scoreText.GetComponent<ScoreKeeper>().scoreValue = 0;
        scoreText.GetComponent<ScoreKeeper>().UpdateScore();
    }
}
