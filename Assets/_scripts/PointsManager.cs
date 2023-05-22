using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static PointsManager Instance { get; private set; }
    private int Points;
    [SerializeField] private Text PointText;
    [SerializeField] private Text WordMatched;
    [SerializeField] private Text VowelsMatched;
    [SerializeField] private Text WrongMatched;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        PointText.text = Points.ToString();
        WordsMatcher.Instance.OnLetterMatched += WordsMatcher_OnLetterMatched;
        WordsMatcher.Instance.OnWordComplete += WordsMatcher_OnWordComplete;
        WordsMatcher.Instance.OnvowelsMatched += Instance_OnvowelsMatched;
        WordsMatcher.Instance.OnVowelMissed += Instance_OnVowelMissed;
    }

    private void Instance_OnVowelMissed(object sender, System.EventArgs e)
    {
        StartCoroutine(VowelMissed());
    }

    private void Instance_OnvowelsMatched(object sender, System.EventArgs e)
    {
        Points += 10;
        PointText.text = Points.ToString();
        StartCoroutine(VowelMatched());
    }

    private void WordsMatcher_OnWordComplete(object sender, System.EventArgs e)
    {
        Points += 300;
       
        PointText.text = Points.ToString();
        StartCoroutine(WordsMatched());
    }

    private void WordsMatcher_OnLetterMatched(object sender, System.EventArgs e)
    {
        Points += 1;
        PointText.text = Points.ToString();
        PlayerPrefs.SetInt("Points", Points);
    }


    IEnumerator WordsMatched()
    {
        WordMatched.gameObject.SetActive(true);
        yield return new WaitForSeconds(.7f);
        WordMatched.gameObject.SetActive(false);
    }
    IEnumerator VowelMatched ()
    {
        VowelsMatched.gameObject.SetActive(true);
        yield return new WaitForSeconds(.7f);
        VowelsMatched.gameObject.SetActive(false);
    }
    IEnumerator VowelMissed()
    {
        WrongMatched.gameObject.SetActive(true);
        yield return new WaitForSeconds(.7f);
        WrongMatched.gameObject.SetActive(false);
    }
    public int PointGainedWhilePlaying()
    {
        return Points;
    }
    public void ResetPoint()
    {
        Points = 0;
        PointText.text = Points.ToString();
    }
}
