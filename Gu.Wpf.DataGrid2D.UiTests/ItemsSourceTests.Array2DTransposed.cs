﻿namespace Gu.Wpf.DataGrid2D.UiTests
{
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public partial class ItemsSourceTests
    {
        public class Array2DTransposed
        {
            [Test]
            public void AutoColumns()
            {
                using (var app = Application.Launch(Info.ExeFileName, "Array2DWindow"))
                {
                    var window = app.MainWindow;
                    window.WaitUntilResponsive();
                    var dataGrid = window.FindDataGrid("AutoColumnsTransposed");
                    Assert.AreEqual(2, dataGrid.RowCount);
                    Assert.AreEqual(3, dataGrid.ColumnCount);

                    var columnHeaders = dataGrid.ColumnHeaders;
                    Assert.AreEqual(3, columnHeaders.Count);
                    Assert.AreEqual("C0", columnHeaders[0].Text);
                    Assert.AreEqual("C1", columnHeaders[1].Text);
                    Assert.AreEqual("C2", columnHeaders[2].Text);

                    Assert.AreEqual("1", dataGrid[0, 0].Value);
                    Assert.AreEqual("3", dataGrid[0, 1].Value);
                    Assert.AreEqual("5", dataGrid[0, 2].Value);
                    Assert.AreEqual("2", dataGrid[1, 0].Value);
                    Assert.AreEqual("4", dataGrid[1, 1].Value);
                    Assert.AreEqual("6", dataGrid[1, 2].Value);
                }
            }

            [Test]
            public void ExplicitColumns()
            {
                using (var app = Application.Launch(Info.ExeFileName, "Array2DWindow"))
                {
                    var window = app.MainWindow;
                    var dataGrid = window.FindDataGrid("ExplicitColumnsTransposed");

                    Assert.AreEqual(3, dataGrid.ColumnCount);
                    var columnHeaders = dataGrid.ColumnHeaders;
                    Assert.AreEqual(3, columnHeaders.Count);
                    Assert.AreEqual("Col 1", columnHeaders[0].Text);
                    Assert.AreEqual("Col 2", columnHeaders[1].Text);
                    Assert.AreEqual("Col 3", columnHeaders[2].Text);

                    Assert.AreEqual(2, dataGrid.RowCount);
                    Assert.AreEqual("1", dataGrid[0, 0].Value);
                    Assert.AreEqual("3", dataGrid[0, 1].Value);
                    Assert.AreEqual("5", dataGrid[0, 2].Value);
                    Assert.AreEqual("2", dataGrid[1, 0].Value);
                    Assert.AreEqual("4", dataGrid[1, 1].Value);
                    Assert.AreEqual("6", dataGrid[1, 2].Value);
                }
            }

            [Test]
            public void WithHeaders()
            {
                using (var app = Application.Launch(Info.ExeFileName, "Array2DWindow"))
                {
                    var window = app.MainWindow;
                    var dataGrid = window.FindDataGrid("WithHeadersTransposed");
                    var columnHeaders = dataGrid.ColumnHeaders;
                    Assert.AreEqual(3, columnHeaders.Count);
                    Assert.AreEqual("A", columnHeaders[0].Text);
                    Assert.AreEqual("B", columnHeaders[1].Text);
                    Assert.AreEqual("C", columnHeaders[2].Text);

                    var rowHeaders = dataGrid.RowHeaders;
                    Assert.AreEqual(2, rowHeaders.Count);
                    Assert.AreEqual("1", rowHeaders[0].Text);
                    Assert.AreEqual("2", rowHeaders[1].Text);

                    Assert.AreEqual("1", dataGrid[0, 0].Value);
                    Assert.AreEqual("3", dataGrid[0, 1].Value);
                    Assert.AreEqual("5", dataGrid[0, 2].Value);
                    Assert.AreEqual("2", dataGrid[1, 0].Value);
                    Assert.AreEqual("4", dataGrid[1, 1].Value);
                    Assert.AreEqual("6", dataGrid[1, 2].Value);
                }
            }

            [Test]
            public void ViewUpdatesSource()
            {
                using (var app = Application.Launch(Info.ExeFileName, "Array2DWindow"))
                {
                    var window = app.MainWindow;
                    var dataGrid = window.FindDataGrid("AutoColumnsTransposed");
                    var update = window.FindButton("UpdateDataButton");
                    var data = window.FindTextBlock("DataTextBox");

                    dataGrid[0, 0].Value = "10";
                    update.Click();
                    Assert.AreEqual("{{10, 2}, {3, 4}, {5, 6}}", data.Text);

                    dataGrid[1, 2].Value = "11";
                    update.Click();
                    Assert.AreEqual("{{10, 2}, {3, 4}, {5, 11}}", data.Text);
                }
            }
        }
    }
}
