using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UIElements;
public class UIHandler : MonoBehaviour
{
    public static UIHandler Instance { get; private set; }

    private UIDocument uiDocument;
    private List<VisualElement> playerHealthbarFillers;

    private Label m_ScoreText;
    private Label m_ScoreTextShadow;

    private Label m_TimerText;
    private Label m_TimerTextShadow;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        uiDocument = GetComponent<UIDocument>();

        m_ScoreText = uiDocument.rootVisualElement.Q<Label>("ScoreText");
        m_ScoreTextShadow = uiDocument.rootVisualElement.Q<Label>("ScoreTextShadow");

        m_TimerText = uiDocument.rootVisualElement.Q<Label>("TimerText");
        m_TimerTextShadow = uiDocument.rootVisualElement.Q<Label>("TimerTextShadow");

        playerHealthbarFillers = uiDocument.rootVisualElement.Query(className: "healthbar-filler-numbered").ToList();
    }

    public void ChangePlayerHealth(int health)
    {
        playerHealthbarFillers[health].style.opacity = 0;
    }
    public void ChangeScore(int score)
    {
        m_ScoreText.text = "Score: " + score.ToString();
        m_ScoreTextShadow.text = "Score: " + score.ToString();
    }

    public void ChangeTimer(int minutes, int seconds)
    {
        m_TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        m_TimerTextShadow.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
