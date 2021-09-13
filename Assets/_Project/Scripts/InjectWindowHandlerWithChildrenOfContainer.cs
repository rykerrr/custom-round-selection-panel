using System.Collections.Generic;
using UnityEngine;

namespace SelectionWindow
{
    public class InjectWindowHandlerWithChildrenOfContainer : MonoBehaviour
    {
        [SerializeField] private SelectionWindowHandler handler = default;
        [SerializeField] private Transform elementContainer = default;

        private void Start()
        {
            if (ReferenceEquals(handler, null)) handler = GetComponent<SelectionWindowHandler>();
            if (ReferenceEquals(handler, null)) return;

            LoadChildrenToContainer();
        }

        private void LoadChildrenToContainer()
        {
            var elements = new List<SelectionWindowElement>();

            foreach (Transform child in elementContainer.transform)
            {
                SelectionWindowElement element = default;

                var notWindowElem = ReferenceEquals(
                    element = child.GetComponent<SelectionWindowElement>(), null);
                if (notWindowElem) continue;
                
                elements.Add(element);
            }
            
            handler.Init(elements);
        }
    }
}
