using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Grid", menuName = "LevelGrid")]
public class LevelGrid : ScriptableObject
{
    public int ColumnAmount;
    public int RowAmount;
}
