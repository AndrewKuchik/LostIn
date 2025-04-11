using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{
    public int nextScene;
    public float nextSceneTime; 
    void Start()
    {
        StartCoroutine(NextSceneSwitch());
    }

    IEnumerator NextSceneSwitch()
    {
        yield return new WaitForSeconds(nextSceneTime);
        SceneManager.LoadScene(nextScene);
    }
}
