using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBehavior : MonoBehaviour
{
    private static MusicBehavior instance = null;
    public static MusicBehavior Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            // Destroy this instance if another one already exists
            Destroy(this.gameObject);
            return;
        }
        else
        {
            // Set this instance as the singleton
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        // Play the background music
        GetComponent<AudioSource>().Play();
    }
}
