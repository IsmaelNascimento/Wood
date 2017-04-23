using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonsUis : MonoBehaviour
{
    public void SceneLoad(int iScene)
    {
        SceneManager.LoadScene(iScene);
    }
}
