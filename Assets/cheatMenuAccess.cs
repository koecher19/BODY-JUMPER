using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cheatMenuAccess : MonoBehaviour
{
    /*
     * put load scene counter on maximum and enabled load scene
     */
    public GameObject loadChapter;
    SaveStateLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        this.sceneLoader = GetComponent<SaveStateLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f2"))
        {
            ActivateCheat();
        }
    }

    void ActivateCheat()
    {
        this.sceneLoader.savedSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
        this.sceneLoader.UpdateSceneIndex();
        this.loadChapter.SetActive(true);
    }
}
