using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    // Start is called before the first frame update
    public int sceneBuildIndex;
    
    public void OpenScene() {
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }

}
