using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewDialogContent", menuName = "Game/NewDialog")]
public class DialogContent : ScriptableObject
{
    public List<Dialog> dialogList;
}
[System.Serializable]
public class Dialog
{
    [Multiline]
    public string dialogText;
}
