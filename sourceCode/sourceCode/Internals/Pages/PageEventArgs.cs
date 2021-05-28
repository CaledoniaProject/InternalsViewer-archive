﻿using System;

namespace InternalsViewer.Internals.Pages
{
    /// <summary>
    /// Event data for page related events
    /// </summary>
    public class PageEventArgs : EventArgs
    {
        private bool openInNewWindow;
        private RowIdentifier rowId;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageEventArgs"/> class.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="openInNewWindow">if set to <c>true</c> [open in new window].</param>
        public PageEventArgs(RowIdentifier address, bool openInNewWindow)
        {
            this.RowId = address;
            this.OpenInNewWindow = openInNewWindow;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the event triggers a new window to be opened
        /// </summary>
        /// <value><c>true</c> if [open in new window]; otherwise, <c>false</c>.</value>
        public bool OpenInNewWindow
        {
            get { return this.openInNewWindow; }
            set { this.openInNewWindow = value; }
        }

        /// <summary>
        /// Gets or sets the row id.
        /// </summary>
        /// <value>The row id.</value>
        public RowIdentifier RowId
        {
            get { return this.rowId; }
            set { this.rowId = value; }
        }

        /// <summary>
        /// Gets or sets the page address.
        /// </summary>
        /// <value>The address.</value>
        public PageAddress Address
        {
            get { return this.rowId.PageAddress; }
            set { this.rowId.PageAddress = value; }
        }
    }
}
