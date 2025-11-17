using UnityEngine;

public class SpotTrigger : MonoBehaviour
{
    public Door2 door;              // двері які треба відкрити
    public string requiredTag = "PuzzleObject";  // тег об’єкта який має попасти в зону

    private bool doorOpened = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (doorOpened) return;

        if (other.CompareTag(requiredTag))
        {
            door.OpenDoor();
            doorOpened = true;

            Debug.Log("Правильний предмет вставлено — двері відкрились!");
        }
    }
}
