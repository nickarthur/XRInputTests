﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class StickUsageProxy : MonoBehaviour
{
    public XRNode node;
    public string usageName;

    public Text textComponent;
    public Slider horizontalSliderComponent;
    public Slider verticalSliderComponent;
    public Text valueTextComponent;

    private void Start()
    {
        if (textComponent != null)
        {
            textComponent.text = usageName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 value;

        if (!InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(new InputUsage<Vector2>(usageName), out value))
            return;

        if (horizontalSliderComponent != null)
            horizontalSliderComponent.value = value.x;

        if (verticalSliderComponent != null)
            verticalSliderComponent.value = value.y;

        if (valueTextComponent != null)
            valueTextComponent.text = string.Format("[{0},{1}]", value.x.ToString("F"), value.y.ToString("F"));
    }
}
