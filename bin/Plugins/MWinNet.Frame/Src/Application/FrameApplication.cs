using MWinNet.Dock;
using System;

namespace MWinNet.Frame
{
    public class FrameApplication
    {
        private static FrameApplication _app = new FrameApplication();
        public static FrameApplication ActiveApplication
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

        internal FrameApplication()
        {
            DockPanelInstance.Instance.ActiveDocumentChanged += Instance_ActiveDocumentChanged;
            DockPanelInstance.Instance.ActiveContentChanged += Instance_ActiveContentChanged;
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
                return (ToolWindow)DockPanelInstance.Instance.ActiveDocument;
            }
        }

        public ToolWindow ActiveWindow
        {
            get
            {
                return (ToolWindow)DockPanelInstance.Instance.ActiveContent;
            }
        }


    }
}
