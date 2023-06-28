using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]

public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    Tile waypoint;

    GridManager gridmanger;


    void Awake()
    {
        gridmanger = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
       
        label.enabled = false;
        DisplayCoordinates();
       
    }
    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
        SetLabelColor();
        ToggleLabels();
    }
    
    //toggles labels on and off
    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.enabled;
        }
    }

    //sets label color based on if waypoint is placeable
    void SetLabelColor()
    {
        if (waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }

    //displays coordinates of waypoint
    void DisplayCoordinates()
    {
        if(gridmanger == null) { return; }
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / gridmanger.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridmanger.UnityGridSize);

        label.text = coordinates.x + "," + coordinates.y;
    }


    //updates the name of the waypoint to match the coordinates
    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}