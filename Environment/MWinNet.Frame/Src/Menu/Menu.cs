using MWinNet.Core;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MWinNet.Frame
{
    public class Menu : MenuStrip, IStatusUpdate
    {
        public static Menu _singleton = null;
        public static Menu Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new Menu();
                }
                return _singleton;
            }
        }

        public Menu _mainMenu = null;
        public Menu MainMenu
        {
            get
            {
                if (_mainMenu == null)
                {
                    _mainMenu = CreateMenu();
                }
                return _mainMenu;
            }
        }

        private Menu CreateMenu()
        {
            Menu mainMenu = new Menu();
            mainMenu.SuspendLayout();
            mainMenu.ImageScalingSize = new Size(24, 24);
            mainMenu.Location = new Point(0, 0);
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new Size(1082, 32);
            mainMenu.TabIndex = 0;
            mainMenu.Text = "MainMenu";
            mainMenu.ResumeLayout(false);
            mainMenu.PerformLayout();

            return mainMenu;
        }

        public void AddItemRange(ToolStripItem[] range)
        {
            Array.ForEach(range, item =>
            {
                MainMenu.Items.Add(item);
            });
        }

        public void UpdateStatus()
        {

        }

        public void UpdateText()
        {

        }
    }
}
