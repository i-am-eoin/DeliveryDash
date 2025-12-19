using UnityEngine;
using TMPro; 

public class Driver : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float padding = 1.4f;
    [SerializeField] public int health = 100;
    [SerializeField] AudioClip carHitSound;
    [SerializeField] [Range(0, 1)] float carHitSoundVolume = 0.75f;
    [SerializeField] public TMP_Text scoreText;   
    [SerializeField] public TMP_Text healthText;
    [SerializeField] GameObject carExplosion;

    float xMin;
    float xMax;
    public int score = 0;
    public bool dead = false;
    public int level = 1;
    void Start()
    {
        SetupMoveBoundaries();
    }

    void Update()
    {
        scoreText.text = $"Score: {score}";
        healthText.text = $"Health: {health}";
        Move();
        if (health <= 0) {
            StaticScoreAndHealth.score = score;
            StaticScoreAndHealth.health = health;
            dead = true;
            return;
        }
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
    private void ProcessHit(DmgDealer damageDealer, Vector3 hitPosition, bool isBanana)
    {
        if (damageDealer == null) { return; }
        if (!isBanana) {
            GameObject explosion = Instantiate(carExplosion, hitPosition, Quaternion.identity);
            Destroy(explosion, 1f);
        }
        health -= damageDealer.GetDamage();
        StaticScoreAndHealth.health = health;
        damageDealer.Hit();
        AudioSource.PlayClipAtPoint(carHitSound, Camera.main.transform.position, carHitSoundVolume);
        if (health <= 0) {
            StaticScoreAndHealth.score = score;
            StaticScoreAndHealth.health = health;
            dead = true;
            return;
        }
    }    
    private void OnTriggerEnter2D(Collider2D other)
    {
        DmgDealer damageDealer = other.gameObject.GetComponent<DmgDealer>();
        bool isBanana = other.gameObject.CompareTag("Banana");
        ProcessHit(damageDealer, other.transform.position, isBanana);
        
    }
}