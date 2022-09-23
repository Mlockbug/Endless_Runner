using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerControll : MonoBehaviour
{
    public GameObject player;
    //variables to be used in spawning platforms
    public GameObject[] platforms;
    float p_timeToNextSpawn;
    float p_timeSinceLastSpawn = 0f;
    public float p_minSpawnTime = 1f;
    public float p_maxSpawnTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(platforms[Random.Range(0, platforms.Length)], new Vector3(transform.position.x+5f,transform.position.y,transform.position.z), Quaternion.identity);
        p_timeToNextSpawn = Random.Range(p_minSpawnTime, p_maxSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        p_timeSinceLastSpawn += Time.deltaTime;

        if (p_timeSinceLastSpawn > p_timeToNextSpawn)
        {
            float offset = Random.Range(-2f, 2f);
            float newValueY = transform.position.y + offset;
            while (newValueY < -4f || newValueY > 3f)
            {
                offset = Random.Range(-2f, 2f);
                newValueY = transform.position.y + offset;
            }
            Instantiate(platforms[Random.Range(0, platforms.Length)], new Vector3(transform.position.x, newValueY, transform.position.z), Quaternion.identity);
            p_timeToNextSpawn = Random.Range(p_minSpawnTime, p_maxSpawnTime);
            p_timeSinceLastSpawn = 0f;
        }
    }
}
