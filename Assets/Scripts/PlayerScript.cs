using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI ;

public class PlayerScript : MonoBehaviour
{
    public event EventHandler OnSpacePressed;
    public event EventHandler OnPlayerDeath;
    public event EventHandler OnSuccess;


    public Rigidbody2D PlayerRigidbody;
    public GameObject SoundManager;

    public GameObject GameOverScreen;
    public GameObject desaturationGO;

    [SerializeField] float BirdJumpHeight;
    int score;
    int highScore;
    int coins;

    [SerializeField] TMP_Text ScoreText;
    [SerializeField] TMP_Text ScoreGOText;
    [SerializeField] TMP_Text HighScoreGOText;
    [SerializeField] TMP_Text CoinGOText;

    bool alreadyCollided = false;
    float timeUntilAbleToCollideAgain;


    private PlayerInput playerInput;
    // Start is called before the first frame update
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }
    void Start()
    {
        PlayerRigidbody.velocity = Vector2.up * BirdJumpHeight;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Obstacle" || other.tag == "Ground")
        {
            PlayerDies();
        }
        else if (other.tag == "Success" && alreadyCollided == false)
        {
            alreadyCollided = true;
            AddScore(1);
            Debug.Log("Score increased to: " + score);
            OnSuccess?.Invoke(this, EventArgs.Empty);

        }
        else if (other.tag == "Coins" && alreadyCollided == false)
        {
            alreadyCollided = true;
            timeUntilAbleToCollideAgain = 1f;
            Destroy(other.gameObject);
            AddCoins(1);
            OnSuccess?.Invoke(this, EventArgs.Empty);
        }
        else if (other.tag == "Gem" && alreadyCollided == false)
        {
            alreadyCollided = true;
            timeUntilAbleToCollideAgain = 1f;
            Destroy(other.gameObject);
            AddCoins(5);
            OnSuccess?.Invoke(this, EventArgs.Empty);
        }
    }
    private void Update()
    {
        if (timeUntilAbleToCollideAgain < 0)
        {
            alreadyCollided = false;
        }
        else
        {
            timeUntilAbleToCollideAgain -= Time.deltaTime;
        }
    }


    public void Flap (InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
            PlayerRigidbody.velocity = Vector2.up * BirdJumpHeight;
            OnSpacePressed?.Invoke(this, EventArgs.Empty);
            //Send event "Player jumped" to AudioManagerScript
        }
    }

    
    void AddCoins(int coinsToAdd)
    {
        coins += coinsToAdd;
        ScoreText.text = score.ToString();
    }

    void AddScore(int ScoreToAdd)
    {
        score += ScoreToAdd;
        ScoreText.text = score.ToString();
    }
    void PlayerDies ()
    {
        if (score > highScore)
        {
            
            PlayerPrefs.SetInt("HighScore", score);
            Debug.Log("Highscore: " + highScore);
        }
        else
        {
            Debug.Log("Highscore:" + score);
        }
        Debug.Log("Player dead");
        Invoke(nameof(GameOverPopsUp), 1);
        OnPlayerDeath?.Invoke(this, EventArgs.Empty);
        enabled = false;
        playerInput.enabled = false;
    }

    void GameOverPopsUp ()
    {
        GameOverScreen.SetActive(true);
        ScoreText.enabled = false;
        ScoreGOText.text = "Score:   " + score.ToString();
        CoinGOText.text = "Coins: " + coins.ToString();
        HighScoreGOText.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0);
        desaturationGO.SetActive(true);
        foreach (Transform child in desaturationGO.transform)
        {
            child.gameObject.SetActive(true);  
        }
    }

}

