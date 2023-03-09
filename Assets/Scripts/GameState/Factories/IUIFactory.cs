using Scripts.GameState.Services;
using Scripts.Menu;

namespace Scripts.GameState.Factories
{
    public interface IUIFactory : IService
    {
        public MainMenu MainMenu { get;}
        public NextLevelMenu NextLevelMenu { get; }
        public LoseMenu LoseMenu { get; }

        public LoseMenu WinMenu { get; }

        public ScoreUI ScoreUI { get; }
        public ResultView ResultView { get; }

        public ComboView ComboView { get; }
        public MainMenu CreateMainMenu();

        public NextLevelMenu CreateNextLevelMenu();

        public LoseMenu CreateLoseMenu();
        void Clearup();

        public ScoreUI CreateScoreUI();
        public ResultView CreateResultView();

        public LoseMenu CreateWinMenu();
        public ComboView CreateComboView();
    }
}