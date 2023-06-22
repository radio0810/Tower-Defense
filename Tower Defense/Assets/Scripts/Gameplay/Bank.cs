using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{

    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;

    [SerializeField] TextMeshProUGUI displayBalance;


    public int CurrentBalance { get { return currentBalance; } }

    void Awake()
    {
        currentBalance = startingBalance;
        updateDisplay();
    }

    //deposit money into the bank
    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        updateDisplay();
    }

    //withdraw money from the bank
    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        updateDisplay();
        if(currentBalance < 0)
        {
            currentBalance = 0;
            Restart();
        }
    }

    //update the bank display
    void updateDisplay()
    {
        displayBalance.text = "Gold: " + currentBalance;
    }

    //restart the game
    public void Restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
