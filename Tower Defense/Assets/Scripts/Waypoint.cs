using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] Tower towerPrefab;

    public bool IsPlaceable { get { return isPlaceable; } }
    void OnMouseDown()
    {
        //if the waypoint is placeable, create a tower at the waypoint
        if(isPlaceable)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlaceable = !isPlaced;
            
        }
        else
        {
            Debug.Log("Can't place here");
        }
       
    }
}
