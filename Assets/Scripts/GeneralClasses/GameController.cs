using Assets.Scripts.GeneralClasses;
using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using static Assets.Scripts.GeneralClasses.Constants;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.MyLibraries;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform _playerView;
    [SerializeField] private GameObject _projectile;
    private ViewServices _viewServices;
    private Player _player;
    private IEnemyFactory _enemyFactory;
    private List<Enemy> _enemyList;
    private List<Projectile> _projectileList;
    private IControl _control;
    
    void Start()
    {
        _viewServices = new ViewServices();

        _enemyFactory = new FoxFactory(_playerView);
        _enemyList = new List<Enemy>();
        _projectileList = new List<Projectile>();
        _control = new ControlPC();
        Shoota shoota = new Shoota(_playerView, _projectile, _viewServices, 1, _projectileList);
        shoota.Speed = ARROW_SPEED;
        shoota.Damage = ARROW_DAMAGE;
        _player = new Player(_playerView, new MoveLinear(_playerView, PLAYER_SPEED), _control, new DamageSimple(PLAYER_MAX_HEALTH, _playerView), shoota);

        Fox fox = (Fox)_enemyFactory.Create(new Vector3(2, 2, 0));
        _enemyList.Add(fox);
        fox = (Fox)_enemyFactory.Create(new Vector3(-2, 2, 0));
        _enemyList.Add(fox);
        fox = (Fox)_enemyFactory.Create(new Vector3(2, -2, 0));
        _enemyList.Add(fox);
        fox = (Fox)_enemyFactory.Create(new Vector3(-2, -2, 0));
        _enemyList.Add(fox);
        fox = (Fox)_enemyFactory.Create(new Vector3(0, 2, 0));
        _enemyList.Add(fox);
        fox = (Fox)_enemyFactory.Create(new Vector3(2, 0, 0));
        _enemyList.Add(fox);
        fox = (Fox)_enemyFactory.Create(new Vector3(-2, 0, 0));
        _enemyList.Add(fox);
        fox = (Fox)_enemyFactory.Create(new Vector3(0, -2, 0));
        _enemyList.Add(fox);
    }

    
    void Update()
    {
        _player.HandleControls(Time.deltaTime);
        foreach (var enemy in _enemyList)
        {
            if (enemy != null)
                enemy.Move(Time.deltaTime);
        }
        foreach (var projectile in _projectileList)
        {
            if (projectile is Arrow)
                ((Arrow)projectile).Move(Time.deltaTime);
        }
    }
}
