﻿using GorillaShirts.Behaviours;
using GorillaShirts.Interaction;
using GorillaShirts.Interfaces;
using GorillaShirts.Models;
using System;

namespace GorillaShirts.Buttons
{
    internal class PackDecrease : IStandButton
    {
        public Interaction.ButtonType Type => Interaction.ButtonType.PackDecrease;
        public Action<ShirtConstructor> Function => (ShirtConstructor constructor) =>
        {
            constructor.SelectedPackIndex = constructor.SelectedPackIndex == 0 ? constructor.ConstructedPacks.Count - 1 : constructor.SelectedPackIndex - 1;

            Pack selectedPack = constructor.SelectedPack;

            constructor.SetPackInfo(selectedPack, selectedPack.PackagedShirts[selectedPack.CurrentItem]);

            Shirt selectedShirt = constructor.SelectedShirt;
            PhysicalRig localRig = constructor.LocalRig;
            Stand shirtStand = constructor.Stand;

            shirtStand.Rig.Wear(selectedShirt);
            shirtStand.Display.UpdateDisplay(selectedShirt, localRig.Rig.CurrentShirt, selectedPack);
        };
    }
}
