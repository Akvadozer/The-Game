using System;
using UnityEngine;
using TrapSpace;
using PlayerSpace;
using SlimeSpace;
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
        TrapSpace.Trap.OnHit += TrapCollision;
    }

    private void TrapCollision()
    {
        _player.Damage();

        //добавляем метод отнимания жизней из игрока и анимация
    }

    private void OnDisable()
    {
        TrapSpace.Trap.OnHit -= TrapCollision;
    }

    
}