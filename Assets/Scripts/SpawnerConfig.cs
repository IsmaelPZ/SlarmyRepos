using UnityEngine;

public class SpawnerConfig : MonoBehaviour
{
    public GameObject northernSpawner;
    public GameObject southernSpawner;
    public GameObject easternSpawner;
    public GameObject westernSpawner;

    private void Start()
    {
        northernSpawner.SetActive(true);
        southernSpawner.SetActive(false);
        easternSpawner.SetActive(false);
        westernSpawner.SetActive(false);
    }
    private void Update()
    {
        int roundedTime = Mathf.FloorToInt(Time.timeSinceLevelLoad);

        if (roundedTime >= 90 && roundedTime < 180)
        {

            northernSpawner.SetActive(false);
            southernSpawner.SetActive(true);
            easternSpawner.SetActive(true);
            westernSpawner.SetActive(false);
        }
        else if (roundedTime >= 180 && roundedTime < 270)
        {
            northernSpawner.SetActive(true);
            southernSpawner.SetActive(true);
            easternSpawner.SetActive(false);
            westernSpawner.SetActive(false);
        }
        else if (roundedTime >= 270 && roundedTime < 360)
        {
            northernSpawner.SetActive(true);
            southernSpawner.SetActive(true);
            easternSpawner.SetActive(true);
            westernSpawner.SetActive(false);
        }
        else if (roundedTime >= 360 && roundedTime < 389)
        {
            northernSpawner.SetActive(false);
            southernSpawner.SetActive(false);
            easternSpawner.SetActive(false);
            westernSpawner.SetActive(false);
        }
        else if (roundedTime >= 390)
        {
            northernSpawner.SetActive(false);
            southernSpawner.SetActive(false);
            easternSpawner.SetActive(false);
            westernSpawner.SetActive(true);
        }

    }
}
