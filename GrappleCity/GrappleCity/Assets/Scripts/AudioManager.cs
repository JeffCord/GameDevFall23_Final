using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip bgm;
    public AudioClip jumpSound;
    public AudioClip dashSound;
    public AudioClip deathSound;
    public AudioClip keyButtonSound;
    public AudioClip slidingDoorButtonSound;
    public AudioClip gravityButtonSound;
    public AudioClip gameStartSound;
    public AudioClip exitReachedSound;
    
    private static AudioManager instance = null;
    public static AudioManager Instance
    {
        get {return instance;}
    }

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        }
        else {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = bgm;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip) {
        SFXSource.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
