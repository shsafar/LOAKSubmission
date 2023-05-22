using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    [SerializeField] private PointsManager pointsManager;
    int CompletedWords;
    int TotalWordsToCompleteLevels;

    [SerializeField] private GameObject LevelCompleteUI;
    [SerializeField] private Text Points;
    [SerializeField] private Text WordsCompleted;
    private void Awake()
    {
        Instance = this;
        LevelCompleteUI.gameObject.SetActive(false);
    }
    private void Start()
    {
        WordsMatcher.Instance.OnWordComplete += wordsMather_OnWordComplete;
    }

    private void wordsMather_OnWordComplete(object sender, System.EventArgs e)
    {
        CompletedWords++;
       
    }

    private void Update()
    {
        Points.text = pointsManager.PointGainedWhilePlaying().ToString();
        WordsCompleted.text = CompletedWords.ToString();
        if (CompletedWords > 2)
        {
            //Debug.Log("Level Completed"); LevelCompleteUI.gameObject.SetActive(true);
        }
    }

    public int WordCompleted()
    {
        return CompletedWords;
    }
}
