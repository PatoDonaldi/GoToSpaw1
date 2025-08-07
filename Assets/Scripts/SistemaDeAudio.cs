using UnityEngine;

public class SistemaDeAudio : MonoBehaviour
{
    [Header("Fontes de Audio")]
    [SerializeField] private AudioSource bgAaudio;
    [SerializeField] private AudioSource sfxAudio;
    [Header("Volume dosAudios")]
    [Range(0f, 1f)][SerializeField] private float bgVolume = 0.5f;
    [Range(0f, 1f)][SerializeField] private float sfxVolume = 0.5f;
    private static SistemaDeAudio Instance;



    void Awake()
    {
        if (Instance != null && Instance != this )
        {
            Destroy(gameObject);
            return;
        }
        
             Instance = this;
             DontDestroyOnLoad(gameObject);

        bgAaudio= GameObject.Find("BgAudio").GetComponent<AudioSource>();
        bgAaudio = GameObject.Find("sfxAudio").GetComponent<AudioSource>();
    }

     public void PlayBackGroundMusic(AudioClip clip)
    {
        bgAaudio.clip = clip;
        bgAaudio.volume = bgVolume;
        bgAaudio.loop = true;
        bgAaudio.Play();
    }

    public void PlaySoundEffects(AudioClip clip)
    {
        sfxAudio.volume = sfxVolume;
        sfxAudio.PlayOneShot(clip);
    }

}
