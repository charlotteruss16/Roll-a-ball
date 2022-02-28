using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float currentTime;
    bool timing;

    [Header("UI")]
    public Image clockFill;

    void Update()
    {
        if (timing)
        {
            currentTime += Time.deltaTime;
            clockFill.fillAmount = Mathf.Round(currentTime * 100f) / 100f;
        }
    }

    public void StartTimer()
    {
        timing = true;
    }

    public void StopTimer()
    { 
        timing = false;
    }

    public float GetTime()
    {
        return currentTime;
    }
}
