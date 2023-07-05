using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    //Fader��û��ʼ�ã�ֱ�Ӽ��գ�������
    string originScene;
    string nowScene;
    private void Start()
    {
        originScene = SceneManager.GetActiveScene().name;
        nowScene = SceneManager.GetActiveScene().name;
    }
    private void Update()
    {
        nowScene = SceneManager.GetActiveScene().name;
        if(nowScene != originScene)
        {
            originScene = nowScene;
            if(nowScene == "IntroScene")
            {
                AudioManager.Instance.PlayBGM(BackgroundMusic.IntroScene);
            }
        }
    }
}
