using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    public int activatedAltars = 0;
    public int totalAltars = 3;

    public GameObject finalPortal;

    public void AltarActivated()
    {
        activatedAltars++;

        if (activatedAltars >= totalAltars)
        {
            finalPortal.SetActive(true);
            Debug.Log("бя╡ юкрюп╡ юйрхбнбюм╡! онпрюк б╡дйпхбяъ!");
        }
    }
}
