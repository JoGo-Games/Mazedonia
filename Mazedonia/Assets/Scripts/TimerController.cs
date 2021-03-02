using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public float seconds = 0.0f;
    public int minutes = 0;

    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= 60.0f)
        {
            seconds -= 60.0f;
            minutes += 1;
        }
        timeText.text = "" + minutes.ToString("00") + ":" + seconds.ToString("00.00").Replace(",", ":");
    }
}
