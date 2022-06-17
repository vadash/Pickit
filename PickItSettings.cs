using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using ExileCore.Shared.Interfaces;
using ExileCore.Shared.Nodes;

namespace PickIt;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public class PickItSettings : ISettings
{
    public HotkeyNode PickUpKey { get; set; } = Keys.F;
    public RangeNode<int> PickupRange { get; set; } = new(600, 1, 1000);
    public RangeNode<int> ExtraDelay { get; set; } = new(0, 0, 200);
    public RangeNode<int> TimeBeforeNewClick { get; set; } = new(500, 0, 1500);
    public ToggleNode Enable { get; set; } = new(false);
}