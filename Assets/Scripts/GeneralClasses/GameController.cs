using Assets.Scripts.GeneralClasses;
using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using static Assets.Scripts.GeneralClasses.Constants;
using UnityEngine;
using Assets.Scripts.MyLibraries;
using Assets.Scripts.enums;
using Assets.Scripts.ScriptableObjects;
using TMPro;

namespace Assets.Scripts.GeneralClasses
{
    internal sealed class GameController : MonoBehaviour
    {
        [SerializeField] private Transform _playerView;
        [SerializeField] private TextMeshProUGUI _pointsText;
        Game _game;

        void Start()
        {
            _game = new Game(_playerView, _pointsText);
            _game.InitGame();
            _game.StartGame();
        }


        void Update()
        {
            _game.Update();
        }
    }
}