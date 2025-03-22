using UnityEngine;

public class Player_Heath : MonoBehaviour
{
    public float MaxHealth=100;
    public float health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = MaxHealth;
    }


    public void Take(float damage)
    {
        health -= damage;
    }
}
