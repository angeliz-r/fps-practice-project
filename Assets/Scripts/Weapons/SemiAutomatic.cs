using UnityEngine;
[CreateAssetMenu(fileName = "SemiAuto Gun", menuName = "Weapons/SemiAutomatic")]
public class SemiAutomatic : Weapon
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
