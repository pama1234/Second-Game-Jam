using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum FingerOption
{
    five,
    four,
    three,
    two,
    one,
    zero,
}
public class CursorManager : Singleton<CursorManager>
{
    private Vector2 mousePos;
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 1f);
        Cursor.visible = false;
    }
    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, 1f);
    }
    public void ChangeSprite(FingerOption option)
    {
        spriteRenderer.sprite = sprites[(int)option];
    }
}
