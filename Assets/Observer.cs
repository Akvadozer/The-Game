using System;
using UnityEngine;
using TrapSpace;
using PlayerSpace;
using UnityEngine.SceneManagement;

public class Observer : MonoBehaviour
{
    internal Player _player;
    private void Start()
    {
        _player = GetComponent<Player>();
    }
    private void OnEnable()
    {
        TrapSpace.Trap.OnHit += FireCollision;
    }

    private void FireCollision()
    {
        _player.Damage();
        Debug.Log( _player._lives);

        //добавляем метод отнимания жизней из игрока и анимация
    }

    private void OnDisable()
    {
        TrapSpace.Trap.OnHit -= FireCollision;
    }
}