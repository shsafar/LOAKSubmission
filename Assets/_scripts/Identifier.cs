using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Identifier : MonoBehaviour
{
    [SerializeField]private WordsMatcher wordsMatcher;
    public LayerMask Text;
    //[SerializeField]public Text[] texts;


   
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 pos = touch.position;
            Ray ray = Camera.main.ScreenPointToRay(pos);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999, Text))
            {
                if (GameManager.Instance.IsGamePlaying())
                {
                  //  GameObject bullet = Instantiate(Bullet, Muzzal);
                    wordsMatcher.Macther(raycastHit);
                }
            }
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 pos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(pos);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999, Text))
            {
                if (GameManager.Instance.IsGamePlaying())
                {
                    Debug.Log(raycastHit.transform.name);
                    wordsMatcher.Macther(raycastHit);
                }
            }
        }
       
    }
}
