using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 5;
    [SerializeField] int currentHitPoints = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentHitPoints = hitPoints;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHitPoints--;
        if(currentHitPoints <= 0)
        {
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        Destroy(gameObject);
    }
}
