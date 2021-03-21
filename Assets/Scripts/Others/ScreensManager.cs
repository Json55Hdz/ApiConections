using DoozyUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreensManager : MonoBehaviour
{
    public static ScreensManager Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }
    public void ShowScreenAndHideOthers(string group,string screen,bool AddNavStory)
    {
        UINavigation.ShowUiElementAndHideAllTheOthers(screen,group,AddNavStory);
    }
    
    public void ShowScreen(string group,string screen,bool AddNavStory)
    {
        UINavigation.ShowUiElement(screen,group,AddNavStory);
    }

    public void ShowSpecifitByIdentifier (ScreenIdentifier screen)
    {
        ShowScreen(screen.elemetCat,screen.elementName,false);
    }
    public void ShowANdHideOthersSpecifitByIdentifier (ScreenIdentifier screen)
    {
        ShowScreenAndHideOthers(screen.elemetCat,screen.elementName,false);
    }

}
