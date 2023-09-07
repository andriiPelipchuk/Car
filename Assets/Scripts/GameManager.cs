using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] CarMovement _carMovement;
    [SerializeField] UIManager _UI;

    private void Start()
    {
        Restart();
        CarMovement.PlayerDied += OpenLosePopUp;
        UIManager.restart += Restart;
        Win.PlayerWin += OpenWinPopUp;
    }
    private void OpenLosePopUp()
    {
        _UI.OpenLosePopUp();
    }
    private void OpenWinPopUp()
    {
        _carMovement.SetZeroSpeed();
        _UI.OpenWinPopUp();
    }
    private void Restart()
    {
        
        _carMovement.BasicPosition();
    }
}
