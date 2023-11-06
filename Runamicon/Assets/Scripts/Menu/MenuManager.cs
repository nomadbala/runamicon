using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
	[SerializeField] private GameObject _mainPanel;
	[SerializeField] private GameObject _settingsPanel;
	[SerializeField] private Slider _difficultySlider;
	[SerializeField] private Slider _musicValueSlider;

	private float _difficulty;
	private float _musicValue;
	public void PlayGame()
	{
		SceneManager.LoadScene(1);
	}
	private void Awake()
	{
		_difficulty = _difficultySlider.value;
		_musicValue = _musicValueSlider.value;
	}
	public void Settings()
	{
		_difficultySlider.value = _difficulty;
		_musicValueSlider.value = _musicValue;
		_mainPanel.SetActive(false);
		_settingsPanel.SetActive(true);
	}

	public void SettingsCancel()
	{
		_settingsPanel.SetActive(false);
		_mainPanel.SetActive(true);
	}
	public void SettingsSave()
	{
		_difficulty = _difficultySlider.value;
		_musicValue = _musicValueSlider.value;
		_settingsPanel.SetActive(false);
		_mainPanel.SetActive(true);
	}

	public void Quit() => Application.Quit();

	public Scene GetNextScene() => SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1);

	public string GetNextSceneName() => SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).name;
}
