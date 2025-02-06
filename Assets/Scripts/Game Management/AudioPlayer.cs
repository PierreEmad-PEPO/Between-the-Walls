using AYellowpaper.SerializedCollections;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField,SerializedDictionary("Sound name", "Clip")] 
    private SerializedDictionary<SoundEffects, AudioClip[]> soundEffects;

    private void Awake()
    {
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlaySoundEffect( SoundEffects soundType, float volume = 1f)
    {
        if(!audioSource.isPlaying)
        audioSource.PlayOneShot(soundEffects[soundType]
                [Random.Range(0, soundEffects[soundType].Length)], volume);
    }
}
