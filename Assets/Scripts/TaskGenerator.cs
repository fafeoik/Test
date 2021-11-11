using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TaskGenerator : MonoBehaviour
{
    [SerializeField]
    private List<Cell> cellList = new List<Cell>();

    public List<Cell> activeLettersList { get; private set; } = new List<Cell>();

    private System.Random rnd = new System.Random();
    private int randomNumber;

    [SerializeField]
    private TMP_Text letterText;

    //Letter or anythng else that player need to find
    public string Task { get; private set; }

    public void DeleteFromActiveList(int index)
    {
        activeLettersList.RemoveAt(index);
    }
    public void GenerateLetters(int amountOfLetters)
    {
        for(int i = 0; i < amountOfLetters; i++)
        {
            randomNumber = rnd.Next(0, cellList.Count - 1);
            activeLettersList.Add(cellList[randomNumber]);
            cellList.RemoveAt(randomNumber);
        }

    }
    public void GenerateTask()
    {
        randomNumber = rnd.Next(0, activeLettersList.Count - 1);
        Task = activeLettersList[randomNumber].name;
    }

    public void ShowTaskLetter()
    {
        letterText.text = Task;
    }



}
