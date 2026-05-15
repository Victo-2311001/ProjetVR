using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ObjetRamassable : MonoBehaviour
{
    //Référence vers son spawn point
    public SpawnPoint spawnPoint;

    private XRGrabInteractable grabInteractable;

    private bool objetPris;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        objetPris = false;
    }

    void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnObjetPris);
    }

    void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnObjetPris);
    }

    /// <summary>
    /// Quand l'objet est pris, commence le décompte pour la réapparition.
    /// </summary>
    /// <param name="args"></param>
    private void OnObjetPris(SelectEnterEventArgs args)
    {
        if (spawnPoint != null)
        {
            spawnPoint.ObjetRamasse();
            objetPris = true;
        }
    }

    //Détruire les objets qui tombe à terre ou sur la table 
    private void OnCollisionEnter(Collision collision)
    {
        if(objetPris && collision.gameObject.CompareTag("Table") || collision.gameObject.CompareTag("Planche"))
        {
            //Ajouter 3 secondes comme pénalité
            GameController.Instance.Penalite();
            Destroy(gameObject);
        }
    }
}