using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultAttack : MonoBehaviour
{
    public GameObject projectile;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject attack = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = transform.position;
            Vector2 direction = (mousePos - myPos).normalized;
            attack.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            attack.GetComponent<Projectile>().damage = Random.Range(minDamage, maxDamage);
        }
    }
}
