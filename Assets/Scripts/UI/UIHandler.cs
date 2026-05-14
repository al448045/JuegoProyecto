using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UIElements;
public class UIHandler : MonoBehaviour
{
    public static UIHandler Instance { get; private set; }

    private UIDocument uiDocument;

    //Blackbars
    private VisualElement m_UpScreenBar;
    private VisualElement m_DownScreenBar;

    //Score
    private VisualElement m_ScoreContainer;
    private Label m_ScoreText;
    private Label m_ScoreTextShadow;

    //Timer
    private VisualElement m_TimerContainer;
    private Label m_TimerText;
    private Label m_TimerTextShadow;

    //HealthBar
    private List<VisualElement> playerHealthbarFillers;
    private VisualElement m_HealthbarContainer;
    private VisualElement m_HealthbarBorder;

    private VisualElement m_HealthbarTextContainer;
    private Label m_HealthbarTextLabel;

    //Wave Text
    private VisualElement m_WaveTextContainer;
    private Label m_WaveTextLabel;

    //Enemy Counter
    private VisualElement m_EnemiesRemainingContainer;
    private VisualElement m_EnemiesCounterContainer;

    private Label m_EnemiesRemainingText;
    private Label m_BruteCounterText;
    private Label m_ShooterCounterText;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        //UIDocument
        uiDocument = GetComponent<UIDocument>();

        //Black bars
        m_UpScreenBar = uiDocument.rootVisualElement.Q<VisualElement>("UpScreenBar");
        m_DownScreenBar = uiDocument.rootVisualElement.Q<VisualElement>("DownScreenBar");

        //Score
        m_ScoreContainer = uiDocument.rootVisualElement.Q<VisualElement>("ScoreContainer");
        m_ScoreText = uiDocument.rootVisualElement.Q<Label>("ScoreText");
        m_ScoreTextShadow = uiDocument.rootVisualElement.Q<Label>("ScoreTextShadow");

        //Timer
        m_TimerContainer = uiDocument.rootVisualElement.Q<VisualElement>("TimerContainer");
        m_TimerText = uiDocument.rootVisualElement.Q<Label>("TimerText");
        m_TimerTextShadow = uiDocument.rootVisualElement.Q<Label>("TimerTextShadow");

        //HealthBar
        playerHealthbarFillers = uiDocument.rootVisualElement.Query(className: "healthbar-filler-numbered").ToList();
        m_HealthbarBorder = uiDocument.rootVisualElement.Q<VisualElement>("HealthbarBorderAndInlines");
        m_HealthbarContainer = uiDocument.rootVisualElement.Q<VisualElement>("HealthbarContainer");
        m_HealthbarTextContainer = uiDocument.rootVisualElement.Q<VisualElement>("HealthbarTextContainer");
        m_HealthbarTextLabel = uiDocument.rootVisualElement.Q<Label>("HealthbarTextLabel");

        //Wave text
        m_WaveTextContainer = uiDocument.rootVisualElement.Q<VisualElement>("WaveTextContainer");
        m_WaveTextLabel = uiDocument.rootVisualElement.Q<Label>("WaveTextLabel");

        //Enemy Counter
        m_EnemiesRemainingContainer = uiDocument.rootVisualElement.Q<VisualElement>("EnemiesRemainingContainer");
        m_EnemiesCounterContainer = uiDocument.rootVisualElement.Q<VisualElement>("EnemyCounterContainer");

        m_EnemiesRemainingText = uiDocument.rootVisualElement.Q<Label>("EnemiesRemainingText");
        m_BruteCounterText = uiDocument.rootVisualElement.Q<Label>("BruteCounterText");
        m_ShooterCounterText = uiDocument.rootVisualElement.Q<Label>("ShooterCounterText");
}

    public void ChangePlayerHealthbar(int health)
    {
        playerHealthbarFillers[health].style.opacity = 0;
        m_HealthbarTextLabel.text = health.ToString();
    }
    public void ChangeScoreText(int score)
    {
        m_ScoreText.text = "Score: " + score.ToString();
        m_ScoreTextShadow.text = "Score: " + score.ToString();
    }

    public void ChangeWaveText(int waveCounter)
    {
        m_WaveTextLabel.text = "Wave " + waveCounter.ToString();
    }

    public void ChangeBruteCounter(int counter)
    {
        string newText = "x" + counter.ToString();
        m_BruteCounterText.text = newText;
    }

    public void ChangeShooterCounter(int counter)
    {
        string newText = "x" + counter.ToString();
        m_ShooterCounterText.text = newText;
    }

public void ChangeTimer(int minutes, int seconds)
    {
        m_TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        m_TimerTextShadow.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
