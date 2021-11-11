using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellScript : MonoBehaviour
{
    private TaskGenerator taskGenerator;
    private AnswerChecker answerChecker;

    private Animator cellAnimator;
    private System.Random rnd = new System.Random();
    private Cell thisCell;
    private GameObject letterObj;
    public string letter { get; private set; }
    private int RandomNumber;

    private GameObject starsObj;
    private void Awake()
    {
        answerChecker = FindObjectOfType<AnswerChecker>();
        letterObj = gameObject.transform.Find("Letter").gameObject;
        starsObj = gameObject.transform.Find("Stars").gameObject;
        taskGenerator = FindObjectOfType<TaskGenerator>();
        ChooseLetter();
        SetCellInfo();
        GetComponent<Animator>().SetTrigger("Bounce");
    }

    private void ChooseLetter()
    {
        RandomNumber = rnd.Next(0, taskGenerator.activeLettersList.Count - 1);
        thisCell = taskGenerator.activeLettersList[RandomNumber];
        taskGenerator.DeleteFromActiveList(RandomNumber);
    }
    private void SetCellInfo()
    {
        letterObj.GetComponent<Image>().sprite = thisCell.CellImage;
        letter = thisCell.CellName;
    }

    public void ActicateChecker()
    {
        answerChecker.letterObj = letterObj;
        answerChecker.pressedCell = thisCell;
        answerChecker.cellObj = gameObject;
        answerChecker.CheckAnswer();
    }
    public void StartParticles()
    {
        starsObj.GetComponent<ParticleSystem>().Play();
    }
}
