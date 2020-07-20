using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeMechanics : MonoBehaviour
{
    public Grenade grenade;
    private float _countdown;
    private bool _hasExploded;
    private float _blastRadius;
    private float _force;
    private GameObject _explosionEffect;

    void Start()
    {
        _countdown = grenade.delay;
        _hasExploded = false;
        _blastRadius = grenade.blastRadius;
        _force = grenade.explosionForce;
        _explosionEffect = grenade.explosionEffect;
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(_countdown);
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
        AudioManager.instance.PlayAudio(grenade.audioType, AudioSourceType.PLAYER_SRC);
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
                damageable.DealDamage(Mathf.RoundToInt(Mathf.Lerp(grenade.maxDamage, grenade.minDamage, 2)));
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
