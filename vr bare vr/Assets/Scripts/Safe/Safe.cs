using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Safe : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI NumberText;
    [SerializeField] int[] numbers;
    int whichOneAreWeOn;

    bool isWrong;
    public bool isCorrect;
    
    float timer;

    [SerializeField] string correctAnswer;

    // set safe to not kinematic
    [SerializeField] Rigidbody safe;
    private void Update()
    {
        if (isWrong)
        {
           
            if(timer < 1f || (timer > 1.5f && timer < 2f) || (timer > 2.5 && timer < 3))
            {
                NumberText.color = Color.red;
                NumberText.fontSize = 28;
                NumberText.text = "Wrong";
            }
            else if (timer > 0.5f)
            {
                NumberText.color = Color.white;
                NumberText.fontSize = 36;
                NumberText.text = " ";
                if(timer > 3)
                {
                    Reset();
                    timer = 0;
                    isWrong = false;
                    return;
                }
            }
            timer += 1 * Time.deltaTime;
        }
    }

    public void pressed(int number, bool isResetButton)
    {
        if (!isWrong && !isCorrect)
        {
            if (!isResetButton)
            {
                numbers[whichOneAreWeOn] = number;
                NumberText.text = null;
                /* foreach (int num in numbers)
                 {
                     NumberText.text += num.ToString();
                 }*/
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (i > whichOneAreWeOn)
                    {
                        NumberText.text += "*";
                    }
                    else
                    {
                        NumberText.text += numbers[i].ToString();
                    }
                }

                whichOneAreWeOn++;
                if (whichOneAreWeOn == numbers.Length)
                {
                    if(NumberText.text == correctAnswer)
                    {
                        Debug.Log("Correct");
                        NumberText.color = Color.green;
                        NumberText.fontSize = 28;
                        NumberText.text = "Correct";

                        isCorrect = true;

                        safe.isKinematic = false;
                    }
                    else
                    {
                        isWrong = true;
                    }
                }
            }
            else
            {
                Reset();
            }
        }
        
       
    }

    private void Reset()
    {
       // isWrong = true;
        whichOneAreWeOn = 0;
        NumberText.text = null;
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = 0;
            NumberText.text += "*";
        }
    }
}
