using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    [SerializeField] GameObject gameObjct;
    public bool shown = false;
    // Start is called before the first frame update
    void Start()
    {

        shown = (PlayerPrefs.GetInt("shown")) == 1 ? true : false;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!shown&&GameManager.Instance.IsGamePlaying())
        {
            gameObjct.SetActive(true);
            shown = true;
            PlayerPrefs.SetInt("shown", shown ? 1 : 0);
        }
    }
}
