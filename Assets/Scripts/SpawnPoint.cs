using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    private float delaySpawn = 2.0f;
    private GameObject prefabObjet;

    private GameObject objetActuel;

    void Start()
    {
        //Donner référence au spawn à l'objet qui est déjà dans la scène
        ObjetRamassable ramassable = objetActuel.GetComponent<ObjetRamassable>();
        if (ramassable != null)
        {
            ramassable.spawnPoint = this;
        }
    }

    private void SpawnerObjet()
    {
        objetActuel = Instantiate(prefabObjet, transform.position, transform.rotation);

        ObjetRamassable ramassable = objetActuel.GetComponent<ObjetRamassable>();
        if (ramassable != null)
        {
            ramassable.spawnPoint = this;
        }
            
    }

    public void ObjetRamasse()
    {
        StartCoroutine(RespawnApresDelai());
    }

    private IEnumerator RespawnApresDelai()
    {
        yield return new WaitForSeconds(delaySpawn);
        SpawnerObjet();
    }
}
