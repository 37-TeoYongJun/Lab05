using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public float totalCoins;
    public float timeLeft;
    public float timeRemaining;

    private float score;
    private float timeValue;

    public Text scoreText;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        timeRemaining = Mathf.FloorToInt(timeLeft % 60);

        timeText.text = "Time: " + timeRemaining.ToString();

        if (score >= totalCoins)
        {
            if (timeLeft >= timeValue)
            {
                SceneManager.LoadScene("GameWinScene");
            }
        }

        else if (timeLeft <= 0)
        {
            SceneManager.LoadScene("GameLoseScene");
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        ParticleSystem collect = GameObject.Find("CollectParticle").GetComponent<ParticleSystem>();

        if (collision.gameObject.tag == "Coin")
        {
            collect.Play();

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
