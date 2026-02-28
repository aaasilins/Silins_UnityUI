using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("UI Pogas")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private void Start()
    {
        playButton.onClick.AddListener(OnPlayClicked);
        quitButton.onClick.AddListener(OnQuitClicked);
    }

    private void OnPlayClicked()
    {
        SceneManager.LoadScene("CharacterCreation");
    }

    private void OnQuitClicked()
    {
        Debug.Log("Quit!");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
