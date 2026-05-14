using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    private float delaySpawn = 2.0f;
    [SerializeField]
    private GameObject prefabObjet;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip sonSpawn;

    //Méthode qui spawn l'objet choisi pris par l'utilisateur 
    private void SpawnerObjet()
    {
        GameObject nouveauObjet = Instantiate(prefabObjet, transform.position, transform.rotation);

        //Assigner le spawn point au nouvel objet
        ObjetRamassable ramassable = nouveauObjet.GetComponent<ObjetRamassable>();
        if (ramassable != null)
        {
            ramassable.spawnPoint = this;
            SonControlleur.Instance.transform.position = ramassable.transform.position;
            audioSource.PlayOneShot(sonSpawn);
        }
           
    }

    //Lancer la coroutine après grab
    public void ObjetRamasse()
    {
        StartCoroutine(RespawnApresDelai());
    }
    
    //Delay de deux secondes
    private IEnumerator RespawnApresDelai()
    {
        yield return new WaitForSeconds(delaySpawn);
        SpawnerObjet();
    }
}