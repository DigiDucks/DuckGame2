using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireInput : MonoBehaviour
{
    public int wireNumber;
    char wireColor;

    WireManager manager;

    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<WireManager>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        changeAlpha(0.5f);
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Button Pressed " + ToString());
            Debug.Log(wireColor);
            if(manager.GetCorrectWire() == wireNumber)
            {
                GameManager.instance.Won();
                Debug.Log("Correct");
            }
            else
            {
                GameManager.instance.Lost();
                Debug.Log("Wrong");
            }
        }
    }

    private void OnMouseExit()
    {
        changeAlpha(1.0f);
    }

    void changeAlpha(float a)
    {
        Color change = new Color(sprite.color.r, sprite.color.g, sprite.color.b, a);
        sprite.color = change;
    }

    public void SetColor(char color)
    {
        wireColor = color;
    }

    public char GetColor()
    {
        return wireColor;
    }
}
