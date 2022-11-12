using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameGrid
{
    public class GridSlot : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private Action<GridSlot> onSlotClicked;

        private void Awake()
        {
            _button.onClick.AddListener(() => onSlotClicked.Invoke(this));
        }

        internal void Initialize(Action<GridSlot> onSlotClicked)
        {
            this.onSlotClicked = onSlotClicked;
        }
    }
}
