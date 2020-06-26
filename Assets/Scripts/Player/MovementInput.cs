using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInput : MonoBehaviour
{
    public bool isDefault;
    [Header("Controls")]
    public string vAxis;
    public string hAxis;
    public KeyCode jump;
    public KeyCode sprint;
    public int shoot;
    public int scope;

    void OnEnable()
    {
        if (isDefault) //WASD
        {
            vAxis = "Vertical";
            hAxis = "Horizontal";
            jump = KeyCode.Space;
            sprint = KeyCode.LeftShift;
            shoot = 0;
            scope = 1;
        }
        if (!isDefault) //IJKL
        {
            vAxis = "CustomVertical";
            hAxis = "CustomHorizontal";
            jump = KeyCode.Space;
            sprint = KeyCode.Quote;
            shoot = 0;
            scope = 1;
        }
    }
}
