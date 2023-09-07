using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public delegate void OnPlayerWin();
    public static event OnPlayerWin PlayerWin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerWin?.Invoke();
    }
}
