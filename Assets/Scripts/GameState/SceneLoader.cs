using System;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Scripts.GameState
{
    public class SceneLoader
    {
        private readonly Game _game;

        public SceneLoader(Game game)
        {
            _game = game;
        }

        public void LoadScene(string sceneName,Action callBack = null)
        {
            _game.StartCoroutine(LoadSceneRotuine(sceneName, callBack));
        }

        private IEnumerator LoadSceneRotuine(string sceneName, Action callBack = null)
        {
            if(sceneName == SceneManager.GetActiveScene().name)
            {
                yield break;
            }

            var operation = SceneManager.LoadSceneAsync(sceneName);
            while(operation.isDone == false)
            {
                yield return null;
            }

            callBack?.Invoke();
        }
    }
}