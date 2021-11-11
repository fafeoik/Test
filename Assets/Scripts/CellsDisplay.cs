using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellsDisplay : MonoBehaviour
{
    [SerializeField]
    private Transform CellPrefab;

    private TaskGenerator taskGenerator;
    private FadeEffect fadeEffect;

    [SerializeField]
    private CanvasGroup taskCanvas;
    [SerializeField]
    private CanvasGroup gameCanvas;

    [SerializeField]
    private GameObject restartPanel;


    [SerializeField]
    private List<LevelGrid> GridList = new List<LevelGrid>();
    private GridLayoutGroup GridPanel;

    private int cellAmount;
    public int CurrentLvlIndex { get; private set; }
    void Start()
    {
        fadeEffect = FindObjectOfType<FadeEffect>();
        taskGenerator = FindObjectOfType<TaskGenerator>();
        GridPanel = GetComponent<GridLayoutGroup>();

        CurrentLvlIndex = 0;
        BuildLevel();
    }

    private void BuildLevel()
    {
        cellAmount = GridList[CurrentLvlIndex].ColumnAmount * GridList[CurrentLvlIndex].RowAmount;
        taskGenerator.GenerateLetters(cellAmount);
        taskGenerator.GenerateTask();
        taskGenerator.ShowTaskLetter();
        fadeEffect.FadeIn(1f, taskCanvas);
        BuildGrid();
    }
    public void BuildGrid()
    {
        GridPanel.constraintCount = GridList[CurrentLvlIndex].ColumnAmount;
        CreateCells();
    }

    private void CreateCells()
    {
        
        for (int i = 0; i < cellAmount; i++)
        {
            Instantiate(CellPrefab, gameObject.transform);
        }
    }

    public void ChangeLvl()
    {
        CurrentLvlIndex += 1;
        if(CurrentLvlIndex >= GridList.Count)
        {
            ShowRestartPanel();
            fadeEffect.FadeOut(2f, gameCanvas);
        }
        else
        {
            BuildLevel();
        }

    }

    private void ShowRestartPanel()
    {
        restartPanel.SetActive(true);
    }
}
