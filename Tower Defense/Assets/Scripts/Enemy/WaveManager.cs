using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI waveText;

    [SerializeField]int maxWaves = 10;
    int statingWave = 1;

    int currentWave = 0;

    [SerializeField] int waveSize = 5;
    int killCountGoal = 15;
    [SerializeField] int killCount = 0;
    [SerializeField] int difficultyRamp = 1;


    public int CurrentWave()
    {
        return currentWave;
    }
    public int WaveSize 
    {
        get { return waveSize; }    
        set { waveSize = value; }
    }

    public int KillCount
    {
        get { return killCount; }
        set { killCount = value; }
    }

    

    // Start is called before the first frame update
    void Start()
    {
        currentWave = statingWave;
        UpdateDisplay();
    }

    void Update()
    {
        if(killCount >= killCountGoal)
        {
            IncreaseDifficulty();
            UpdateDisplay();
        }
    }

    void IncreaseDifficulty()
    {
        if(currentWave >= maxWaves) { return; }
        killCount = 0;
        currentWave++;
        waveSize += difficultyRamp;
        difficultyRamp++;
    }

    public void UpdateDisplay()
    {
        waveText.text = "Wave: " + currentWave.ToString();
    }
}
