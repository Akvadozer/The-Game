using System;
using UnityEngine;
using TrapSpace;
using PlayerSpace;
using EnemySpace;
using UnityEngine.SceneManagement;
using StrawSpace;
using TMPro;
using Unity.VisualScripting;

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
        StrawSpace.Strawberry.OnStraw += Bonus;
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
        StrawSpace.Strawberry.OnStraw -= Bonus;
    }

    private void Bonus()
    {
        _player._lives++;
        Debug.Log(" lives" + _player._lives);
    }
    
    
     
}
    