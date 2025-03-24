using UnityEngine;
using UnityEngine.UI;

public class Player_Heath : MonoBehaviour
{
    public float MaxHealth=100;
    public float health;
    public Slider healthSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = MaxHealth;
    }

    public void UpdateVisualHealth()
    {
        if (healthSlider != null)
        {
            healthSlider.value = health;
        }
        else { Debug.LogError("health slider is null"); }

    }

    public void Take(float damage)
    {
        health -= damage;
        UpdateVisualHealth();
    }

}
