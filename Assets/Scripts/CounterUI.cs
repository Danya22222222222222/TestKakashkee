using UnityEngine;
using TMPro;

public class CounterUI : MonoBehaviour
{
    public TextMeshProUGUI counterText; // перет€гни Text (TMP)
    void OnEnable()
    {
        if (QuestManager.Instance != null)
            QuestManager.Instance.OnCountChanged += UpdateText;
    }
    void OnDisable()
    {
        if (QuestManager.Instance != null)
            QuestManager.Instance.OnCountChanged -= UpdateText;
    }

    void UpdateText(int current, int required)
    {
        if (counterText != null)
            counterText.text = $"Found: {current} / {required}";
    }
}
