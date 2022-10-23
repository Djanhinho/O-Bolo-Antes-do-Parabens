using Ez;
using Script.Player;
using Trisibo;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Script.GameManager
{
    public class Game : MonoBehaviour
    {
        [SerializeField]private SceneField sceneThingy;
        [SerializeField]private Transform[] spawn;
        [SerializeField]private GameObject enemy;
    
        private PlayerLife player;
        private UIManager uiManager;

        public static int coins;
        public static Game Manager;
        public UnityEvent restartGame;
        public UnityEvent pauseGame;

        void Awake()
        {
            if (Manager == null)
            {
                Manager = this;
            }
        }

        void Start()
        {
            player = FindObjectOfType<PlayerLife>();
            uiManager = FindObjectOfType<UIManager>();
        }

        void Update()
        {
            //~~Código para teste, remover posteriormente!!!!~~
            if(Input.GetKeyDown(KeyCode.F5))
            {
                SceneManager.LoadScene(sceneThingy.BuildIndex);
            }
            //~~Código para teste, remover posteriormente!!!!~~
        
            PausingGame();
            CheckPlayerLife();
            CheckGameState();

        }

        void PausingGame()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseGame.Invoke();
                Time.timeScale = 0;
            }
        }
        void CheckPlayerLife()
        {
            var h = player.gameObject.Request<IArmor, int?>(_ => _.GetHealth());
            if (h <= 0)
            {
                restartGame.Invoke();
            }
        }
    
        public void RestartLevel()
        {
            SceneManager.LoadScene(sceneThingy.BuildIndex);
        }

        public void OnDied()
        {
            var randomSpawn = Random.Range(0, spawn.Length);
            Instantiate(enemy, spawn[randomSpawn].position, Quaternion.identity);
        }

        public void OnCoinCollected(int coin)
        {
            coins += coin;
        }

        void CheckGameState()
        {
            var p = uiManager.gameObject.Request<IUI, bool?>(_ => _.OnShop());
        
            if (p == true)
            {
                Time.timeScale = 0;
            }

        }

        public void OnResume()
        {
            Time.timeScale = 1;
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    
    }
}
