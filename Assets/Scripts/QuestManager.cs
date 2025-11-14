using UnityEngine;
using System;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get; private set; }

    public int currentCount = 0;
    public int requiredCount = 3; // постав своЇ значенн€
    public Door Door;  // перет€гни сюди двер≥ в ≥нспектор≥

    public event Action<int, int> OnCountChanged; // (current, required)

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    void Start()
    {
        // пов≥домленн€ початкового стану
        OnCountChanged?.Invoke(currentCount, requiredCount);
    }

    public void CollectItem()
    {
        currentCount++;
        OnCountChanged?.Invoke(currentCount, requiredCount);
        CheckOpenDoor();
    }

    void CheckOpenDoor()
    {
        if (Door == null) return;
        if (currentCount >= requiredCount)
            Door.OpenDoor();
    }
}
