using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public delegate void ClickButton();
    public static event ClickButton Click;
    private void OnMouseDown()
    {
        Click?.Invoke();
    }
}
