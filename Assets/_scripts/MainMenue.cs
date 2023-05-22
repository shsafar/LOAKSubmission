using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMenue : MonoBehaviour
{
    [SerializeField] private Button PLay;
 
    [SerializeField] private Button Setting;
    [SerializeField] private Button Quit;


    private void Awake()
    {
        PLay.onClick.AddListener(() => {

            GameManager.Instance.PlayButton();
            gameObject.SetActive(false);
        });
        Quit.onClick.AddListener(() => {

            Application.Quit();
        });
    }
}
