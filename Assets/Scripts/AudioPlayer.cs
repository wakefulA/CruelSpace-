using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    public bool Off;

    public void PlaySound(AudioClip audioClip)
    {
        if(audioClip == null || Off)
            return;
        
        _audioSource.PlayOneShot(audioClip);
        
        
        
    }
    
    public void AddTheSoundOfAGunshotClip()
    {
        PlaySound(_audioClip);
    }
}
