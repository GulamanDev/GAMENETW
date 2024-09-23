using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TMP_Text healthLabel;
    [SerializeField] Enemy damage;

    private int maxHealth = 100;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
        Debug.Log("Planet initialized with health: " + currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);
        if (other.transform.tag == "Enemy")
        {
            Debug.Log("Enemy detected: " + other.gameObject.name);
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            TakeDamage(enemy.damage); // Adjust damage value as needed
            other.gameObject.SetActive(false); // Deactivate the enemy
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Planet took damage: " + damage + ", current health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
        UpdateHealthUI();
    }

    private void Die()
    {
        Debug.Log("Planet has died. Game Over.");
        GameObject gameOverObject = GameObject.FindWithTag("GameOver");
        if (gameOverObject != null)
        {
            gameOverObject.SetActive(true);
        }
    }

    private void UpdateHealthUI()
    {
        healthSlider.value = currentHealth;
        healthLabel.text = currentHealth.ToString();
        Debug.Log("Health UI updated: " + currentHealth + "/" + maxHealth);
    }
}
