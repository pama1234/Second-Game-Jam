using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TitleController : MonoBehaviour
{
    public GameObject mainBackground;
    public GameObject subBackground;
    //MenuSystem
    public MainMenu mainMenu;
    public ContinueMenu continueMenu;
    public DeveloperMenu developerMenu;
    public SettingMenu settingMenu;
    private Stack<TitleMenuBase> menuStack = new Stack<TitleMenuBase>();
    private void Start()
    {
        mainBackground.SetActive(true);
        subBackground.SetActive(false);
        mainMenu.Open();
        settingMenu.selectButton.SetButtons();
        AudioManager.Instance.PlayBGM(BackgroundMusic.TitleScene);
        SaveManager.Instance.Init();
    }
    public void OpenMenu(TitleMenuBase menu)
    {
        //Deactivate top menu
        if (menuStack.Count > 0)
        {
            foreach (var singlemenu in menuStack)
            {
                singlemenu.gameObject.SetActive(false);
            }
        }
        menuStack.Push(menu);
    }
    public void CloseMenu()
    {
        var instance = menuStack.Pop();
        instance.gameObject.SetActive(false);
        //Reactivate top menu
        var topmenu = menuStack.Peek();
        topmenu.gameObject.SetActive(true);
    }
}
