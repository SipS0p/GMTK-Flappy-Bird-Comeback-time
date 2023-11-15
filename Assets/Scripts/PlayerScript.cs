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

    public Rigidbody2D PlayerRigidbody;
    public GameObject SoundManager;

    public GameObject GameOverScreen;
    public GameObject desaturationGO;

    [SerializeField] float BirdJumpHeight;
    int Score;

    [SerializeField] TMP_Text ScoreText;
    [SerializeField] TMP_Text ScoreGOText;

    bool isAlive = true;
    bool AlreadyCollided = false;

    private PlayerInput playerInput;
    // Start is called before the first frame update
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }
    void Start()
    {
        isAlive = true;
        PlayerRigidbody.velocity = Vector2.up * BirdJumpHeight;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Obstacle" || other.tag == "Ground")
        {
            PlayerDies();
        }
        else if (other.tag == "Success" && (AlreadyCollided == false))
        {
            AlreadyCollided = true;
            AddScore(1);
            Debug.Log("Score increased to: " + Score);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        AlreadyCollided = false;
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

    
    void AddScore(int ScoreToAdd)
    {
        Score = Score + ScoreToAdd;
        ScoreText.text = Score.ToString();
    }
    void PlayerDies ()
    {
        Debug.Log("Player dead");
        Invoke(nameof(GameOverPopsUp), 1);
        OnPlayerDeath?.Invoke(this, EventArgs.Empty);
        isAlive = false;
        enabled = false;
        playerInput.enabled = false;
    }

    void GameOverPopsUp ()
    {
        GameOverScreen.SetActive(true);
        ScoreText.enabled = false;
        ScoreGOText.text = "Score: " + Score.ToString();
        desaturationGO.SetActive(true);
        foreach (Transform child in desaturationGO.transform)
        {
            child.gameObject.SetActive(true);  
        }
    }

}

