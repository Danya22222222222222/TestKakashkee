using UnityEngine;

public class ShowCircleOnTouch : MonoBehaviour
{
    public GameObject circle; // сюди перет€гни коло з сцени

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // коли гравець доторкаЇтьс€ до чогось
        if (circle != null)
        {
            circle.GetComponent<SpriteRenderer>().enabled = true; // зробити видимим
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // коли гравець в≥д≥йшов
        if (circle != null)
        {
            circle.GetComponent<SpriteRenderer>().enabled = false; // знову сховати
        }
    }
}