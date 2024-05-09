using Content.Client.UserInterface;
using Content.Shared.Ame.Components;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.CustomControls;
using Robust.Client.UserInterface.XAML;

namespace Content.Client.Ame.UI
{
    [GenerateTypedNameReferences]
    public sealed partial class AmeWindow : Content.AL.UIKit.Widgets.Window
    {
        public AmeWindow(AmeControllerBoundUserInterface ui)
        {
            RobustXamlLoader.Load(this);
            IoCManager.InjectDependencies(this);

            EjectButton.OnPressed += _ => ui.ButtonPressed(UiButton.Eject);
            ToggleInjection.OnPressed += _ => ui.ButtonPressed(UiButton.ToggleInjection);
            IncreaseFuelButton.OnPressed += _ => ui.ButtonPressed(UiButton.IncreaseFuel);
            DecreaseFuelButton.OnPressed += _ => ui.ButtonPressed(UiButton.DecreaseFuel);
        }

        /// <summary>
        /// Update the UI state when new state data is received from the server.
        /// </summary>
        /// <param name="state">State data sent by the server.</param>
        public void UpdateState(BoundUserInterfaceState state)
        {
            var castState = (AmeControllerBoundUserInterfaceState) state;

            // Disable all buttons if not powered
            if (Contents.Children != null)
            {
                ButtonHelpers.SetButtonDisabledRecursive(Contents, !castState.HasPower);
                EjectButton.Disabled = false;
            }

            if (!castState.HasFuelJar)
            {
                EjectButton.Disabled = true;
                ToggleInjection.Disabled = true;
                FuelAmount.Text = Loc.GetString("ame-window-fuel-not-inserted-text");
            }
            else
            {
                EjectButton.Disabled = false;
                ToggleInjection.Disabled = false;
                FuelAmount.Text = $"{castState.FuelAmount}";
            }

            if (!castState.IsMaster)
            {
                ToggleInjection.Disabled = true;
            }

            if (!castState.Injecting)
            {
                InjectionStatus.Text = Loc.GetString("ame-window-engine-injection-status-not-injecting-label") + " ";
            }
            else
            {
                InjectionStatus.Text = Loc.GetString("ame-window-engine-injection-status-injecting-label") + " ";
            }

            CoreCount.Text = $"{castState.CoreCount}";
            InjectionAmount.Text = $"{castState.InjectionAmount}";
            // format power statistics to pretty numbers
            CurrentPowerSupply.Text = $"{castState.CurrentPowerSupply.ToString("N1")}";
            TargetedPowerSupply.Text = $"{castState.TargetedPowerSupply.ToString("N1")}";
        }
    }
}
