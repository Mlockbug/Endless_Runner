using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnerControll : MonoBehaviour
{
    public GameObject player;
    //variables to be used in spawning platforms
    public GameObject[] platforms;
    float p_timeToNextSpawn;
    float p_timeSinceLastSpawn = 0f;
    public float p_minSpawnTime = 1f;
    public float p_maxSpawnTime = 3f;

    public GameObject[] pickUps;

    public GameObject shuriken;
    float cooldown = 0;

    public GameObject missile;
    public GameObject missileSpawn;

    public Text shurikenTimer;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(platforms[Random.Range(0, platforms.Length)], new Vector3(transform.position.x+5f,transform.position.y,transform.position.z), Quaternion.identity);
        p_timeToNextSpawn = Random.Range(p_minSpawnTime, p_maxSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        p_timeSinceLastSpawn += Time.deltaTime;
        cooldown -= Time.deltaTime;
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
            Instantiate(pickUps[Random.Range(0, pickUps.Length)], new Vector3(transform.position.x, newValueY + 1f, transform.position.z), Quaternion.identity);
            p_timeToNextSpawn = Random.Range(p_minSpawnTime, p_maxSpawnTime);
            p_timeSinceLastSpawn = 0f;
        }

        if (Input.GetKeyDown(KeyCode.E) && cooldown <= 0)
        {
            Instantiate(shuriken, player.transform.position, Quaternion.identity);
            cooldown = 3f;
        }
        
        if (cooldown<=0)
        {
            shurikenTimer.text = "0";
        }
        else if (cooldown <= 1)
        {
            shurikenTimer.text = "1";
        }
        else if (cooldown <= 2)
        {
            shurikenTimer.text = "2";
        }
        else if (cooldown <= 3)
        {
            shurikenTimer.text = "3";
        }
    }
}
