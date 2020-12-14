using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public int damage = 15;
    Rigidbody rb;

    public float speed = 1500f;
    public GameObject ImpactEffect;
    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Transform target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 direction = target.position - transform.position;
        rb.AddForce(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            PlayerHP playerHealth = collision.transform.GetComponent<PlayerHP>();
            playerHealth.PlayerHealth = playerHealth.PlayerHealth - damage;
            Destroy(gameObject);
        }
        else
        {
            Instantiate(ImpactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }            
    }
}
