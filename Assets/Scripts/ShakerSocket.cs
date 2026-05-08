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

    public void OnSocketEntered()
    {
        Physics.IgnoreCollision(topCollider, baseCollider, true);
    }

    public void OnSocketExited()
    {
        Physics.IgnoreCollision(topCollider, baseCollider, false);
    }
}
