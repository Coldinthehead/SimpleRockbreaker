using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Menu
{
    public class MainMenu : MonoBehaviour
    {
        public event Action OnNewGameButtonDown;

        public void CallNewGameButtonDown()
        {
            OnNewGameButtonDown?.Invoke();
        }
    }
}