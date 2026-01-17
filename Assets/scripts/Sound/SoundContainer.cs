using System.Collections.Generic;
using UnityEngine;

public class SoundContainer : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] List<AudioClip> audioClips;
    [SerializeField] float minPitch;
    [SerializeField] float maxPitch;

    public void PlaySound()
    {
        source.Stop();
        source.pitch = Random.Range(minPitch,maxPitch);
        int i = Random.Range(0,audioClips.Count);
        source.PlayOneShot(audioClips[i]);
    }
}
