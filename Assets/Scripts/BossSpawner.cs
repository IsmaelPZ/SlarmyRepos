using UnityEngine;

public class BossSpawner : MonoBehaviour
{

    public GameObject SlimeBoss;

    private bool hasSpawned = false;

   
    private void Update()
    {
        int roundedTime = Mathf.FloorToInt(Time.timeSinceLevelLoad);
        if (!hasSpawned && roundedTime >= 392)

        {
            SpawnBoss();
            hasSpawned = true;
        }   
    }
    
    private void SpawnBoss()
    {
        Instantiate(SlimeBoss, transform.position, Quaternion.identity);
    }


}
