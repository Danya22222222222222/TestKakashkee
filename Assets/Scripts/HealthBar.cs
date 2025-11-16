using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Image healthbar;
    public float maxHealth = 100f;
    public float HP;
    // Start is called before the first frame update
    void Start()
    {
        healthbar = GetComponent<Image>();
        HP= maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = HP / maxHealth;
    }
}
