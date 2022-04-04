using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject pausePannel;
    bool isPaused = false;

    private void Start()
    {
        pausePannel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            pausePannel.SetActive(true);
            Time.timeScale = 0;
        }

        else
        {
            pausePannel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
