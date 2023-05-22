using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WordsGenerator : MonoBehaviour
{
    [Header("First Words")]
    [SerializeField] private string[] Words;
    public string[] character;
    [SerializeField] private Text Assigned;

    private void Start()
    {
        //for (int i = 0; i < AlphabetsToMatch.text.Length; i++)
        //{
        //    string[] sr = new string[AlphabetsToMatch.text.Length];
        //    // if (raycastHit.transform.GetComponent<TextMesh>().text == AlphabetsToMatch[i].text)
        //    if (raycastHit.transform.GetComponent<TextMesh>().text.ToString() == sr[i].ToString())
        //    {
        //        Debug.Log(sr[i]);
        //        AlphabetsToMatch.text = sr.ToString().Substring(0, i);


        //    }
        //}
        AssignedWord();
    }
    private void AssignedWord()
    {
        Assigned.text = Words[Random.Range(0, Words.Length)].ToString();
        character = new string[Assigned.text.Length];

       // Debug.Log(Assigned.text.Length);
        for (int i = 0; i < Assigned.text.Length; i++)
        {
            character[i] = Assigned.text.Substring(i,1);
        }
    }

}
