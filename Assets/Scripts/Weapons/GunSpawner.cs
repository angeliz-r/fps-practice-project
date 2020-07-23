using System.Collections;
using UnityEngine;

public class GunSpawner : MonoBehaviour
{
    [Header("Weapon GameObjects")]
    public GameObject[] weaponObject;
    [Space]
    [Header("Spawn Position")]
    public Transform[] spawnAreas;
    [Space]
    [Header("Weapon Display Prefabs")]
    public GameObject[] weaponPrefab;
    void Start()
    {
        StartCoroutine(SpawnCooldown());
    }
    public void CheckIfEmpty()
    {
        for (int i = 0; i < spawnAreas.Length; i++)
        {
            if (weaponObject[i] == null)
            {
                Instantiate(weaponPrefab[i], spawnAreas[i].transform);
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
