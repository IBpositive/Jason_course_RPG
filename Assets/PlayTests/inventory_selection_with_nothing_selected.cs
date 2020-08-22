﻿using NSubstitute.Core;
using NUnit.Framework;

namespace PlayTests
{
    public class inventory_selection_with_nothing_selected
    {
        [Test]
        public void clicking_non_empty_slot_selects_slot()
        {
            var inventoryPanel = inventor_panel.GetInventoryPanel();
            var slot = inventoryPanel.Slots[0];

            slot.OnPointerClick(null);
            Assert.AreSame(slot,inventoryPanel.Selected);
        }
    }
    
    public class inventory_selection_with_non_empty_slot_selected
    {
        [Test]
        public void clicking_slot_moves_selected_item_to_clicked_slot()
        {
            var inventoryPanel = inventory_helpers.GetInventoryPanelWithItems(2);
            var slot0 = inventoryPanel.Slots[0];
            var slot1 = inventoryPanel.Slots[1];
            var item0 = slot0.Item;
            var item1 = slot1.Item;
            
            Assert.IsNotNull(item0);
            Assert.IsNotNull(item1);
            
            slot0.OnPointerClick(null);
            slot1.OnPointerClick(null);

            Assert.AreSame(item0,slot1.Item);
            Assert.AreSame(item1,slot0.Item);
        }
    }
}