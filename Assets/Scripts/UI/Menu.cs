using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject startMenu;

    [SerializeField]
    private GameObject gameMenu;

    [SerializeField]
    private Button stopButton;

    [SerializeField]
    private Button shieldButton;

    [SerializeField]
    private Button gunButton;

    [SerializeField]
    private TextMeshProUGUI gunButtonText;
    public TextMeshProUGUI GunButtonText { get { return gunButtonText; } }

    [SerializeField]
    private TextMeshProUGUI moneyText;

    [SerializeField]
    private TextMeshProUGUI stopButtonText;

    private static bool isStopped = false;

    PlayerController player;

    public Button StopButton { get { return stopButton; } }
    public Button ShieldButton { get { return shieldButton; } }
    public Button GunButton { get { return gunButton; } }
    public TextMeshProUGUI MoneyText { get { return moneyText; } }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);    
    }

    public void StartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int buildIndex = currentScene.buildIndex;

        startMenu.SetActive(false);
        SceneManager.LoadScene(++buildIndex);
        gameMenu.SetActive(true);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void StopGame()
    {
        player = FindObjectOfType<PlayerController>();

        if (!isStopped)
            ChangeGameState(true, false, "Replay", 0);
        else
            ChangeGameState(false, true, "Stop", 1);
    }

    public void OnGunButtonClick()
    {
        LaserData data = FindObjectOfType<LaserData>();
        data.IncreaseLaserLevel();
        gunButtonText.text = "GUN (" + data.CurrentIndexLevel + ")\n(100$)";
    }

    private void ChangeGameState(bool isStop, bool enabled, string text, int timeScale)
    {
        isStopped = isStop;
        Time.timeScale = timeScale;
        player.enabled = enabled;
        stopButtonText.text = text;
    }
}
