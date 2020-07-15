using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoStatus : MonoBehaviour
{
    public static AmmoStatus instance;
    public GameObject ammoStatusText;

    void Awake ()
    {
        instance = this;
    }
    public void StatusPopUp()
    {
        GameObject temp = Instantiate(ammoStatusText, this.transform.position, Quaternion.identity);
        temp.transform.parent = gameObject.transform;
    }
}
