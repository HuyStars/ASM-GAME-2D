using UnityEngine;

public class Music : MonoBehaviour
{
    private bool isSoundOn = true;
    private AudioSource[] allAudioSources;

    private void Start()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();
    }

    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;
        foreach (var audioSource in allAudioSources)
        {
            audioSource.enabled = isSoundOn;
        }
    }
}