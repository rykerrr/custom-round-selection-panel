using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

namespace SelectionWindow
{
    public class SelectionWindowHandler : MonoBehaviour
    {
        [SerializeField] private RectTransform center = default;
        [SerializeField] private float radius = default;
        [SerializeField] private int scrollCtxDivVal = 120;
        [SerializeField] private SelectionWindowElementOverview selWindow = default;

        [SerializeField] private float tweenDur = 1f;
        
        [SerializeField] private List<SelectionWindowElement> elements = default;

        private float angle = 0f;
        private int curInd = 0;

        private void Awake()
        {
            DOTween.Init(null, true, LogBehaviour.Verbose);
            DOTween.defaultAutoPlay = AutoPlay.AutoPlayTweeners;
            
            if (elements == null || elements.Count == 0) return;
            
            SetElementsCircularlyAroundCenter();
        }

        private void Update()
        {
            if (Keyboard.current.qKey.wasPressedThisFrame)
            {
                SelectElement(curInd - 1);
            }

            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                SelectElement(curInd + 1);
            }
        }

        private void SetElementsCircularlyAroundCenter()
        {
            angle = 360f / elements.Count;
            
            for (int i = 0; i < elements.Count; i++)
            {
                var elemRectTransf = (RectTransform) elements[i].transform;
                var elemAngle = angle * i;

                var x = Mathf.Cos(elemAngle * Mathf.Deg2Rad);
                var y = Mathf.Sin(elemAngle * Mathf.Deg2Rad);

                var posAdd = new Vector2(x, y) * radius;

                elemRectTransf.anchoredPosition = center.anchoredPosition + posAdd;

                elements[i].TempAngle = elemAngle;
            }
        }

        private void ScrollBy(int indiceScrollAmn)
        {
            foreach (var elem in elements)
            {
                var elemRectTransf = (RectTransform) elem.transform;

                var elemAngle = elem.TempAngle + angle * indiceScrollAmn;
                if(elem.Tracking) Debug.Log(elemAngle + " | " + angle + " | " + angle * indiceScrollAmn + " | " + elem.TempAngle);
                
                var x = Mathf.Cos(elemAngle * Mathf.Deg2Rad);
                var y = Mathf.Sin(elemAngle * Mathf.Deg2Rad);
                
                var posAdd = new Vector2(x, y) * radius;

                if(elem.Tracking) Debug.Log(x + " | " + y + " | " + posAdd);

                elemRectTransf.DOAnchorPos(center.anchoredPosition + posAdd, tweenDur, true);
                // elemRectTransf.anchoredPosition = center.anchoredPosition + posAdd;

                elem.TempAngle = elemAngle;
            }
        }
        
        public void OnMouseScroll_ProcessScroll(InputAction.CallbackContext ctx)
        {
            if (ctx.canceled) return;
            
            var scrollValRaw = ctx.ReadValue<Vector2>().y;
            var scrollValNormalized = Mathf.RoundToInt(scrollValRaw / scrollCtxDivVal);
            
            var newInd = curInd + scrollValNormalized * -1;
            
            SelectElement(newInd);
        }

        public void SelectElement(int newInd)
        {
            while (newInd < 0)
            {
                newInd += elements.Count;
            }
            
            if (newInd >= elements.Count) newInd %= elements.Count;

            ScrollBy(curInd - newInd); 
            
            curInd = newInd;

            selWindow.SelectElement(elements[curInd]);
        }

        public void Init(List<SelectionWindowElement> elements)
        {
            this.elements = elements;

            SetElementsCircularlyAroundCenter();
            SelectElement(0);
        }
    }
}
