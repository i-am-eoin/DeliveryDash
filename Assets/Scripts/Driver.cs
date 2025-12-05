using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float padding = 1.4f;
    [SerializeField] int health = 100;
    [SerializeField] AudioClip carHitSound;
    [SerializeField] [Range(0, 1)] float carHitSoundVolume = 0.75f;

    float xMin;
    float xMax;

    void Start()
    {
        SetupMoveBoundaries();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        transform.position = new Vector2(newXPos, transform.position.y);
    }

    private void SetupMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0)).x - padding;
    }    
    private void ProcessHit(DmgDealer damageDealer)
    {
        health -= damageDealer.GetDamage();  
        damageDealer.Hit();
        //AudioSource.PlayClipAtPoint(carHitSound, Camera.main.transform.position, carHitSoundVolume);

    }    
    private void OnTriggerEnter2D(Collider2D other)
    {
        DmgDealer damageDealer = other.gameObject.GetComponent<DmgDealer>();
        ProcessHit(damageDealer);
    }
}