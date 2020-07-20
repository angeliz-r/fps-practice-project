using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticles : MonoBehaviour
{
    private ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        var main = ps.main;
        main.stopAction = ParticleSystemStopAction.Destroy;
    }
}
