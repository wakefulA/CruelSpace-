using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    public void PlaySound(AudioClip audioClip)
    {
        if(audioClip == null)
            return;
        
        _audioSource.PlayOneShot(audioClip);
        
        
        
    }
    
    public void AddTheSoundOfAGunshotClip()
    {
        PlaySound(_audioClip);
    }
}
