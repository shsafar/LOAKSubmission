using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public event EventHandler OnStateChanged;

    bool over = false;

    [SerializeField] private GameObject GamPLayUIs;
    [SerializeField] private GameObject Environment;
    [SerializeField] private GameObject mainMenue;
    private enum State
    {
        PressPlayToStart,
        CountDownStart,
        GamePlaying,
        GameOver,
    }

    private State state;
    private float CountDownToStartTimer = 3;
    public float GamePlayingTimer = 120;
    float maximunTime = 120;

    private void Awake()
    {
        Instance = this;
        state = State.PressPlayToStart;

    }
    private void Update()
    {
        
        switch (state)
        {
            case State.PressPlayToStart:
                {
                    GamPLayUIs.SetActive(false);
                    Environment.SetActive(false);
                    PointsManager.Instance.ResetPoint();
                    WordsMatcher.Instance.PLAYERLIFEREST();
                    CountDownToStartTimer = 3;
                    break;
                }
            case State.CountDownStart:
                {
                  
                    CountDownToStartTimer -=Time.deltaTime;
                    if (CountDownToStartTimer < 0)
                    {
                        over = false;
                        state = State.GamePlaying;
                        OnStateChanged?.Invoke(this, EventArgs.Empty);
                    }
                    break;
                }
            case State.GamePlaying:
                {
                    GamePlayingTimer -= Time.deltaTime;
                    GamPLayUIs.SetActive(true);
                    Environment.SetActive(true);
                    if (GamePlayingTimer < 0)
                    {
                        state = State.GameOver;
                        OnStateChanged?.Invoke(this, EventArgs.Empty);
                    }
                    break;
                }
            case State.GameOver:
                {
                    GamPLayUIs.SetActive(false);
                    Environment.SetActive(false);
                    if (over==false)
                    {
                        OnStateChanged?.Invoke(this, EventArgs.Empty);
                        PointsManager.Instance.ResetPoint();
                        WordsMatcher.Instance.PLAYERLIFEREST();
                        CountDownToStartTimer = 3;
                        over = true;
                    }
                    break;
                }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            state = State.CountDownStart;
        }
       
        if(WordsMatcher.Instance.PlayerLife() <= 0)
        {
            state = State.GameOver;
        }
    }

    public void PlayButton()
    {
        state = State.CountDownStart;
        GamePlayingTimer = maximunTime;
    }
    public void Home()
    {
        state = State.PressPlayToStart;
        Time.timeScale = 1f;
        PointsManager.Instance.ResetPoint();
    }
    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }

    public bool IsCountdownToStartActive()
    {
        return state == State.CountDownStart;
    }
   
    public bool ISGameOver()
    {
        return state == State.GameOver;
    }

    public float Timer()
    {
        return GamePlayingTimer;
    }
    public float countDownToStartTimer()
    {
        return CountDownToStartTimer;
    }

    public void MainMenue()
    {
        state = State.PressPlayToStart;
        mainMenue.SetActive(true);
        PointsManager.Instance.ResetPoint();
        Time.timeScale = 1f;
    }
}
