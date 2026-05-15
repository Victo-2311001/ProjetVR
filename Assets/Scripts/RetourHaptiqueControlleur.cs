using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class RetourHaptiqueControlleur : MonoBehaviour
{
    public static RetourHaptiqueControlleur Instance;

    private XRGrabInteractable grabInteractable;

    [SerializeField] private float amplitudeGrab = 0.5f;
    [SerializeField] private float dureeGrab = 0.1f;

    private XRBaseInputInteractor controlleur;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
    }

    /// <summary>
    /// Envoi une vibration quand un objet est pris
    /// </summary>
    public void RetourHaptiqueGrabObjet()
    {
        controlleur.SendHapticImpulse(amplitudeGrab, dureeGrab * 3);
    }

    /// <summary>
    /// Envoi une vibration quand un objet est laché
    /// </summary>
    public void RetourHaptiqueUngrabObjet()
    {
        controlleur.SendHapticImpulse(amplitudeGrab * 0.5f, dureeGrab);
        controlleur = null;
    }

    /// <summary>
    /// Va chercher le controlleur qui a pris l'objet et le garde en mémoire
    /// </summary>
    /// <param name="controlleurRecu"></param>
    public void AttacherControleur(XRBaseInputInteractor controlleurRecu)
    {
        controlleur = controlleurRecu;
    }
}
