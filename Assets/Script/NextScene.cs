using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void Scene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
