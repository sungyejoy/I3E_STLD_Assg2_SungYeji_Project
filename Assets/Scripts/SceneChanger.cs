using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int targetSceneIndex;

    public void ChangeScene()
    {
        SceneManager.LoadScene(targetSceneIndex);
    }

}
