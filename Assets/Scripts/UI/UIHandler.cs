using UnityEngine;
using UnityEngine.UIElements;
public class UIHandler : MonoBehaviour
{
    public static UIHandler Instance { get; private set; }

    private VisualElement m_Healthbar;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        m_Healthbar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        SetHealth(1.0f);
    }

    public void SetHealth(float percentage)
    {
        m_Healthbar.style.width = Length.Percent(100 * percentage);
    }
}
