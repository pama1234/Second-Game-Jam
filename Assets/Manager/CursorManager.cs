using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorManager : Singleton<CursorManager>
{
    private Vector2 mousePos;
    private void Start()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 1f);
        Cursor.visible = false;
    }
    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = new Vector3(mousePos.x, mousePos.y, 1f);
    }
}
