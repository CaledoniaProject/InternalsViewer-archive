﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using InternalsViewer.Internals;

namespace InternalsViewer.UI.Renderers
{
    internal class PfsRenderer : IDisposable
    {
        private static readonly Color allocatedColour = Color.Silver;
        private static readonly Color ghostColour = Color.Salmon;
        private static readonly Color iamColour = Color.SlateBlue;
        private static readonly Color mixedColor = Color.FromArgb(168, 204, 162);
        private static readonly Color spaceColour = Color.LightGreen;

        private readonly Color backColour;
        private readonly Color borderColour = Color.DarkGray;
        private Pen borderPen;
        private bool displayAllocationText;
        private Pen pageBorderPen;
        private Rectangle pageRectangle;
        private LinearGradientBrush pfsAllocatedBrush;
        private Font pfsFont;
        private Brush pfsGhostBrush;
        private Brush pfsIamBrush;
        private Brush pfsMixedBrush;
        private LinearGradientBrush pfsSpaceBrush;

        public PfsRenderer(Rectangle pageRectangle, Color backgroundColour)
        {
            this.pageRectangle = pageRectangle;
            backColour = backgroundColour;
            CreateBrushesAndPens();
        }

        public PfsRenderer(Rectangle pageRectangle, Color backgroundColour, Color borderColour)
        {
            this.pageRectangle = pageRectangle;
            backColour = backgroundColour;
            this.borderColour = borderColour;
            CreateBrushesAndPens();
        }

        public void CreateBrushesAndPens()
        {
            pfsIamBrush = new SolidBrush(iamColour);
            pfsGhostBrush = new SolidBrush(ghostColour);
            pfsMixedBrush = new SolidBrush(mixedColor);

            pfsAllocatedBrush = new LinearGradientBrush(pageRectangle,
                                                        allocatedColour,
                                                        backColour,
                                                        LinearGradientMode.ForwardDiagonal);
            pfsAllocatedBrush.WrapMode = WrapMode.TileFlipX;

            pfsSpaceBrush = new LinearGradientBrush(pageRectangle,
                                                    ExtentColour.LightBackgroundColour(spaceColour),
                                                    spaceColour,
                                                    LinearGradientMode.Vertical);

            pageBorderPen = new Pen(borderColour);
            borderPen = new Pen(Color.Gainsboro);

            pfsFont = new Font("Sans Serif", 6, FontStyle.Regular);

            displayAllocationText = (TextRenderer.MeasureText("%", pfsFont).Height < pageRectangle.Height);
        }

        public void DrawPfsPage(Graphics g, Rectangle rect, PfsByte pfsByte)
        {
            string spaceFree = string.Empty;
            int spaceUsedWidth = 0;

            int indLen = (rect.Height / 3);

            Rectangle pfsRect = new Rectangle(rect.X, rect.Y, rect.Width, indLen);
            Rectangle iamRect = new Rectangle(rect.X + 1, rect.Y + pfsRect.Height, indLen, indLen);
            Rectangle mixedRect = new Rectangle(rect.X + 1 + iamRect.Width, rect.Y + pfsRect.Height, indLen, indLen);
            Rectangle ghostRect = new Rectangle(rect.X + 1 + iamRect.Width * 2, rect.Y + pfsRect.Height, indLen, indLen);
            Rectangle spaceRect = new Rectangle(rect.X, mixedRect.Y + mixedRect.Height + 1, rect.Width, indLen + 1);

            if (pfsByte.Allocated)
            {
                g.FillRectangle(pfsAllocatedBrush, pfsRect);
            }
            if (pfsByte.Iam)
            {
                g.FillRectangle(pfsIamBrush, iamRect);
            }

            if (pfsByte.Mixed)
            {
                g.FillRectangle(pfsMixedBrush, mixedRect);
            }

            if (pfsByte.GhostRecords)
            {
                g.FillRectangle(pfsGhostBrush, ghostRect);
            }

            switch (pfsByte.PageSpaceFree)
            {
                case PfsByte.SpaceFree.Empty:

                    spaceFree = "0%";
                    spaceUsedWidth = 0;
                    break;

                case PfsByte.SpaceFree.FiftyPercent:

                    spaceFree = "50%";
                    spaceUsedWidth = (int)(rect.Width * 0.5);
                    break;

                case PfsByte.SpaceFree.EightyPercent:

                    spaceFree = "80%";
                    spaceUsedWidth = (int)(rect.Width * 0.8);
                    break;

                case PfsByte.SpaceFree.NinetyFivePercent:

                    spaceFree = "95%";
                    spaceUsedWidth = (int)(rect.Width * 0.95);
                    break;

                case PfsByte.SpaceFree.OneHundredPercent:

                    spaceFree = "100%";
                    spaceUsedWidth = rect.Width;
                    break;
            }

            g.FillRectangle(pfsSpaceBrush, new Rectangle(spaceRect.X, spaceRect.Y, spaceUsedWidth, spaceRect.Height));

            if (displayAllocationText)
            {
                TextRenderer.DrawText(g,
                                      spaceFree,
                                      pfsFont,
                                      spaceRect,
                                      Color.Black,
                                      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }

            g.DrawRectangle(borderPen, iamRect);
            g.DrawRectangle(borderPen, mixedRect);
            g.DrawRectangle(borderPen, ghostRect);
            g.DrawRectangle(pageBorderPen, rect);
        }

        public Bitmap PfsBitmap(PfsByte pfsByte)
        {
            Bitmap pfsBitmap = new Bitmap(36, 36);
            pfsBitmap.SetResolution(100, 100);
            Graphics g = Graphics.FromImage(pfsBitmap);

            DrawPfsPage(g, pageRectangle, pfsByte);

            return pfsBitmap;
        }

        internal static Bitmap KeyImage(Color color)
        {
            Bitmap key = new Bitmap(16, 16);
            Rectangle keyRectange = new Rectangle(0, 0, key.Width - 1, key.Height - 1);
            Graphics g = Graphics.FromImage(key);

            LinearGradientBrush brush = new LinearGradientBrush(keyRectange,
                                                                color,
                                                                ExtentColour.BackgroundColour(color),
                                                                LinearGradientMode.Horizontal);

            g.FillRectangle(brush, keyRectange);
            g.DrawRectangle(SystemPens.ControlDark, keyRectange);

            return key;
        }

        internal void ResizePage(int width, int height)
        {
            float sx = pfsAllocatedBrush.Rectangle.Height / height;
            float sy = pfsAllocatedBrush.Rectangle.Width / width;

            pfsAllocatedBrush.ResetTransform();
            pfsAllocatedBrush.ScaleTransform(sx, sy);

            pfsSpaceBrush.ResetTransform();
            pfsSpaceBrush.ScaleTransform(sx, sy);

            displayAllocationText = (TextRenderer.MeasureText("%", pfsFont).Height < height / 2);
        }

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            pfsIamBrush.Dispose();
            pfsMixedBrush.Dispose();
            pfsGhostBrush.Dispose();
            pfsAllocatedBrush.Dispose();
            pfsSpaceBrush.Dispose();
            borderPen.Dispose();
            pageBorderPen.Dispose();
        }

        #endregion
    }
}
