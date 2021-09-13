using System;
using UnityEngine;

namespace SelectionWindow
{
    public class SelectWindowElementOnClick : MonoBehaviour
    {
        [SerializeField] private SelectionWindowHandler handler = default;
        
        private int ind = 0;

        private void Awake()
        {
            ind = transform.GetSiblingIndex();
            
            Debug.Log(ind);
        }

        public void OnClick_SelectThisInSelectionWindow()
        {
            handler.SelectElement(ind);
        }
    }
}
