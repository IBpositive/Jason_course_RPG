using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace a_player
{
    public class moving_into_an_item
    {
        private Player player;
        private Item item;

        // this code runs first when testing
        // think of it as more OOP type work
        // Jason included the player move in this, but since I had to reorder it to get my test to work
        // I'm not sure if i'll break it moving it here.
        [UnitySetUp]
        public IEnumerator init()
        {
            yield return Helpers.LoadItemTestScene();
            player = Helpers.GetPlayer();
            player.PlayerInput.Vertical.Returns(1f);

            item = Object.FindObjectOfType<Item>();
        }

        [UnityTest]
        public IEnumerator picks_up_and_equips_item()
        {
            Assert.AreNotSame(item, player.GetComponent<Inventory>().ActiveItem);
            
            //player.PlayerInput.Vertical.Returns(1f);

            yield return new WaitForSeconds(3f);

            Assert.AreSame(item, player.GetComponent<Inventory>().ActiveItem);
        }

        [UnityTest]
        public IEnumerator changes_crosshair_to_item_crosshair()
        {
            var crosshair = Object.FindObjectOfType<Crosshair>();

            Assert.AreNotSame(item.CrosshairDefinition.Sprite, crosshair.GetComponent<Image>().sprite);

            item.transform.position = player.transform.position;

            yield return new WaitForFixedUpdate();

            Assert.AreEqual(item.CrosshairDefinition.Sprite, crosshair.GetComponent<Image>().sprite);
        }

        [UnityTest]
        public IEnumerator changes_slot_1_icon_to_match_item_icon()
        {
            var hotbar = Object.FindObjectOfType<Hotbar>();
            var slotOne = hotbar.GetComponentInChildren<Slot>();

            Assert.AreNotSame(item.Icon, slotOne.IconImage.sprite);

            item.transform.position = player.transform.position;

            yield return new WaitForFixedUpdate();

            Assert.AreEqual(item.Icon, slotOne.IconImage.sprite);
        }
    }
}