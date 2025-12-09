using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] AudioClip pickupSound;
    [SerializeField] [Range(0, 1)] float pickupVolume = 0.75f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var driver = collision.gameObject.GetComponent<Driver>();
        if (driver != null)
        {
            driver.score += 5;
            Destroy(gameObject); 
            AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position, pickupVolume);
        }     
    }
}
