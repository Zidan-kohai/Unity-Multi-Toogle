using System;
using UnityEngine;
using UnityEngine.UI;

public class CustomToggle : MonoBehaviour
{
    [SerializeField] private CustomToggleGroup customToggleGroup;
    [SerializeField] private Button button;
    [SerializeField] private RectTransform checkBox;
    public bool IsActive { get; private set; }

    private void Start()
    {
        button.onClick.AddListener(OnClick);

        if (customToggleGroup != null)
            customToggleGroup.OnSetItemStateEvent += SetState;
    }

    public void SetState(CustomToggle toogle, bool state)
    {
        if(toogle == this)
        {
            IsActive = state;
            checkBox.gameObject.SetActive(IsActive);
        }
        else
        {
            if(!customToggleGroup.MultiChoose)
            {
                IsActive = false;
                checkBox.gameObject.SetActive(IsActive);
            }
        }
    }

    private void OnClick()
    {
        if (customToggleGroup != null)
        {
            customToggleGroup.OnSetItemStateEvent?.Invoke(this, !IsActive);
        }
        else
        {
            SetState(this, !IsActive);
        }
    }


}
