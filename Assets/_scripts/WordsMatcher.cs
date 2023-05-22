using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class WordsMatcher : MonoBehaviour
{
    public static WordsMatcher Instance { get; private set; }

    public event EventHandler OnWordComplete;
    public event EventHandler OnLetterMatched;
    public event EventHandler OnVowelMissed;

    public event EventHandler OnvowelsMatched;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip Impact;
    [SerializeField] private AudioClip WordComplete;
    [SerializeField] private AudioClip MissedVowel;
    //Letters that we Need TO Identify
    [SerializeField]private Text[] LettersToFind;

    //Letters That are already been found
    [SerializeField]private string[] LetterThatfound;

    //The Word That we Need To Complete
    [SerializeField]private string ActualWord;

    [Header("String Array Of Random Word ")]
    [SerializeField] private string[] Word;
    
    //Text That we Are Going to Store Our Letters Of String In herarchy There Must Be An Text Object
    [SerializeField]private Text[] StringToTextWords;
    

    //Text That we Are Going To Use To Assign To StringToTextWords On Runtime Accourding To Lenght
    [SerializeField]private Text[] TextToStoreStringToTextWords;

    //Int to Keep Track of How Many Letters Are Remainig
    int wordSize;

    int playerLife;
    [SerializeField] private Text lifeText;
    private void Awake()
    {
        Instance = this;
        playerLife = 3;
    }
    private void Update()
    {
        lifeText.text = playerLife.ToString();
        if (wordSize == 0)
        {
            for (int i = 0; i < LettersToFind.Length; i++)
            {
                if (LetterThatfound[i] == LettersToFind[i].ToString())
                {
                    OnWordComplete?.Invoke(this, EventArgs.Empty);
                    audioSource.PlayOneShot(WordComplete);
                }
            }
            ConvertStringToTextGameObjects();
            //Restoring The The Properties After The Word Is Commpleted
            RestoreText();
            //To Check If the Word Actualy Completed
           
            
        }
        
    }
    public void Macther(RaycastHit raycastHit)
    {
        
        for (int i = 0; i < LettersToFind.Length; i++)
        {
            if (raycastHit.transform.GetComponent<TextMesh>().text == LettersToFind[i].text)
            {
               //Cycling Through Each Letter And String TO Find The Matching Word
                if (LetterThatfound[i] != LettersToFind[i].ToString() )
                {
                    
                    LetterThatfound[i] = LettersToFind[i].ToString();
                    LettersToFind[i].color = Color.green;
                    Destroy(raycastHit.transform.gameObject);
                    wordSize--;
                    AudioSource.PlayClipAtPoint(Impact, raycastHit.transform.position);
                    Debug.Log(wordSize);
                    if (LettersToFind[i].text == "A" || LettersToFind[i].text == "E"
                        || LettersToFind[i].text == "I" || LettersToFind[i].text == "O" || LettersToFind[i].text == "U") { Debug.Log("Vowels"); OnvowelsMatched?.Invoke(this, EventArgs.Empty); }
                    else { OnLetterMatched?.Invoke(this, EventArgs.Empty); }
                    break;
                }
            }
            else 
            {
            }
        }
    }

    private void ConvertStringToTextGameObjects()
    {
        ActualWord = Word[UnityEngine.Random.Range(0, Word.Length)];

        StringToTextWords = new Text[ActualWord.ToString().Length];
        //Converting String Into Text By Assign Each Text Single String Value
        for (int i = 0; i < ActualWord.ToString().Length; i++)
        {
            //Assigning Text GameObject of letters to StringToTextWords so we can display them
            StringToTextWords[i] = TextToStoreStringToTextWords[i];
            //Assigning Each String to Each Assisgned Text
            StringToTextWords[i].text = ActualWord.ToString().Substring(i, 1);

            //Turning On TextToStoreStringToTextWords Only That we Want To Use
            if (StringToTextWords.Length <= TextToStoreStringToTextWords.Length)
            {
                TextToStoreStringToTextWords[i].gameObject.SetActive(true);
            }

        }

        //Turning Off Not Usable TextToStoreStringToTextWords in Herarchy for Better Looks
        for (int y = StringToTextWords.Length; y < TextToStoreStringToTextWords.Length; y++)
            {
            if (StringToTextWords.Length < TextToStoreStringToTextWords.Length) 
                {
                    TextToStoreStringToTextWords[y].gameObject.SetActive(false);
                }
            }

       

        //Properties Of Our Goal
        LettersToFind = StringToTextWords;
        wordSize = LettersToFind.Length;
        LetterThatfound = new string[LettersToFind.Length];
    }
    private void RestoreText()
    {
        //FindObjectOfType<Text>().color = Color.white;
        for (int i = 0; i < StringToTextWords.Length; i++)
        {
            StringToTextWords[i].color = Color.white;
        }
    }
    public void CheckMisssed(Collider collider)
    {
        for (int i = 0; i < LettersToFind.Length; i++)
        {
          if (collider.transform.GetComponent<TextMesh>().text == LettersToFind[i].text)
            {
                if((LetterThatfound[i] != LettersToFind[i].ToString())){
                    if (LettersToFind[i].text == "A" || LettersToFind[i].text == "E"
                        || LettersToFind[i].text == "I" || LettersToFind[i].text == "O" || LettersToFind[i].text == "U") {
                        AudioSource.PlayClipAtPoint(MissedVowel, collider.transform.position);
                        playerLife--;
                       // Debug.Log(playerLife);
                        OnVowelMissed?.Invoke(this, EventArgs.Empty);
                        break;
                    }
                }
            }
        }
    }
    public int PlayerLife()
    {
        return playerLife;
    }
    public void PLAYERLIFEREST()
    {
        playerLife = 3;
    }
}
