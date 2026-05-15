using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


/// <summary>
/// Inspiré de ChatGPT pour régler mon problème de shaker qui bug à cause des colliders 
/// </summary>
public class ShakerSocket : MonoBehaviour
{
    [SerializeField]
    private Collider topCollider;
    
    [SerializeField]
    private Collider baseCollider;

    /// <summary>
    /// Enlève la collision quand le top est mis sur le shaker
    /// </summary>
    public void OnSocketEntered()
    {
        Physics.IgnoreCollision(topCollider, baseCollider, true);
        Recettes.Instance.VerifierRecette();
    }

    /// <summary>
    /// Remet la collision quand le top est enlever de la base
    /// </summary>
    public void OnSocketExited()
    {
        Physics.IgnoreCollision(topCollider, baseCollider, false);
    }
}
