using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LadderBoard : MonoBehaviour
{
    [SerializeField] private Button ladderBoard;

    [SerializeField] private Button Exit;
    [SerializeField] private Text HighScore;
  public   int HighScorre;
    [SerializeField] private PointsManager pointsManager;

    [SerializeField] private GameObject Whole;
    private void Awake()
    {
        Whole.SetActive(false);
        ladderBoard.onClick.AddListener(() =>
        {
            Whole.SetActive(true);
        });

        Exit.onClick.AddListener(() =>
        {
            Whole.SetActive(false);
        });

     
    }

    private void Instance_OnLetterMatched(object sender, System.EventArgs e)
    {
       
    }

    private void Start()
    {
        HighScorre = PlayerPrefs.GetInt("HighScorre");
        WordsMatcher.Instance.OnLetterMatched += Instance_OnLetterMatched;
    }
    private void Update()
    {
       
        if (pointsManager.PointGainedWhilePlaying() > HighScorre)
        {
            int point = pointsManager.PointGainedWhilePlaying();
            HighScorre += 0;

            HighScorre += point;
            PlayerPrefs.SetInt("HighScorre", HighScorre);

        }
        
        HighScore.text = HighScorre.ToString();
    }
}
