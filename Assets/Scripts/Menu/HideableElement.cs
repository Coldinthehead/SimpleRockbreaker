using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Menu
{
    public class HideableElement : MonoBehaviour
    {
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}