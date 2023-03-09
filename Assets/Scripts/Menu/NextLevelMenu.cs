using System;
using UnityEngine;

namespace Scripts.Menu
{
    public class NextLevelMenu : HideableElement
    {
        public event Action OnNextLevelButtonDown; 
        

        public void NextLevelButtonDown()
        {
            OnNextLevelButtonDown?.Invoke();
        }

 
    }
}