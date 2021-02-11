using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public int damage = 15;
    Rigidbody rb;
    public Transform shootpoint;

    public float speed = 1500f;
    public GameObject ImpactEffect;
    [SerializeField]
    private Transform projectile;
    // Start is called before the first frame update

    private void Awake()
    {
        InvokeRepeating("spawnProjectile", Random.Range(1f, 10f), Random.Range(1f,10f));
       
        rb = GetComponent<Rigidbody>();
        Transform target = GameObject.FindGameObjectWithTag("Target1").transform;
        Vector3 direction = target.position - transform.position;
        rb.AddForce(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            PlayerHP playerHealth = collision.transform.GetComponent<PlayerHP>();
            playerHealth.PlayerHealth = playerHealth.PlayerHealth - damage;
            Destroy(gameObject);
        }
        else
        {
            var test = Instantiate(ImpactEffect, transform.position, transform.rotation);
            //test.transform.parent = transform;
            Destroy(gameObject);

        }
    }
    private void spawnProjectile()
    {
        Instantiate(projectile, shootpoint.transform.position, Quaternion.identity);
    }
}
