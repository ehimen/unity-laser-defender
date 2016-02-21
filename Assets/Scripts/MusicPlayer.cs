using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;

    public AudioClip[] clips;

    private AudioSource music;

    void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            OnLevelWasLoaded(0);
		}
	}

    void OnLevelWasLoaded(int level)
    {
        music.Stop();

        if (clips[level]) {
            music.clip = clips[level];
            music.loop = true;
            music.Play();
        }

    }

}
