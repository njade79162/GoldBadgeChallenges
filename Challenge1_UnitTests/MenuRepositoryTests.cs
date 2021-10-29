using Challenge1_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge1_UnitTests
{
    [TestClass]
    public class MenuRepositoryTests
    {
        [TestMethod]
        public void Test_AddMenuItem()
        {
            MenuRepository menuRepo = new MenuRepository();
            Menu item = new Menu();

            bool added = menuRepo.AddMenuItem(item);

            Assert.IsTrue(added);
        }

        [TestMethod]
        public void Test_GetItemByName()
        {
            MenuRepository menuRepo = new MenuRepository();
            List<string> ingredients = new List<string>();
            ingredients.Add("Bun");
            ingredients.Add("Patty");
            ingredients.Add("Ketchup");
            ingredients.Add("Mustard");
            ingredients.Add("Pickle");
            Menu expected = new Menu(1, "Hamburger", "A Hamburger", ingredients, 3.17);
            menuRepo.AddMenuItem(expected);

            Menu actual = menuRepo.GetItemByName("Hamburger");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_DeleteItem()
        {
            MenuRepository menuRepo = new MenuRepository();
            List<string> ingredients = new List<string>();
            ingredients.Add("Bun");
            ingredients.Add("Patty");
            ingredients.Add("Ketchup");
            ingredients.Add("Mustard");
            ingredients.Add("Pickle");
            Menu item = new Menu(1, "Hamburger", "A Hamburger", ingredients, 3.17);
            menuRepo.AddMenuItem(item);

            bool removed = menuRepo.DeleteItem(item);

            Assert.IsTrue(removed);
        }
    }
}
