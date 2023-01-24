using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIButton : MonoBehaviour
{
    [SerializeField]
    private UIScreenID ScreenID;

    private Button thisButton;

    private void Awake() => thisButton = GetComponent<Button>();

    private void OnEnable() => thisButton.onClick.AddListener(OpenScreen);

    private void OnDisable() => thisButton.onClick.RemoveListener(OpenScreen);

    public virtual void OpenScreen() => UIManager.Instance.OpenScreen(ScreenID);
}
