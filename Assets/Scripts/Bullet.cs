using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    public int damage = 100;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable(){
        // the object is already positioned from the instantiation, simply move it on y-axis
        rb.velocity = transform.up * speed;
        StartCoroutine(DisableOverTime());
    }

    private IEnumerator DisableOverTime(){
        yield return new WaitForSeconds(2.0f);
        this.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // Check if the collider is tagged as "Enemy"
        {
            this.gameObject.SetActive(false); // Deactivate the bullet
        }
    }
}

