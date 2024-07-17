using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timeField;
    private float time;

    public Text scoreField;
    public static int scoreNum;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //timeField.text = time.ToString("F1");

        int hours = Mathf.FloorToInt(time / 3600);
        int minutes = Mathf.FloorToInt((time % 3600) / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timeField.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);

        scoreField.text = string.Format("{0}", scoreNum);

    }
}
