using Assets.Scripts.GeneralClasses;
using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using static Assets.Scripts.GeneralClasses.Constants;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform playerView;
    Player _player;
    
    void Start()
    {
        _player = new Player(playerView, new MoveLinear(playerView, PLAYER_SPEED), new ControlPC(), new DamageSimple(PLAYER_MAX_HEALTH, playerView));
    }

    
    void Update()
    {
        _player.Move(Time.deltaTime);
    }
}
