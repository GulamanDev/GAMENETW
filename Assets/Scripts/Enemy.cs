using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //AI Initial Health
    [SerializeField] private float health;
    //AI Max Health
    [SerializeField] private float maxHealth;
    //HelthBar
    [SerializeField] EnemyHealth healthBar;
    [SerializeField] private float moveSpeed = 5.0f;
   
    public int damage = 10;
    public int bulletDamage = 50;
    public float Health => health;
    public float MaxHealth => maxHealth;

    private Transform target = null;
    private ScoreManager scoreManager;

    private void OnEnable(){
        scoreManager = FindObjectOfType<ScoreManager>();
        healthBar = GetComponentInChildren<EnemyHealth>();
        health = maxHealth;
        healthBar.UpdateHealthBar(health , maxHealth);
        LookAtTarget();
    }

    public void SetTarget(Transform target){
        this.target = target;
    }

    private void Update(){
        Move();
    }
    
    private void LookAtTarget(){
        Quaternion newRotation;
        Vector3 targetDirection = target == null ? transform.position : transform.position - target.transform.position;
        newRotation = Quaternion.LookRotation(targetDirection, Vector3.forward);
        newRotation.x = 0;
        newRotation.y = 0;
        transform.rotation = newRotation;
    }

    private void Move(){
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Bullet bullet = other.gameObject.GetComponent<Bullet>();
        if (other.CompareTag("Bullet"))
        {
            health -= bulletDamage;
            healthBar.UpdateHealthBar(health , maxHealth);
            if (health <= 0)
            {
            this.gameObject.SetActive(false);
            scoreManager.EnemyDeactivated();
            }
        }
        if (other.CompareTag("Planet"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
