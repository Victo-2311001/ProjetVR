using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class SpawnObjets : MonoBehaviour
{
    [SerializeField]
    private float delaySpawn = 2.0f;

    private GameObject prefabObjet;
    private Vector3 spawnObjet;

    void Start()
    {
        StartCoroutine(SpawnerObjetRamasse());
    }

    IEnumerator SpawnerObjetRamasse()
    {
        yield return new WaitForSeconds(delaySpawn);

        Instantiate(prefabObjet, spawnObjet, Quaternion.identity);

    }
}
