using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance => GameManager.Instance.UIManager;

    private Dictionary<UIScreenID, UIScreen> _uiScreens;
    [SerializeField]
    private List<UIScreen> _uiScreensList;

    private UIScreenID _currentScreen;
    private UIScreenID _previousScreen;
    private void Awake()
    {
        InitScreens();
    }

    private void InitScreens()
    {
        _uiScreens = new();
        foreach (var e in _uiScreensList)
        {
            if (_uiScreens.ContainsKey(e.ScreenID))
            {
                Debug.LogError($"You are adding a duplicate Key {e.ScreenID}, make sure the keys are unique!");
                continue;
            }
            _uiScreens.Add(e.ScreenID, e);
        }
        _currentScreen = UIScreenID.Main;
        OpenScreen(UIScreenID.Main);
    }


    public void OpenScreen(UIScreenID ID)
    {

        if (!_uiScreens.ContainsKey(ID))
        {
            Debug.LogError($"No screen found with ID {ID}");
            return;
        }

        if (ID == UIScreenID.None)
        {
            Debug.LogError("Requested screen with no ID");
            return;
        }

        var screen = _uiScreens[ID];
        _previousScreen = _currentScreen;
        _currentScreen = ID;
        var prevScreen = _uiScreens[_previousScreen];

        if (!screen.IsPopup)
        {
            CloseScreens();
        }
        if (prevScreen.IsPopup)
        {
            ClosePopup();
        }
        screen.gameObject.SetActive(true);
    }

    public void ClosePopup()
    {
        var screen = _uiScreens[_previousScreen];
        screen.gameObject.SetActive(false);
    }
    private void CloseScreens()
    {
        var previousScreen = _uiScreens[_previousScreen];
        foreach (var e in _uiScreens)
        {
            if (previousScreen.IsPopup)
                continue;

            e.Value.gameObject.SetActive(false);
        }
    }

    public UIScreenID GetPreviousScreen()
    {
        return _previousScreen;
    }

    public UIScreenID GetCurrentScreen()
    {
        return _currentScreen;
    }
}