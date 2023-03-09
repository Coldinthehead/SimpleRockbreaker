using Scripts.Data;
using Scripts.GameState.Services;
using Scripts.GameState.States;
using UnityEngine;

namespace Scripts.GameState
{

    [DefaultExecutionOrder(-50)]
    public class Game : MonoBehaviour
    {
        private static Game _instance;
        public static Game GetInstance => _instance;
        public GameStateMachine GameStateMachine;

        [SerializeField] private StageTemplate _stageTemplate;
        private ServiceLocator _allServices;
        private SceneLoader _sceneLoader;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void Start()
        {
            _allServices = ServiceLocator.Container;
            _sceneLoader = new SceneLoader(this);
            GameStateMachine = new GameStateMachine(_allServices, _sceneLoader, _stageTemplate);
            GameStateMachine.Enter<BootstrapState>();
        }
    }
}