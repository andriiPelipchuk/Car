using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _lose, _win, _button;

    public delegate void RestartLevel();
    public static event RestartLevel restart;

    private void Start()
    {
        RestartButton.Click += Restart;
    }
    public void OpenWinPopUp()
    {
        _win.SetActive(true);
        _button.SetActive(true);
    }
    public void OpenLosePopUp()
    {
        _lose.SetActive(true);
        _button.SetActive(true);
    }
    public void Restart()
    {
        _lose.SetActive(false);
        _win.SetActive(false);
        _button.SetActive(false);
        restart?.Invoke();
    }

}
