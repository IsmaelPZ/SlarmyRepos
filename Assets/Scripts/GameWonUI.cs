using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWonUI : MonoBehaviour
{

    public void Gamewon()
    {
        SceneManager.LoadScene(3);
    }
}
