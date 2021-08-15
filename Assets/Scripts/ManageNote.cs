using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageNote : MonoBehaviour
{
    int[] codes = new int[10];

    // Start is called before the first frame update
    void Start()
    {
        generateCodes();
        for(int i = 0; i < 10; i++)
        {
            Debug.Log(codes[i].ToString());
        }
        assignCodes();
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
                    j = 0;
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
}
