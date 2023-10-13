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

        skyboxUp.mainTexture = scenes[sceneIndex].skyboxUp;
        skyboxDown.mainTexture = scenes[sceneIndex].skyboxDown;
        skyboxLeft.mainTexture = scenes[sceneIndex].skyboxLeft;
        skyboxRight.mainTexture = scenes[sceneIndex].skyboxRight;
        skyboxForward.mainTexture = scenes[sceneIndex].skyboxFront;
        skyboxBack.mainTexture = scenes[sceneIndex].skyboxBack;
        scenes[sceneIndex].directionLight.SetActive(true);
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
        scenes[sceneIndex].directionLight.SetActive(false);
        scenes[sceneIndex].toadSwapper.SwapMaterials();

        timer = 0;
        sceneIndex++;

        if(sceneIndex >= scenes.Length)
            return;
        
        skyboxUp.mainTexture = scenes[sceneIndex].skyboxUp;
        skyboxDown.mainTexture = scenes[sceneIndex].skyboxDown;
        skyboxLeft.mainTexture = scenes[sceneIndex].skyboxLeft;
        skyboxRight.mainTexture = scenes[sceneIndex].skyboxRight;
        skyboxForward.mainTexture = scenes[sceneIndex].skyboxFront;
        skyboxBack.mainTexture = scenes[sceneIndex].skyboxBack;
        scenes[sceneIndex].directionLight.SetActive(true);
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
        public GameObject directionLight;
    }
}
