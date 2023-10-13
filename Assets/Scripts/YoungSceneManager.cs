using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoungSceneManager : MonoBehaviour
{
    public SceneInfo[] scenes;
    public Material skyboxUp;
    public Material skyboxDown;
    public Material skyboxLeft;
    public Material skyboxRight;
    public Material skyboxForward;
    public Material skyboxBack;
    


    private int sceneIndex;
    private float timer;


    private void Start()
    {
        sceneIndex = 0;
        timer = 0;
    }


    private void Update()
    {
        if(Input.GetKey(KeyCode.Space)) {
            timer += Time.deltaTime;

            if(timer > scenes[sceneIndex].timeInScene) {
                GoToNextScene();
            }
        }
    }


    private void GoToNextScene()
    {
        scenes[sceneIndex].toadSwapper.SwapMaterials();
        skyboxUp.mainTexture = scenes[sceneIndex].skyboxUp;
        skyboxDown.mainTexture = scenes[sceneIndex].skyboxDown;
        skyboxLeft.mainTexture = scenes[sceneIndex].skyboxLeft;
        skyboxRight.mainTexture = scenes[sceneIndex].skyboxRight;
        skyboxForward.mainTexture = scenes[sceneIndex].skyboxFront;
        skyboxBack.mainTexture = scenes[sceneIndex].skyboxBack;

        timer = 0;
        sceneIndex++;
    }


    [System.Serializable]
    public class SceneInfo
    {
        public float timeInScene;
        public SwapToadMaterials toadSwapper;
        public Texture skyboxUp;
        public Texture skyboxDown;
        public Texture skyboxLeft;
        public Texture skyboxRight;
        public Texture skyboxFront;
        public Texture skyboxBack;
    }
}
