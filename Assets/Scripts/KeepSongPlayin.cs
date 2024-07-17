using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepSongPlayin : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject[] themeSong = GameObject.FindGameObjectsWithTag("GameMusic");
        if(themeSong.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
