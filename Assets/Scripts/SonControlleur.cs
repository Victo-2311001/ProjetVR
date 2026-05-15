using UnityEngine;
using UnityEngine.Audio;

public class SonControlleur : MonoBehaviour
{
    public static SonControlleur Instance;

    [SerializeField]
    private AudioClip[] audioClip;

    [SerializeField]
    private AudioSource audioSource;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// Joue un son quand une bouteille est pris
    /// </summary>
    public void JouerSonBouteille()
    {
        audioSource.PlayOneShot(audioClip[0]);
    }

    /// <summary>
    /// Joue un son quand une canette est pris
    /// </summary>
    public void JouerSonCannette()
    {
        audioSource.PlayOneShot(audioClip[1]);
    }

    /// <summary>
    /// Joue un son quand l'oeuf est pris
    /// </summary>
    public void JouerSonOeuf()
    {
        audioSource.PlayOneShot(audioClip[2]);
    }
}
