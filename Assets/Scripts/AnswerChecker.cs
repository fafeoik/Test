using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AnswerChecker : MonoBehaviour
{
    private TaskGenerator taskGenerator;
    public GameObject letterObj;
    public Cell pressedCell;
    public GameObject cellObj;
    private Animator letterAnim;
    private Button[] buttons;
    void Start()
    {

        taskGenerator = FindObjectOfType<TaskGenerator>();
    }

    public void CheckAnswer()
    {
        letterAnim = letterObj.GetComponent<Animator>();
        if (pressedCell.CellName == taskGenerator.Task)
        {
            CorrectAnswer();
        }
        else
        {
            WrongAnswer();
        }
    }
    private void CorrectAnswer()
    {
        
        buttons = FindObjectsOfType<Button>();
        foreach(var item in buttons)
        {
            item.enabled = false;
        }
        letterAnim.SetTrigger("Right");
        cellObj.GetComponent<CellScript>().StartParticles();
        
        Invoke("ChangeLevel", 1f);
    }

    private void ChangeLevel()
    {
        foreach (var item in buttons)
        {
            Destroy(item.gameObject);
        }
        FindObjectOfType<CellsDisplay>().ChangeLvl();
    }

    private void WrongAnswer()
    {
        letterAnim.SetTrigger("Wrong");
    }


}
