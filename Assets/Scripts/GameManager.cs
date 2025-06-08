using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject mainMenu;
    public GameObject instructionsMenu;
    public GameObject creditsMenu;

    [Header("Buttons")]
    public Button startButton;
    public Button quitButton;
    public Button instructionsButton;
    public Button creditsButton;
    public Button closeInstructionsButton;
    public Button closeCreditsButton;

    [Header("Audio Clips")]
    public AudioClip menuMusicClip;
    public AudioClip gameMusicClip;
    public AudioClip buttonClickClip;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    private void Start()
    {
        // Set music to menu and play
        PlayMusic(menuMusicClip);

        // UI state
        mainMenu.SetActive(true);
        instructionsMenu.SetActive(false);
        creditsMenu.SetActive(false);

        // Hook up button events
        AddButtonSound(startButton, StartGame);
        AddButtonSound(quitButton, QuitGame);
        AddButtonSound(instructionsButton, OpenInstructions);
        AddButtonSound(creditsButton, OpenCredits);
        AddButtonSound(closeInstructionsButton, CloseInstructions);
        AddButtonSound(closeCreditsButton, CloseCredits);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainMenu.SetActive(true);
            PlayMusic(menuMusicClip);
        }
    }

    private void AddButtonSound(Button button, UnityEngine.Events.UnityAction action)
    {
        button.onClick.AddListener(() =>
        {
            PlaySFX(buttonClickClip);
            action.Invoke();
        });
    }

    public void StartGame()
    {
        mainMenu.SetActive(false);
        PlayMusic(gameMusicClip);
        Debug.Log("Game Started!");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void OpenInstructions()
    {
        instructionsMenu.SetActive(true);
    }

    public void CloseInstructions()
    {
        instructionsMenu.SetActive(false);
    }

    public void OpenCredits()
    {
        creditsMenu.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsMenu.SetActive(false);
    }

    private void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip != clip)
        {
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    private void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
