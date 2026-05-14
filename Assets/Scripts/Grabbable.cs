using UnityEngine;
using static UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics.HapticsUtility;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.Audio;

public class Grabbable : MonoBehaviour
{

    private XRGrabInteractable grabInteractable;
    private XRBaseInputInteractor controlleur;

    [SerializeField]
    private GameObject musiqueControlleur;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        musiqueControlleur = GameObject.FindWithTag("MusiqueControlleur");
    }

    /// <summary>
    /// Assigne les méthodes à leurs actions dans le jeu
    /// </summary>
    void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrabEntered);
        grabInteractable.selectExited.AddListener(OnGrabExited);
    }

    /// <summary>
    /// Désassgigne les méthodes À la fin du jeu
    /// </summary>
    void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrabEntered);
        grabInteractable.selectExited.RemoveListener(OnGrabExited);
    }


    /// <summary>
    /// Lance la vibration quand l'objet est pris
    /// </summary>
    /// <param name="args">Information de l'objet qui contient le component xr grab</param>
    private void OnGrabEntered(SelectEnterEventArgs args)
    {
        // Récupérer le contrôleur depuis l'interactor
        controlleur = args.interactorObject.transform.GetComponent<XRBaseInputInteractor>();

        // Récupérer l'objet pris
        GameObject objetPris = args.interactableObject.transform.gameObject;

        musiqueControlleur.transform.position = objetPris.transform.position;

        // Comparer le tag de l'objet pris
        if (objetPris.CompareTag("Biere") || objetPris.CompareTag("Saque") || objetPris.CompareTag("Vanille"))
        {
            MusiqueControlleur.Instance.JouerSonBouteille();
        }
        else if (objetPris.CompareTag("Soda") || objetPris.CompareTag("Monster"))
        {
            MusiqueControlleur.Instance.JouerSonCannette();
        }
        else if(objetPris.CompareTag("Oeuf"))
        {
            MusiqueControlleur.Instance.JouerSonOeuf();
        }

        RetourHaptiqueControlleur.Instance.AttacherControleur(controlleur);

        RetourHaptiqueControlleur.Instance.RetourHaptiqueGrabObjet();
    }

    /// <summary>
    /// Lance la vibration quand l'objet est déposé
    /// </summary>
    /// <param name="args">Information de l'objet qui contient le component xr grab</param>
    private void OnGrabExited(SelectExitEventArgs args)
    {
        controlleur = args.interactorObject.transform.GetComponent<XRBaseInputInteractor>();

        RetourHaptiqueControlleur.Instance.RetourHaptiqueUngrabObjet();
    }
}
