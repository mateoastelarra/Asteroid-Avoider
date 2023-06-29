using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] private Vector2 forceRange;
    private float force;

    private void Start() 
    {
        Rigidbody RB = GetComponent<Rigidbody>();
        force = Random.Range(forceRange.x, forceRange.y);
        RB.AddForce((player.transform.position - transform.position) * force);
    }
    private void OnTriggerEnter(Collider other) 
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        
        if ( playerHealth == null){return;}

        playerHealth.Crash();
    }
}
