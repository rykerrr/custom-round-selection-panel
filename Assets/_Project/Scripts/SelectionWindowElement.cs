using System;
using UnityEngine;
using UnityEngine.UI;

namespace SelectionWindow
{
    public class SelectionWindowElement : MonoBehaviour
    {
        [SerializeField] private bool tracking = false;

        [SerializeField] private new string name = default;
        [SerializeField] private string description = default;
        [SerializeField] private Image iconImage = default;

        public bool Tracking => tracking;
        public string Name => name;
        public string Description => description;
        public Image IconImage => iconImage;

        public float TempAngle { get; set; }

        private void Awake()
        {
            if (ReferenceEquals(iconImage, null))
            {
                iconImage = GetComponentInChildren<Image>();
            }

            name = gameObject.name = $"{transform.GetSiblingIndex()}";
        }
    }
}