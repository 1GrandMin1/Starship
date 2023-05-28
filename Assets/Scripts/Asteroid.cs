using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private int damage = 1;
    public float speed;
    public float lifeTime;
    public GameObject effect;

    private void Update()
    {
        transform.Translate(Vector2.left * speed);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.CompareTag("Player"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            other.GetComponent<Player>().DamageOnPlayer(damage);
            Destroy(gameObject);
        }
    }
}
