using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RocketMechanics : MonoBehaviour
{
    public Grenade rocket;
    private bool _hasExploded;
    private float _blastRadius;
    private float _force;
    private GameObject _explosionEffect;

    void Start()
    {
        _hasExploded = false;
        _blastRadius = rocket.blastRadius;
        _force = rocket.explosionForce;
        _explosionEffect = rocket.explosionEffect;
    }
    //explodes on impact
    private void OnCollisionEnter(Collision collision)
    {
        if (!_hasExploded)
        {
            Explode();
            _hasExploded = true;
        }
    }

    void Explode()
    {
        Instantiate(_explosionEffect, transform.position, transform.rotation);
        LookForColliders();
        AudioManager.instance.PlayAudio(rocket.audioType, AudioSourceType.PLAYER_SRC);
        Destroy(gameObject);
    }

    void LookForColliders()
    {
        //look for colliders within the blast radius
        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, _blastRadius);

        foreach (Collider nearby in collidersToDestroy)
        {
            IDamageable damageable = nearby.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.DealDamage(Mathf.RoundToInt(Mathf.Lerp(rocket.maxDamage, rocket.minDamage, 2)));
            }
        }

        //look for colliders within the blast radius
        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, _blastRadius);

        foreach (Collider nearby in collidersToMove)
        {
            Rigidbody rb = nearby.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // add explosion force to objects with rigidbodies
                rb.AddExplosionForce(_force, transform.position, _blastRadius);
            }
        }
    }
}
