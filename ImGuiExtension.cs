using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExileCore;
using ExileCore.Shared.Nodes;
using ImGuiNET;
using SharpDX;
using ImGuiVector2 = System.Numerics.Vector2;
using ImGuiVector4 = System.Numerics.Vector4;

namespace Random_Features.Libs;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public class ImGuiExtension
{
    // Int Sliders
    public static int IntSlider(string labelString, int value, int minValue, int maxValue)
    {
        var refValue = value;
        ImGui.SliderInt(labelString, ref refValue, minValue, maxValue);
        return refValue;
    }

    public static int IntSlider(string labelString, string sliderString, int value, int minValue, int maxValue)
    {
        var refValue = value;
        ImGui.SliderInt(labelString, ref refValue, minValue, maxValue);
        return refValue;
    }

    public static int IntSlider(string labelString, RangeNode<int> setting)
    {
        var refValue = setting.Value;
        ImGui.SliderInt(labelString, ref refValue, setting.Min, setting.Max);
        return refValue;
    }

    public static int IntSlider(string labelString, string sliderString, RangeNode<int> setting)
    {
        var refValue = setting.Value;
        ImGui.SliderInt(labelString, ref refValue, setting.Min, setting.Max);
        return refValue;
    }
    
    public static Keys HotkeySelector(string buttonName, Keys currentKey)
    {
        var open = true;
        if (ImGui.Button(buttonName))
        {
            ImGui.OpenPopup(buttonName);
            open = true;
        }

        if (ImGui.BeginPopupModal(buttonName, ref open, (ImGuiWindowFlags)35))
        {
            if (Input.GetKeyState(Keys.Escape))
            {
                ImGui.CloseCurrentPopup();
                ImGui.EndPopup();
            }
            else
            {
                foreach (var key in Enum.GetValues(typeof(Keys)))
                {
                    var keyState = Input.GetKeyState((Keys)key);
                    if (keyState)
                    {
                        currentKey = (Keys)key;
                        ImGui.CloseCurrentPopup();
                        break;
                    }
                }
            }

            ImGui.Text($" Press new key to change '{currentKey}' or Esc for exit.");

            ImGui.EndPopup();
        }

        return currentKey;
    }
}