using System;
using UnityEngine;

public class CustomToggleGroup : MonoBehaviour
{
    public Action<CustomToggle, bool> OnSetItemStateEvent;

    [field: SerializeField] public bool MultiChoose { get; private set; } = false;
}