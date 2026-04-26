using UnityEngine;
using UnityEngine.UIElements;
public class UIHandler : MonoBehaviour
{
    public static UIHandler Instance { get; private set; }

    private VisualElement m_Healthbar;
    private Label m_ScoreText;
    private Label m_TimerText;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();

        m_Healthbar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        m_ScoreText = uiDocument.rootVisualElement.Q<Label>("ScoreText");
        m_TimerText = uiDocument.rootVisualElement.Q<Label>("TimerText");

        SetHealth(1.0f);
    }

    public void SetHealth(float percentage)
    {
        m_Healthbar.style.width = Length.Percent(100 * percentage);
    }

    public void ChangeScore(int score)
    {
        m_ScoreText.text = score.ToString();
    }

    public void ChangeTimer(float time)
    {
        m_TimerText.text = time.ToString();
    }
}
