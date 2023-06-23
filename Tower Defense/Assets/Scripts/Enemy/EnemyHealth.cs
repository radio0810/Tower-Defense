using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Adds amount to maxHitPoints when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    [SerializeField] int currentHitPoints = 0;
    WaveManager waveManager;
    int currentWave = 0;

    Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        
        waveManager = FindObjectOfType<WaveManager>();
        currentWave = waveManager.CurrentWave();
    }

    void Update()
    {
        if(currentWave != waveManager.CurrentWave())
        {
            IncreaseDifficulty();
            currentWave = waveManager.CurrentWave();
        }
    }

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    //processes hit and kills enemy if hit points are 0
    void ProcessHit()
    {
        currentHitPoints--;
        if(currentHitPoints <= 0)
        {
            KillEnemy();
        }
    }

    //kills enemy
    void KillEnemy()
    {
        gameObject.SetActive(false);
        
        enemy.RewardGold();
        waveManager.KillCount++;
    }

    public void IncreaseDifficulty()
    {
        maxHitPoints += difficultyRamp;
    }
}
