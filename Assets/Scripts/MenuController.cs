using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour {

	public Slider musicSlider;
	public Toggle particleToggle;
	// Use this for initialization
	void Start () {
		MaybeInitializePlayerPrefs ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void LoadGame() {
		Application.LoadLevel("DemoScene");
	}

	public void LoadAnteChamber() {
		Application.LoadLevel("AntechamberScene");
	}

	public void LoadSettings() {
		Application.LoadLevel ("SettingsScene");
	}

	public void LoadStart() {
		Application.LoadLevel ("StartScene");
	}

	public void LoadAboutScene() {
		Application.LoadLevel ("AboutScene");
	}

	public void Quit() {
		PlayerPrefs.Save ();
		Application.Quit ();
	}

	public void SetMusicVolume() {
		SoundController soundController = GameObject.Find ("MusicPlayer").GetComponent<SoundController> ();
		soundController.SetMusicVolume (musicSlider.value);
	}

	//Reversed so we default to particles on
	public void SetParticleToggle() {
		if (particleToggle.isOn) {
			PlayerPrefs.SetInt ("ParticlesOff", 0);
		} else {
			PlayerPrefs.SetInt ("ParticlesOff", 1);
		}
		PlayerPrefs.Save ();
	}

	private void MaybeInitializePlayerPrefs() {
		//Other settings
	}

	//TODO initialize settings menu
}