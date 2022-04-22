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
    GameObject resetPoint;
    bool resetting = false;
    Color originalColour;
    Timer timer;
    GameController gameController;

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

        resetPoint = GameObject.Find("ResetPoint");
        originalColour = GetComponent<Renderer>().material.color;
        gameController = FindObjectOfType<GameController>();
        
    }

    private void Update()
    {
        UpdateTimer();
    }

    void FixedUpdate()
    {
        if (resetting)
            return;
        if (gameController.controlType == ControlType.WorldTilt)
            return;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            other.GetComponent<Particles>().CreateParticles();
            Destroy(other.gameObject);
            score++;
            UpdateScore();
            if (score == PickupCont)
            {
                WinGame();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            StartCoroutine(ResetPlayer());
        }
    }

    public IEnumerator ResetPlayer()
    {
        resetting = true;
        GetComponent<Renderer>().material.color = Color.black;
        rb.velocity = Vector3.zero;
        float resetSpeed = 2f;
        Vector3 startPos = transform.position;
        var i = 0.0f;
        var rate = 1.0f / resetSpeed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(startPos, resetPoint.transform.position, i);
            yield return null;
        }

        GetComponent<Renderer>().material.color = originalColour;
        resetting = false;
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
