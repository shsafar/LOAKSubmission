using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private Button pause;
    [SerializeField] private Button Unpause;
  
    [SerializeField] private GameObject BackGround;
    private void Awake()
    {
        pause.onClick.AddListener(() => {

            BackGround.SetActive(true);
            Time.timeScale = 0f;
        });
        Unpause.onClick.AddListener(() => {

            BackGround.SetActive(false);
            Time.timeScale = 1f;
        });

       

    }
}
