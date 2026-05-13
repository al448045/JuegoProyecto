using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UIElements;
public class UIHandler : MonoBehaviour
{
    public static UIHandler Instance { get; private set; }

    private List<VisualElement> playerHealthbarFillers;

    private Label m_ScoreText;
    private Label m_TimerText;

    private UIDocument uiDocument;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        uiDocument = GetComponent<UIDocument>();

        m_ScoreText = uiDocument.rootVisualElement.Q<Label>("ScoreText");
        m_TimerText = uiDocument.rootVisualElement.Q<Label>("TimerText");
        playerHealthbarFillers = uiDocument.rootVisualElement.Query(className: "healthbar-filler-numbered").ToList();
    }

    public void ChangePlayerHealth(int health)
    {
        playerHealthbarFillers[health].style.opacity = 0;
    }
    public void ChangeScore(int score)
    {
        m_ScoreText.text = score.ToString();
    }

    public void ChangeTimer(int minutes, int seconds)
    {
        m_TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
