﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Manual Gun", menuName = "Guns/Manual")]
public class SemiAutomatic : Gun
{
    public override void OnMouseDown(Transform cameraPos)
    {
        Fire(cameraPos);
    }
}
