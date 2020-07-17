using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SemiAuto Gun", menuName = "Guns/SemiAutomatic")]
public class SemiAutomatic : Gun
{
    public override void OnMouseDown(Transform cameraPos)
    {
        Fire(cameraPos);
    }

    public override void OnRightMouseDown()
    {
        Scope();
    }
}
