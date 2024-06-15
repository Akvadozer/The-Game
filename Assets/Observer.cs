using System;
using UnityEngine;
using TrapSpace;
using PlayerSpace;
using EnemySpace;
using UnityEngine.SceneManagement;

public class Observer : MonoBehaviour
{
    internal Player _player;
    
    private void Start()
    {
        _player = GetComponent<Player>();
    }
    
    private void OnEnable() //подписка на делегат
    {
        TrapSpace.Trap.OnHit += TrapCollision;
        EnemySpace.Slime.OnEnemyHit += EnemyCollision;
    }

    private void TrapCollision()
    {
        _player.Damage();

        //добавляем метод отнимания жизней из игрока и анимация
    }

    private void EnemyCollision()
    {
        _player.Damage();
    }

    private void OnDisable() //отписка
    {
        TrapSpace.Trap.OnHit -= TrapCollision;
        EnemySpace.Slime.OnEnemyHit -= EnemyCollision;
    }
    

    
}