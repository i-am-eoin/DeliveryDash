 using UnityEngine;
using System.Collections;

public class MoneySpawner : MonoBehaviour
{

    [SerializeField] int amountToSpawn = 10;
    [SerializeField] float minTimeBetweenSpawn = 0f;
    [SerializeField] float maxTimeBetweenSpawn = 10f;
    [SerializeField] GameObject cashPrefab;
    [SerializeField] float borderL = -8f;
    [SerializeField] float borderR = 8f;
    [SerializeField] float spawnerSpeed = 5f;
    [SerializeField] float cashFallSpeed = 3f;
    float direction = 1f;
    void Start()
    {
        StartCoroutine(SpawnCash());
    }

    IEnumerator SpawnCash()
    {
        for(int i=0;i<amountToSpawn;i++) {
            yield return new WaitForSeconds(Random.Range(0f, maxTimeBetweenSpawn));
            float xPosition = Random.Range(borderL, borderR);
            Vector3 spawnPosition = new Vector3(xPosition, 9, 0f);

            GameObject cash = Instantiate(
                cashPrefab,
                spawnPosition,
                Quaternion.identity
            );
            cash.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, -cashFallSpeed);
        }
    }
    void Update()
    {
        float newX = transform.position.x + direction * spawnerSpeed * Time.deltaTime;
        
        if (newX >= borderR)
        {
            newX = borderR;
            direction = -1f;
        }
        else if (newX <= borderL)
        {
            newX = borderL;
            direction = 1f;
        }
        
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
