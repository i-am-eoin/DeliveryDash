using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] AudioClip pickupSound;
    [SerializeField] [Range(0, 1)] float pickupVolume = 0.75f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("MoneyShredder")) { return; }
        if (collision.gameObject.name.Equals("Banana(Clone)")) { return; }
        collision.gameObject.GetComponent<Driver>().score += 5;
        Destroy(gameObject);      
        AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position, pickupVolume);
    }
}
