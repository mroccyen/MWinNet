using MWinNet.Dock;
using System;

namespace MWinNet.Frame
{
    public class ApplicationCore
    {
        private static ApplicationCore _app = new ApplicationCore();
        public static ApplicationCore ActiveApplication
        {
            get
            {
                return _app;
            }
        }

        public delegate void ActiveMidWindowChangeHandler(object sender, EventArgs e);
        public event ActiveMidWindowChangeHandler ActiveMidWindowChanged;
        public delegate void ActiveWindowChangeHandler(object sender, EventArgs e);
        public event ActiveWindowChangeHandler ActiveWindowChanged;

        internal ApplicationCore()
        {
            DockPanelSingleton.MainDockPanel.ActiveDocumentChanged += Instance_ActiveDocumentChanged;
            DockPanelSingleton.MainDockPanel.ActiveContentChanged += Instance_ActiveContentChanged;
        }

        private void Instance_ActiveContentChanged(object sender, EventArgs e)
        {
            if (ActiveWindowChanged != null)
            {
                ActiveWindowChanged(sender, e);
            }
        }

        private void Instance_ActiveDocumentChanged(object sender, EventArgs e)
        {
            if (ActiveMidWindowChanged != null)
            {
                ActiveMidWindowChanged(sender, e);
            }
        }

        public ToolWindow ActiveMidWindow
        {
            get
            {
                return (ToolWindow)DockPanelSingleton.MainDockPanel.ActiveDocument;
            }
        }

        public ToolWindow ActiveWindow
        {
            get
            {
                return (ToolWindow)DockPanelSingleton.MainDockPanel.ActiveContent;
            }
        }


    }
}
