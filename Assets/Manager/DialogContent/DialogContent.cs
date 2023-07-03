using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewDialogContent", menuName = "NewDialog")]
public class DialogContent : ScriptableObject
{
    public bool istypped;
    public List<Dialog> dialogList;
}
[System.Serializable]
public class Dialog
{
    [Multiline]
    public string dialogText;
}
