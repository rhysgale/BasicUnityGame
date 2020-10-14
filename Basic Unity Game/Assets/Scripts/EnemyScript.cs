using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject _cloudParticlePrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BirdScript birdCollision = collision.collider.GetComponent<BirdScript>();

        if (birdCollision != null)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        EnemyScript enemy = collision.collider.GetComponent<EnemyScript>();
        if (enemy != null)
            return;

        var hitOnHead = collision.contacts[0].normal.y < -0.5;
        if (hitOnHead)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
