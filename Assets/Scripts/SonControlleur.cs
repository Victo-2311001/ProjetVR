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

    public void JouerSonBouteille()
    {
        audioSource.PlayOneShot(audioClip[0]);
    }

    public void JouerSonCannette()
    {
        audioSource.PlayOneShot(audioClip[1]);
    }

    public void JouerSonOeuf()
    {
        audioSource.PlayOneShot(audioClip[2]);
    }
}
