using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private PointsManager pointsManager;
    [SerializeField] private GameObject BackGround;
    [SerializeField] private Text Points;
    [SerializeField] private Text WordCompleted;
    [SerializeField] private Button MainMenue;
    [SerializeField] private GameObject mainMenue;
    [SerializeField] private GameObject GamePlayUis;

  
    private void Awake()
    {
        MainMenue.onClick.AddListener(() => {
            mainMenue.SetActive(true);
            GamePlayUis.SetActive(false);
            Hide();

        });
        Hide();

        
    }
    private void Start()
    {
        GameManager.Instance.OnStateChanged += Instance_OnStateChanged;
    }
    private void Instance_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.ISGameOver())
        {
            Show();
           
        }
    }

    private void Update()
    {
        
        Points.text = pointsManager.PointGainedWhilePlaying().ToString();
        WordCompleted.text = LevelManager.Instance.WordCompleted().ToString();
    }
    void Show()
    {
        BackGround.gameObject.SetActive(true);
    }
    void Hide()
    {
        BackGround.gameObject.SetActive(false);
    }
}
