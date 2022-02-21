using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5;
    public int score;
    int PickupCont;
    Timer timer;

    void Start()
    {
        score = 0;
        rb = GetComponent<Rigidbody>();
        PickupCont = GameObject.FindGameObjectsWithTag("Pickup").Length;
        timer = FindObjectOfType<Timer>();
        timer.StartTimer();
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
            if (score == PickupCont)
            {
                WinGame();
            }
        }
    }

    void WinGame()
    {
        timer.StopTimer();
        print("YOU WIN!!!! YAY!!!! Your time was: " + timer.GetTime().ToString("F2"));
 
    }
}
