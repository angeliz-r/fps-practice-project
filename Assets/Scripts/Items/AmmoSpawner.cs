using System.Collections;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    [Header("Ammo GameObjects")]
    public GameObject[] ammoObject;
    [Space]
    [Header("Ammo Spawn Position")]
    public Transform[] spawnAreas;
    [Space]
    [Header("Ammo Prefabs")]
    public GameObject[] ammoPrefab;

    void Start()
    {
        StartCoroutine(SpawnCooldown());
    }

    public void CheckIfEmpty ()
    {
        for (int i = 0; i < spawnAreas.Length; i++)
        {
            if (ammoObject[i] == null)
            {
                Instantiate(ammoPrefab[i], spawnAreas[i].transform);
            }
        }
        StartCoroutine(SpawnCooldown());
    }

    IEnumerator SpawnCooldown()
    {
        yield return new WaitForSeconds(10);
        CheckIfEmpty();
    }
}
