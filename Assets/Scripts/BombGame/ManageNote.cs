using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageNote : MonoBehaviour
{
    int[] usedInstructions = new int[10];
    int[] codes = new int[10];
    string[] instructions =
    {
        "Cut the 1st Wire",
        "Cut the 2nd Wire",
        "Cut the 3rd Wire",
        "Cut the 4th Wire",
        "Cut the 5th Wire",
        "Cut the Red Wire",
        "Cut the Yellow Wire",
        "Cut the Green Wire",
        "Cut the Blue Wire",
        "Cut the White Wire"
    };

    WireManager bomb;

    // Start is called before the first frame update
    void Start()
    {
        bomb = FindObjectOfType<WireManager>();
        generateCodes();
        //for(int i = 0; i < 10; i++)
        //{
        //    Debug.Log(codes[i].ToString());
        //}
        assignCodes();
        assignInstructions();
        correctChoice();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int randInt(int min, int max)
    {
        float randF = Random.Range(min, max);
        int rounded = (int)randF;
        return rounded;
    }

    void generateCodes()
    {
        codes[0] = randInt(10000, 99999);
        for(int i = 1; i < 10; i++)
        {
            int randVal = randInt(10000, 99999);
            for(int j = 0; j < i; j++)
            {
                if(randVal == codes[j])
                {
                    randVal = randInt(10000, 99999);
                    j = -1;
                }
            }
            codes[i] = randVal;
        }
    }

    void assignCodes()
    {
        TMPro.TextMeshPro[] allText = GetComponentsInChildren<TMPro.TextMeshPro>();
        TMPro.TextMeshPro[] codeText = new TMPro.TextMeshPro[10];

        for (int i = 0; i < 10; i++)
        {
            codeText[i] = allText[(i * 2)];
        }
        for (int i = 0; i < 10; i++)
        {
            codeText[i].text = "Serial Code: " + codes[i].ToString();
        }
    }

    void assignInstructions()
    {
        TMPro.TextMeshPro[] allText = GetComponentsInChildren<TMPro.TextMeshPro>();
        TMPro.TextMeshPro[] instructionText = new TMPro.TextMeshPro[10];

        for(int i = 9; i >= 0; i--)
        {
            instructionText[i] = allText[1 + (i * 2)];
        }

        int randomNumber = randInt(0, 10);
        instructionText[0].text = instructions[randomNumber];
        usedInstructions[0] = randomNumber;

        for (int i = 0; i < 10; i++)
        {
            randomNumber = randInt(0, 10);
            for (int j = 0; j < i; j++)
            {
                if (usedInstructions[j] == randomNumber)
                {
                    randomNumber = randInt(0, 10);
                    j = -1;
                }
            }
            instructionText[i].text = instructions[randomNumber];
            usedInstructions[i] = randomNumber;
        }
    }

    void correctChoice()
    {
        TMPro.TextMeshPro[] allText = GetComponentsInChildren<TMPro.TextMeshPro>();

        TMPro.TextMeshPro[] instructionText = new TMPro.TextMeshPro[10];

        for (int i = 0; i < 10; i++)
        {
            instructionText[i] = allText[1 + (i * 2)];
        }

        int randomNumber = randInt(0, 10);
        int codeMatch = codes[randomNumber];

        for(int i = 0; i < 10; i++)
        {
            //Debug.Log(instructionText[randomNumber].text);
            //Debug.Log(instructions[i]);
            //Debug.Log(string.Compare(instructionText[randomNumber].text, instructions[i]) == 0);

            if(string.Compare(instructionText[randomNumber].text, instructions[i]) == 0)
            {
                switch(i)
                {
                    case 0:
                        bomb.SetBomb(codeMatch, 0);
                        break;

                    case 1:
                        bomb.SetBomb(codeMatch, 1);
                        break;

                    case 2:
                        bomb.SetBomb(codeMatch, 2);
                        break;

                    case 3:
                        bomb.SetBomb(codeMatch, 3);
                        break;

                    case 4:
                        bomb.SetBomb(codeMatch, 4);
                        break;

                    case 5:
                        bomb.SetBomb(codeMatch, 'R');
                        break;

                    case 6:
                        bomb.SetBomb(codeMatch, 'Y');
                        break;

                    case 7:
                        bomb.SetBomb(codeMatch, 'G');
                        break;

                    case 8:
                        bomb.SetBomb(codeMatch, 'B');
                        break;

                    case 9:
                        bomb.SetBomb(codeMatch, 'W');
                        break;
                }
            }
        }
    }
}
