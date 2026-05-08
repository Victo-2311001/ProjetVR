using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ObjetRamassable : MonoBehaviour
{
    //Référence vers son spawn point
    public SpawnPoint spawnPoint;

    private XRGrabInteractable grabInteractable;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnObjetPris);
    }

    void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnObjetPris);
    }

    private void OnObjetPris(SelectEnterEventArgs args)
    {
        if (spawnPoint != null)
        {
            spawnPoint.ObjetRamasse();
        }
    }
}