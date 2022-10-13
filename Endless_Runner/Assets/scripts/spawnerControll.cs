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
    float m_timeToNextSpawn;
    float m_timeSinceLastSpawn = 0f;
    public float m_minSpawnTime = 1f;
    public float m_maxSpawnTime = 2f;

    public Text shurikenTimer;

    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(platforms[Random.Range(0, platforms.Length)], new Vector3(transform.position.x+5f,transform.position.y,transform.position.z), Quaternion.identity);
        p_timeToNextSpawn = Random.Range(p_minSpawnTime, p_maxSpawnTime);
        m_timeToNextSpawn = Random.Range(m_minSpawnTime, m_maxSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (!(isDead))
        {
            p_timeSinceLastSpawn += Time.deltaTime;
            m_timeSinceLastSpawn += Time.deltaTime;
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

            if (m_timeSinceLastSpawn > m_timeToNextSpawn)
            {
                float offset = Random.Range(-2f, 2f);
                float newValueY = missileSpawn.transform.position.y + offset;
                while (newValueY < -4f || newValueY > 3f)
                {
                    offset = Random.Range(-2f, 2f);
                    newValueY = missileSpawn.transform.position.y + offset;
                }
                missileSpawn.transform.position = new Vector3(missileSpawn.transform.position.x, newValueY, missileSpawn.transform.position.z);
                Instantiate(missile, missileSpawn.transform.position, Quaternion.identity);
                m_timeToNextSpawn = Random.Range(m_minSpawnTime, m_maxSpawnTime);
                m_timeSinceLastSpawn = 0f;
            }

            if (Input.GetKeyDown(KeyCode.E) && cooldown <= 0)
            {
                Instantiate(shuriken, new Vector3(player.transform.position.x + 0.5f, player.transform.position.y, player.transform.position.z), Quaternion.identity);
                cooldown = 3f;
            }

            if (cooldown <= 0)
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

    public void Dead()
	{
        isDead = true;
	}
}
