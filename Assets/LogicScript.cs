using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public static LogicScript logicScript;

    bool isGameOver;
    [HideInInspector] public bool isGameStart = false;

    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;

    public int playerLife;
    public int maxLife;

    public Image[] life;
    public Sprite fullLife;
    public Sprite emptyLife;

    public TextMeshProUGUI Score_value;
    public TextMeshProUGUI HScore_value;
    int highScore;

    public float invSpan = 3;
    float invTimer;
    bool justOnce = false;
    [HideInInspector] public bool invulnerable = false;

    public AudioSource score;
    public AudioSource invul;
    public AudioSource lifeFX;

    [ContextMenu("Increase Score")]

    void Awake()
    {
        if (logicScript == null)
        {
            logicScript = this;
        }

        else if (logicScript != this)
        {
            Destroy(gameObject);
        }

        SummonHighScore();

        isGameOver = false;
    }
    void Update()
    {
        UpdateLife();
        UpdateHighScore();
        UpdateScore();

        //Debug.Log(highScore);

        if (invulnerable == true && justOnce == false)
        {
            justOnce = true;
            invTimer = invSpan;

            GameObject[] pillar;

            pillar = GameObject.FindGameObjectsWithTag("Danger");

            foreach (GameObject pill in pillar)
            {
                pill.GetComponent<PolygonCollider2D>().enabled = false;

                Animator animator = pill.GetComponent<Animator>();

                animator.SetBool("ColliderOff", true);
            }

            InvCoolDown();
        }
    }
    public void addscore(int score)
    {
        playerScore = playerScore + score;
        scoreText.text = playerScore.ToString();

    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        isGameOver = true;
        gameOverScreen.SetActive(true);
    }

    void UpdateLife()
    {
        if (playerLife > maxLife)
        {
            playerLife = maxLife;
        }

        for (int i = 0; i < life.Length; i++)
        {

            if (i < playerLife)
            {
                life[i].sprite = fullLife;
            }
            else
            {
                life[i].sprite = emptyLife;
            }

            if (i < maxLife)
            {
                life[i].enabled = true;
            }
            else
            {
                life[i].enabled = false;
            }

        }
    }

    void SummonHighScore()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
    }

    void UpdateHighScore()
    {
        if (playerScore > highScore && isGameOver == false)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("highScore", highScore);
        }

        if (isGameOver == false)
        {
            HScore_value.text = highScore.ToString();
        }
    }

    void UpdateScore()
    {
        Score_value.text = playerScore.ToString();
    }

    public void ClearHighScore()
    {
        PlayerPrefs.SetInt("highScore", 0);
        HScore_value.text = "0";
    }

    public void InvCoolDown()
    {
        while (invulnerable == true)
        {
            invTimer -= Time.deltaTime;

            if (invTimer <= 0)
            {
                justOnce = false;
                invulnerable = false;
            }
        }
    }

    public void PlayScoreSFX()
    {
        score.Play();
    }

    public void PlayInvulSFX()
    {
        invul.Play();
    }

    public void PlayLifeSFX()
    {
        lifeFX.Play();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
