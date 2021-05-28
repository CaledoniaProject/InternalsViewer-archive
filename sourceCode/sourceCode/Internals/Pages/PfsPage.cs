﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InternalsViewer.Internals.Pages
{
    /// <summary>
    /// PFS (Page Free Space) page
    /// </summary>
    public class PfsPage : Page
    {
        private const int PfsOffset = 100;
        private const int PfsSize = 8088;
        private List<PfsByte> pfsBytes;

        /// <summary>
        /// Initializes a new instance of the <see cref="PfsPage"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="address">The address.</param>
        public PfsPage(Database database, PageAddress address)
            : base(database, address)
        {
            LoadPage();
        }

        private void LoadPage()
        {
            if (Header.PageType != PageType.Pfs)
            {
                throw new InvalidOperationException("Page type is not PFS");
            }

            this.pfsBytes = new List<PfsByte>();

            this.LoadPfsBytes();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PfsPage"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="database">The database.</param>
        /// <param name="pageAddress">The page address.</param>
        public PfsPage(string connectionString, string database, PageAddress pageAddress)
            : base(connectionString, database, pageAddress)
        {
            LoadPage();
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i <= this.pfsBytes.Count - 1; i++)
            {
                sb.AppendFormat("{0,-14}{1}", new PageAddress(1, i), this.pfsBytes[i]);
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Gets or sets the PFS bytes collection.
        /// </summary>
        /// <value>The PFS bytes collection.</value>
        public List<PfsByte> PfsBytes
        {
            get { return this.pfsBytes; }
            set { this.pfsBytes = value; }
        }

        /// <summary>
        /// Loads the PFS bytes collection
        /// </summary>
        private void LoadPfsBytes()
        {
            byte[] pfsData = new byte[PfsSize];

            Array.Copy(this.PageData, PfsOffset, pfsData, 0, PfsSize);

            foreach (byte pfsByte in pfsData)
            {
                this.pfsBytes.Add(new PfsByte(pfsByte));
            }
        }
    }
}
