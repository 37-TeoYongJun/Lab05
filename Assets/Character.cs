using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    private float score;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            score += 10;
            scoreText.text = "Score: " + score;

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.layer == 4)
        {
            SceneManager.LoadScene("GameLoseScene");
        }
    }
}
