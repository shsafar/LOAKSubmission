using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Text TimeText;

    float time;
    private void Update()
    {
        time = GameManager.Instance.Timer();
        string minute = ((int)time / 60).ToString();
        string seconds = (time % 60).ToString("f00");
        TimeText.text = minute + ":" + seconds;
    }

}
