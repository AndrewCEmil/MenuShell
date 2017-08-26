using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	//TODO everything for sound effects

	private static SoundController instance = null;
	private AudioSource audioSource;
	private float defaultMusicVolume;
	public static SoundController Instance {
		get { return instance; }
	}
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
		audioSource = GetComponent<AudioSource> ();
		defaultMusicVolume = .5f;

		InitializeSound ();
	}

	private void InitializeSound() {
		audioSource.volume = getSavedMusicVolume ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void SetMusicVolume(float volume) {
		audioSource.volume = volume;
		saveMusicVolume(volume);
	}

	private void saveMusicVolume(float volume) {
		PlayerPrefs.SetFloat ("musicvolume", volume);
		PlayerPrefs.Save ();
	}

	private float getSavedMusicVolume() {
		float volume = PlayerPrefs.GetFloat ("musicvolume", -1);
		if (volume < 0) {
			volume = defaultMusicVolume;
			saveMusicVolume (volume);
		}
		return volume;
	}
}