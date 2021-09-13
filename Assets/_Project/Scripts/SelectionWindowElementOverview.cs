using UnityEngine;
using UnityEngine.UI;

namespace SelectionWindow
{
    public class SelectionWindowElementOverview : MonoBehaviour
    {
        [SerializeField] private Image iconDisplayImage = default;
        
        public void SelectElement(SelectionWindowElement elem)
        {
            var img = elem.IconImage;
            
            iconDisplayImage.sprite = img.sprite;
            iconDisplayImage.color = img.color;
            iconDisplayImage.type = iconDisplayImage.type;
        }
    }
}