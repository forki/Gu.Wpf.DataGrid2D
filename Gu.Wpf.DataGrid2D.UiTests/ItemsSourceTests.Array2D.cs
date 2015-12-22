﻿namespace Gu.Wpf.DataGrid2D.UiTests
{
    using Gu.Wpf.DataGrid2D.Demo;
    using NUnit.Framework;
    using TestStack.White;
    using TestStack.White.Factory;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.Finders;
    using TestStack.White.UIItems.TabItems;

    public partial class ItemsSourceTests
    {
        public class Array2D
        {
            [Test]
            public void AutoColumns()
            {
                using (var app = Application.AttachOrLaunch(ProcessStartInfo))
                {
                    var window = app.GetWindow(AutomationIds.MainWindow, InitializeOption.NoCache);
                    var page = window.Get<TabPage>(AutomationIds.MultiDimensionalTab);
                    page.Select();
                    var dataGrid = page.Get<ListView>(AutomationIds.MultiDimensionalAutoColumns);

                    Assert.AreEqual(2, dataGrid.Rows[0].Cells.Count);
                    Assert.AreEqual(3, dataGrid.Rows.Count);

                    var c0 = dataGrid.Header.Columns[0].Text;
                    Assert.AreEqual("C0", c0);
                    var c1 = dataGrid.Header.Columns[1].Text;
                    Assert.AreEqual("C1", c1);

                    Assert.AreEqual("1", dataGrid.Cell(c0, 0).Text);
                    Assert.AreEqual("3", dataGrid.Cell(c0, 1).Text);
                    Assert.AreEqual("5", dataGrid.Cell(c0, 2).Text);

                    Assert.AreEqual("2", dataGrid.Cell(c1, 0).Text);
                    Assert.AreEqual("4", dataGrid.Cell(c1, 1).Text);
                    Assert.AreEqual("6", dataGrid.Cell(c1, 2).Text);
                }
            }

            [Test]
            public void ExplicitColumns()
            {
                using (var app = Application.AttachOrLaunch(ProcessStartInfo))
                {
                    var window = app.GetWindow(AutomationIds.MainWindow, InitializeOption.NoCache);
                    var page = window.Get<TabPage>(AutomationIds.MultiDimensionalTab);
                    page.Select();
                    var dataGrid = page.Get<ListView>(AutomationIds.MultiDimensionalExplicitColumns);

                    Assert.AreEqual(2, dataGrid.Rows[0].Cells.Count);
                    Assert.AreEqual(3, dataGrid.Rows.Count);

                    var c0 = dataGrid.Header.Columns[0].Text;
                    Assert.AreEqual("Col 1", c0);
                    var c1 = dataGrid.Header.Columns[1].Text;
                    Assert.AreEqual("Col 2", c1);

                    Assert.AreEqual("1", dataGrid.Cell(c0, 0).Text);
                    Assert.AreEqual("3", dataGrid.Cell(c0, 1).Text);
                    Assert.AreEqual("5", dataGrid.Cell(c0, 2).Text);

                    Assert.AreEqual("2", dataGrid.Cell(c1, 0).Text);
                    Assert.AreEqual("4", dataGrid.Cell(c1, 1).Text);
                    Assert.AreEqual("6", dataGrid.Cell(c1, 2).Text);
                }
            }

            [Test]
            public void WithHeaders()
            {
                using (var app = Application.AttachOrLaunch(ProcessStartInfo))
                {
                    var window = app.GetWindow(AutomationIds.MainWindow, InitializeOption.NoCache);
                    var page = window.Get<TabPage>(AutomationIds.MultiDimensionalTab);
                    page.Select();
                    var dataGrid = page.Get<ListView>(AutomationIds.MultiDimensionalWithHeaders);

                    Assert.AreEqual(3, dataGrid.Rows[0].Cells.Count);
                    Assert.AreEqual(3, dataGrid.Rows.Count);

                    var c0 = dataGrid.Header.Columns[0].Text;
                    Assert.AreEqual("A", c0);
                    var c1 = dataGrid.Header.Columns[1].Text;
                    Assert.AreEqual("B", c1);

                    Assert.AreEqual("1", dataGrid.Rows[0].Cells[0].Text);
                    Assert.AreEqual("2", dataGrid.Rows[1].Cells[0].Text);
                    Assert.AreEqual("3", dataGrid.Rows[2].Cells[0].Text);

                    Assert.AreEqual("1", dataGrid.Cell(c0, 0).Text);
                    Assert.AreEqual("3", dataGrid.Cell(c0, 1).Text);
                    Assert.AreEqual("5", dataGrid.Cell(c0, 2).Text);

                    Assert.AreEqual("2", dataGrid.Cell(c1, 0).Text);
                    Assert.AreEqual("4", dataGrid.Cell(c1, 1).Text);
                    Assert.AreEqual("6", dataGrid.Cell(c1, 2).Text);
                }
            }
        }
    }
}