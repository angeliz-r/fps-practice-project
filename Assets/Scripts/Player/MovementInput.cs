using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInput : MonoBehaviour
{
    public static MovementInput instance;
    public Keybindings controls;

    [Header("Primary Controls")]
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
        LoadControls();
    }

    void Awake()
    {
        instance = this;
    }

    public void SaveControls()
    {
        controls.vAxis = vAxis;
        controls.hAxis = hAxis;
        controls.jump = jump;
        controls.interact = interact;
        controls.sprint = sprint;
        controls.drop = drop;
        controls.shoot = shoot;
        controls.scope = scope;
    }

    public void LoadControls()
    {
        vAxis = controls.vAxis; 
        hAxis = controls.hAxis;
        jump = controls.jump;
        interact = controls.interact;
        sprint = controls.sprint;
        drop = controls.drop;
        shoot = controls.shoot;
        scope = controls.scope;
    }

    public string ReturnSetMovement()
    {
        if (controls.hAxis == "Horizontal")
            return "WASD";
        else
            return "IJKL";

    }

    public void ResetControls(bool isDefault)
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
            controls.isDefault = isDefault;
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
        controls.isDefault = isDefault;
        SaveControls();
    }

}
