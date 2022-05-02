using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerupType {PauseTimer, SlowMo}

    public PowerupType myPowerUp;
    public float powerUpDuration = 7f;
    Timer timer;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    public void UsePowerUp()
    {
        if (myPowerUp == PowerupType.PauseTimer)
            timer.PauseTimer(true);

        if (myPowerUp == PowerupType.SlowMo)
            timer.ChangeTimeScale(0.4f);

        StartCoroutine(ResetPowerUp());
    }

    IEnumerator ResetPowerUp()
    {
        yield return new WaitForSeconds(powerUpDuration);
        if (myPowerUp == PowerupType.PauseTimer)
            timer.PauseTimer(false);
        if (myPowerUp == PowerupType.SlowMo)
            timer.ChangeTimeScale(1);
    }

}
