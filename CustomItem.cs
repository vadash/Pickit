using System;
using System.Diagnostics.CodeAnalysis;
using ExileCore.PoEMemory.Components;
using ExileCore.PoEMemory.Elements;
using ExileCore.PoEMemory.MemoryObjects;
// ReSharper disable ConstantConditionalAccessQualifier

namespace PickIt;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public class CustomItem
{
    public readonly Func<bool> IsTargeted;
    public readonly bool IsValid;

    public CustomItem(LabelOnGround item, float distance)
    {
        LabelOnGround = item;
        Distance = distance;
        var itemItemOnGround = item.ItemOnGround;
        var worldItem = itemItemOnGround?.GetComponent<WorldItem>();
        if (worldItem == null) return;
        var groundItem = worldItem.ItemEntity;
        GroundItem = groundItem;
        if (GroundItem == null) return;
        IsTargeted = () => itemItemOnGround?.GetComponent<Targetable>()?.isTargeted == true;
        IsValid = true;
    }

    public LabelOnGround LabelOnGround { get; }
    public float Distance { get; }
    public Entity GroundItem { get; }
}