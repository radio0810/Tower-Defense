using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] Transform target;
    [SerializeField]   float towerRange = 15f;

    [SerializeField] ParticleSystem projectileParticle;
    // Start is called before the first frame update
    void Start()
    {
       target = FindObjectOfType<Enemy>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        AimWeapon();
        FindClosestTarget();
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        weapon.LookAt(target);

        if(targetDistance < towerRange)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
