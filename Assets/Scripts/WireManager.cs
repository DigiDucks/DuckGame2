using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireManager : MonoBehaviour
{
    [SerializeField] GameObject codeLocation;
    [SerializeField] Color[] wireColors;
    [SerializeField] GameObject[] wires;

    int correctWire;
    char correctWireColor;

    char[] wireChar = { 'W', 'R', 'Y', 'G', 'B' };

    WireInput[] wireScripts = new WireInput[5];
    SpriteRenderer[] sprites = new SpriteRenderer[5];
    int[] usedColors = new int[5];

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            sprites[i] = wires[i].GetComponent<SpriteRenderer>();
            wireScripts[i] = wires[i].GetComponent<WireInput>();
        }
        assignColors();
    }

    // Update is called once per frame
    void Update()
    {
        if(correctWire < 0)
        {
            for(int i = 0; i < 5; i++)
            {
                if(wireScripts[i].GetColor() == correctWireColor)
                {
                    correctWire = i;
                    Debug.Log("Correct Wire Should Be: " + correctWire);
                }
            }
        }
    }

    int randInt(int min, int max)
    {
        float randF = Random.Range(min, max);
        int rounded = (int)randF;
        return rounded;
    }

    void assignColors()
    {
        int randomNumber = randInt(0, 5);
        // Debug.Log(randomNumber.ToString());
        usedColors[0] = randomNumber;
        sprites[0].color = wireColors[randomNumber];
        wireScripts[0].SetColor(wireChar[randomNumber]);

        for (int i = 1; i < 5; i++)
        {
            randomNumber = randInt(0, 5);
            for (int j = 0; j < i; j++)
            {
                if (usedColors[j] == randomNumber)
                {
                    randomNumber = randInt(0, 5);
                    j = -1;
                }
            }
            // Debug.Log(randomNumber.ToString());
            usedColors[i] = randomNumber;
            sprites[i].color = wireColors[randomNumber];
            wireScripts[i].SetColor(wireChar[randomNumber]);
        }
    }

    public void SetBomb(int code, int wire)
    {
        TMPro.TextMeshPro codeText = codeLocation.GetComponent<TMPro.TextMeshPro>();
        codeText.text = code.ToString();
        correctWire = wire;
    }

    public void SetBomb(int code, char wire)
    {
        TMPro.TextMeshPro codeText = codeLocation.GetComponent<TMPro.TextMeshPro>();
        codeText.text = code.ToString();
        correctWire = -1;
        correctWireColor = wire;
    }

    public int GetCorrectWire()
    {
        return correctWire;
    }
}
