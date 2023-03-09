using Scripts.GameState.Services;
using Scripts.Menu;
using UnityEngine;

namespace Scripts.GameState.Factories
{
    public class UiFactory : IUIFactory
    {
        public MainMenu MainMenu { get; private set; }
        public NextLevelMenu NextLevelMenu { get; private set; }
        public LoseMenu LoseMenu { get; private set; }
        public ScoreUI ScoreUI { get; private set; }
        public ResultView ResultView { get; private set; }
        public LoseMenu WinMenu { get; private set; }
        public ComboView ComboView { get; private set; }

        private readonly IPlayerService _playerService;

        public UiFactory(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public MainMenu CreateMainMenu()
        {
            string path = "UI/MainMenuCanvas";
            GameObject prefab = Load(path);

            MainMenu = Object.Instantiate(prefab).GetComponent<MainMenu>();
            return MainMenu;
        }

        public NextLevelMenu CreateNextLevelMenu()
        {
            string path = "UI/NextLevelCanvas";
            GameObject prefab = Load(path);

            NextLevelMenu = Object.Instantiate(prefab).GetComponent<NextLevelMenu>();
            NextLevelMenu.Hide();
            return NextLevelMenu;
        }

        public LoseMenu CreateLoseMenu()
        {
            string path = "UI/LoseMenuCanvas";
            GameObject prefab = Load(path);

            LoseMenu = Object.Instantiate(prefab).GetComponent<LoseMenu>();
            LoseMenu.Hide();
            return LoseMenu;
        }
        public ScoreUI CreateScoreUI()
        {
            string path = "UI/ScoreUI";
            GameObject prefab = Load(path);

            ScoreUI = Object.Instantiate(prefab).GetComponent<ScoreUI>();
            ScoreUI.Construct(_playerService);
            ScoreUI.Hide();


            return ScoreUI;
        }

        public ResultView CreateResultView()
        {
            string path = "UI/ResultView";
            GameObject prefab = Load(path);

            ResultView = Object.Instantiate(prefab).GetComponent<ResultView>();
            ResultView.Construct(_playerService);
            ResultView.Hide();

            return ResultView;
        }

        public LoseMenu CreateWinMenu()
        {
            string path = "UI/WinMenu";
            GameObject prefab = Load(path);

            WinMenu = Object.Instantiate(prefab).GetComponent<LoseMenu>();
            WinMenu.Hide();

            return WinMenu;
        }
        public ComboView CreateComboView()
        {
            string path = "UI/ComboView";
            GameObject prefab = Load(path);

            ComboView = Object.Instantiate(prefab).GetComponent<ComboView>();
            ComboView.Construct(_playerService);
            ComboView.Hide();

            return ComboView;
        }

        private static GameObject Load(string path)
        {
            return Resources.Load(path) as GameObject;
        }

        public void Clearup()
        {
            MainMenu = null;
            NextLevelMenu = null;
            LoseMenu = null;
            ScoreUI = null;
            ResultView = null;
            WinMenu = null;
            ComboView = null;
        }
    }
}