using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Clips")]
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip equipSound;
    [SerializeField] private AudioClip[] characterSounds;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Start background music
        if (musicSource != null && backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.volume = 0.3f;
            musicSource.Play();
        }
    }

    public void PlayClick()
    {
        if (sfxSource != null && clickSound != null)
            sfxSource.PlayOneShot(clickSound);
    }

    public void PlayEquip()
    {
        if (sfxSource != null && equipSound != null)
            sfxSource.PlayOneShot(equipSound);
    }

    public void PlayCharacterSound(int index)
    {
        if (sfxSource != null && characterSounds != null &&
            index < characterSounds.Length && characterSounds[index] != null)
            sfxSource.PlayOneShot(characterSounds[index]);
    }
}