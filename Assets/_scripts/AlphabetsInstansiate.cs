using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetsInstansiate : MonoBehaviour
{
    [SerializeField] private GameObject[] Alphabets;
    [SerializeField] private GameObject[] InstansiatePoint;
    public   GameObject Alphs;
    public float InstansiateSpeed  = .7f;
    private void Awake()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        StartCoroutine(Instansiate());
    }
    IEnumerator Instansiate()
    {
        if (GameManager.Instance.IsGamePlaying())
        {
            yield return new WaitForSeconds(InstansiateSpeed);
            //var test = InstansiatePoint[Random.Range(0, InstansiatePoint.Length)];
           
            Alphs = Instantiate(Alphabets[Random.Range(0, Alphabets.Length)], InstansiatePoint[Random.Range(0, InstansiatePoint.Length)].transform.position, InstansiatePoint[Random.Range(0, InstansiatePoint.Length)].transform.rotation);
            Debug.Log(Alphs.name);
            Alphs.transform.Rotate(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
            StartCoroutine(Instansiate());
        }
        
    }
}
