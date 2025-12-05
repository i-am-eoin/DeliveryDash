using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float health = 100;
    private void OnTriggerEnter2D(Collider2D other)
    {
        DmgDealer damageDealer = other.gameObject.GetComponent<DmgDealer>();
        health -= damageDealer.GetDamage();
    }
}

