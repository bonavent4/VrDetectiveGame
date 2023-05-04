using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Safe : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI NumberText;
    [SerializeField] int[] numbers;
    int whichOneAreWeOn;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            pressed(2, false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pressed(4, true);
        }
    }

    public void pressed(int number, bool isResetButton)
    {
       
         if (!isResetButton)
        {
            numbers[whichOneAreWeOn] = number;
            NumberText.text = null;
            foreach (int num in numbers)
            {
                NumberText.text += num.ToString();
            }
            
            whichOneAreWeOn++;
            if(whichOneAreWeOn == numbers.Length)
            {

                Reset();
            }
        }
        else
        {
            Reset();
        }
       
    }

    private void Reset()
    {
        whichOneAreWeOn = 0;
        NumberText.text = null;
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = 0;
            NumberText.text += numbers[i].ToString();
        }
    }
}
