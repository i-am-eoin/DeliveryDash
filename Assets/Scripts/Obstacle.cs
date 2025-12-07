using UnityEngine;

public class Obstacle : MonoBehaviour
{
    float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 3f;
    [SerializeField] AudioClip bulletSound;
    [SerializeField] [Range(0, 1)] float bulletSoundVolume = 0.25f;



    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f) {
            AudioSource.PlayClipAtPoint(bulletSound, Camera.main.transform.position, bulletSoundVolume);
            Shoot();    
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }


    private void Shoot()
    {
        GameObject enemyLaser = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
        enemyLaser.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, -bulletSpeed);
    }    
}
