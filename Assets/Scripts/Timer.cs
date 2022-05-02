using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float currentTime;
    bool timing;
    float bestTime;
    bool paused = false;

    SceneController sceneController;

    [Header("UI Countdown Pannel")]
    public GameObject countdownPannel;
    public TMP_Text countdownText;

    [Header("UI In Game Pannel")]
    public TMP_Text timerText;

    [Header("UI Game Over Pannel")]
    public GameObject timesPannel;
    public TMP_Text myTimeResult;
    public TMP_Text bestTimeResult;

    [Header("UI")]
    public Image clockFill;
    float temp;

    void Start()
    {
        timesPannel.SetActive(false);
        countdownPannel.SetActive(false);
        timerText.text = "";
        sceneController = FindObjectOfType<SceneController>();
    }


    void Update()
    {
        if (timing && !paused)
        {
            currentTime += Time.deltaTime;
            temp += Time.deltaTime;
            if (temp > 1)
                temp = 0;
            clockFill.fillAmount = temp;
            timerText.text = currentTime.ToString("F3");
        }
        if (Input.GetKeyDown(KeyCode.P))
            PlayerPrefs.DeleteAll();
    }

    public IEnumerator StartCountdown()
    {
        bestTime = PlayerPrefs.GetFloat("BestTime" + sceneController.GetSceneName());
        if (bestTime == 0f) bestTime = 600f;

        countdownPannel.SetActive(true);
        countdownText.text = "3";
        yield return new WaitForSeconds(1);
        countdownText.text = "2";
        yield return new WaitForSeconds(1);
        countdownText.text = "1";
        yield return new WaitForSeconds(1);
        countdownText.text = "GO";
        StartTimer();
        countdownPannel.SetActive(false);

    }

    public void StartTimer()
    {
        currentTime = 0;
        timing = true;
    }

    public void StopTimer()
    {
        ChangeTimeScale(1);
        paused = false;
        timing = false;

        if (currentTime <= bestTime)
        {
            bestTime = currentTime;
            PlayerPrefs.SetFloat("BestTime" + sceneController.GetSceneName(), bestTime);
            bestTimeResult.text = bestTime.ToString("F3") + "!!NEW BEST!!";
        }
    }

    public float GetTime()
    {
        return currentTime;
    }

    public bool IsTiming()
    {
        return timing;
    }

    public void PauseTimer(bool _paused)
    {
        paused = _paused;
    }

    public void ChangeTimeScale(float _timeScale)
    {
        Time.timeScale = _timeScale;
    }
}
