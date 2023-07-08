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
    public float duality = 40f;
    public float coins = 0f;
    public float fingers = 5f;
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
    public void Damage(int i)
    {
        duality = duality - i;
    }
    public void AddCoins(int i)
    {
        coins = coins + i;
    }
    public List<float> GetData()
    {
        return new List<float>
        {
            coins,fingers,duality,
        };
    }
    public void ResetDuality()
    {
        coins = 0f;
        fingers = 5f;
        duality = 40f;
    }
    public void ChangeSprite(FingerOption option)
    {
        spriteRenderer.sprite = sprites[(int)option];
    }
}
