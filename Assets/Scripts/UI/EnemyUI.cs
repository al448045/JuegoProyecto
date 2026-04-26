using UnityEngine;
using UnityEngine.UIElements;

public class EnemyUI : MonoBehaviour
{
    private VisualElement m_EnemyHealthBar;
    private void Start()
    {
        UIDocument enemyUIDocument = GetComponent<UIDocument>();
        m_EnemyHealthBar = enemyUIDocument.rootVisualElement.Q<VisualElement>("EnemyHealthBar");
        SetHealth(1.0f);
    }

    public void SetHealth(float percentage)
    {
        m_EnemyHealthBar.style.width = Length.Percent(100 * percentage);
    }
}
