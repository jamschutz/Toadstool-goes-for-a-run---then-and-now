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
    public Transform youngToad;
    


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
        if(sceneIndex < scenes.Length && Input.GetKey(KeyCode.Space)) {
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
        youngToad.localScale = new Vector3(scenes[sceneIndex].toadSize, scenes[sceneIndex].toadSize, scenes[sceneIndex].toadSize);
    }


    [System.Serializable]
    public class SceneInfo
    {
        public float timeInScene;
        public float toadSize;
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
