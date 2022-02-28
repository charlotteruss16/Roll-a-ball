using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5;
    public int score;
    int PickupCont;
    Timer timer;

    [Header("UI")]
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text winMessageText;
    public GameObject inGamePannel;
    public GameObject winPannel;

    void Start()
    {
        score = 0;
        rb = GetComponent<Rigidbody>();
        PickupCont = GameObject.FindGameObjectsWithTag("Pickup").Length;
        timer = FindObjectOfType<Timer>();
        timer.StartTimer();
        UpdateScore();
        inGamePannel.SetActive(true);
        winPannel.SetActive(false);
        
    }

    private void Update()
    {
        UpdateTimer();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
            score++;
            UpdateScore();
            if (score == PickupCont)
            {
                WinGame();
            }
        }
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString() + "/" + PickupCont.ToString();
    }

    void UpdateTimer()
    {
        timerText.text = "Time: " + timer.GetTime().ToString("F2");
    }
    void WinGame()
    {
        timer.StopTimer();
        inGamePannel.SetActive(false);
        winPannel.SetActive(true);
        winMessageText.text = "Your time was: " + timer.GetTime().ToString("F2");
 
    }
}
