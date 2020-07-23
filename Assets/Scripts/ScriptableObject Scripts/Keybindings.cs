using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "Keybindings", menuName = "Keybinding")]
public class Keybindings : ScriptableObject
{
    [Header("Axis Controls")]
    public string vAxis;
    public string hAxis;
    [Space]
    [Header("Key Controls")]
    public KeyCode jump;
    public KeyCode sprint;
    public KeyCode interact;
    public KeyCode drop;
    [Space]
    [Header("Mouse Click Controls, use numbers 0 & 1")]
    public int shoot;
    public int scope;
    [Space]
    [Header("Controls")]
    public bool isDefault;

}
