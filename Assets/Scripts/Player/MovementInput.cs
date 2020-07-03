using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInput : MonoBehaviour
{
    public static MovementInput instance;

    public bool isDefault;

    [Header("Controls")]
    public string vAxis;
    public string hAxis;
    public KeyCode jump;
    public KeyCode sprint;
    public KeyCode interact;
    public KeyCode drop;
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
            interact = KeyCode.E;
            drop = KeyCode.R;
            shoot = 0;
            scope = 1;
        }
        if (!isDefault) //IJKL
        {
            vAxis = "CustomVertical";
            hAxis = "CustomHorizontal";
            jump = KeyCode.Space;
            sprint = KeyCode.Quote;
            interact = KeyCode.U;
            drop = KeyCode.Y;
            shoot = 0;
            scope = 1;
        }
    }

    void Awake()
    {
        instance = this;
    }
}
