using UnityEngine;
using UnityEngine.UI;

public class Player_Heath : MonoBehaviour
{
    public float MaxHealth = 100f;
     float health;
    public Slider healthSlider;

    void Start()
    {
        health = MaxHealth;

        if (healthSlider != null)
        {
            healthSlider.maxValue = MaxHealth;
            healthSlider.value = health;
        }
        else
        {
            Debug.LogError("Health Slider is not assigned in the Inspector!");
        }
    }

    public void UpdateVisualHealth()
    {
        if (healthSlider != null)
        {
            healthSlider.value = health;
        }
        else
        {
            Debug.LogError("Health slider is null");
        }
    }

    public void Take(float damage)
    {
        //Debug.Log("Before taking damage: " + health+" "+damage); // Check the health value before modification
        health =- damage;
        //Debug.Log("After taking damage: " + health+" "+damage);  // Check the health value after modification

        UpdateVisualHealth();
    }
}
