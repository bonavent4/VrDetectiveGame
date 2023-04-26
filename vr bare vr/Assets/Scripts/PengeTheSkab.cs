using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PengeTheSkab : MonoBehaviour
{
    public string password; // Password to unlock the safebox
    private bool isUnlocked; // Flag to check if the safebox is unlocked

    // Start is called before the first frame update
    void Start()
    {
        isUnlocked = false; // Initialize the safebox as locked
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the safebox is unlocked
        if (isUnlocked)
        {
            // Perform actions when the safebox is unlocked
            Debug.Log("Safebox is unlocked!");
            // Add your desired behavior here
        }
    }

    // Method to attempt unlocking the safebox with a given password
    public void Unlock(string enteredPassword)
    {
        // Check if the entered password matches the correct password
        if (enteredPassword == password)
        {
            Debug.Log("Safebox is unlocked!");
            isUnlocked = true; // Set the safebox as unlocked
        }
        else
        {
            Debug.Log("Incorrect password. Try again.");
        }
    }
}
