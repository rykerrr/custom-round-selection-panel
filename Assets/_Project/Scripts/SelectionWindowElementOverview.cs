using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SelectionWindow
{
    public class SelectionWindowElementOverview : MonoBehaviour
    {
        [SerializeField] private Image iconDisplayImage = default;
        [SerializeField] private TextMeshProUGUI nameText = default;
        [SerializeField] private TextMeshProUGUI descText = default;
        
        public void SelectElement(SelectionWindowElement elem)
        {
            var img = elem.IconImage;

            nameText.text = elem.Name;
            descText.text = elem.Description;
            
            iconDisplayImage.sprite = img.sprite;
            iconDisplayImage.color = img.color;
            
            iconDisplayImage.type = img.type;
            iconDisplayImage.fillCenter = img.fillCenter;
        }
    }
}