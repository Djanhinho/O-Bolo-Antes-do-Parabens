using System;
using Script.Enemy;
using Script.Player;
using UnityEngine;

namespace Script.GameManager
{
    public class EventManager : MonoBehaviour
    {
        private PlayerControl playerControl; 
        private EnemyLife enemyLife;
        private UIManager uiManager;

        void Start()
        {
            playerControl = FindObjectOfType<PlayerControl>();
            enemyLife = FindObjectOfType<EnemyLife>();
            uiManager = FindObjectOfType<UIManager>();
        
        }

    }
}
