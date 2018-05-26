using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour {
    //public AudioSource ButtonSound;
    public string SceneName;

    public void moveScene()
    {
        //AudioSource buttonSound = ButtonSound.GetComponent<AudioSource>();
        //buttonSound.PlayOneShot(buttonSound.clip);

        Scene thisScene = SceneManager.GetActiveScene();

        if(thisScene.name != SceneName)
        {
            SceneManager.LoadScene(SceneName);
        }
    }

}
