using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Slime;
    public float interval = 2f;

    public float minInterval = 0.7f; 

    private float nextSpawnTime;
    private float timeElapsed;
    private float timeToIncrease = 120f;



    private void Awake()
    {
        ResetSpawner();
    }

    private void OnEnable()
    {
        ResetSpawner();
    }

    private void ResetSpawner()
    {
        nextSpawnTime = Time.timeSinceLevelLoad;
        timeElapsed = 0f;
        interval = 2f;
    }
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= timeToIncrease)
        {
            interval = Mathf.Max(minInterval, interval / 2f);
            timeElapsed = 0f; //Reset
        }
        
        if (Time.timeSinceLevelLoad >= nextSpawnTime)
        {
            spawnSlime();
            nextSpawnTime = Time.timeSinceLevelLoad + interval;
        }
    }

    private void spawnSlime()
    {

            float myRand = Random.value;

        if(myRand < 0.20)
        {
            GameObject slime = Instantiate(Slime, transform.position, Quaternion.identity);
        }
        else
        {

        }  
    }
}
