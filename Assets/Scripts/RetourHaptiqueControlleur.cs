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

    public void RetourHaptiqueGrabObjet()
    {
        controlleur.SendHapticImpulse(amplitudeGrab, dureeGrab * 3);
    }

    public void RetourHaptiqueUngrabObjet()
    {
        controlleur.SendHapticImpulse(amplitudeGrab * 0.5f, dureeGrab);
        controlleur = null;
    }

    public void AttacherControleur(XRBaseInputInteractor controlleurRecu)
    {
        controlleur = controlleurRecu;
    }
}
