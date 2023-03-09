using System;
namespace Scripts.Menu
{
    public class LoseMenu : HideableElement
    {
        public event Action OnMainMenuButtonDown;
        public event Action OnRestartButtonDown;

      
        public void MainMenuButtonDown() => OnMainMenuButtonDown?.Invoke();
        public void RestartButtonDown() => OnRestartButtonDown?.Invoke();

    
    }
}