using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    [SerializeField] private Text TimerText;

    float time;
    private void Awake()
    {
        TimerText.gameObject.SetActive(false);
    }
    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
       
    }

    private void Update()
    {
        time = Mathf.Ceil(GameManager.Instance.countDownToStartTimer());
        TimerText.text = time.ToString();
        if (GameManager.Instance.IsCountdownToStartActive())
        {
            TimerText.gameObject.SetActive(true);
            if (GameManager.Instance.countDownToStartTimer()<.5)
            {
                TimerText.text = "GO";
            }


        }
        else
        {
            TimerText.gameObject.SetActive(false);
        }
    }
}
