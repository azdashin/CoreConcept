using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{

    public int maxHealth = 100;
    public static int currentHealth;

    public HealthBar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void FixedUpdate()
    {
        if (currentHealth < 1) 
        {
            SceneManager.LoadScene("FirstEvent");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Danger"))
        {
            TakeDamage(10);
        }
        if (other.CompareTag("Projectile"))
        {
            TakeDamage(1);
        }
    }

    void TakeDamage(int damage) 
    {
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);
    }
}
