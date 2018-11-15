using Syncfusion.Data;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoCommon.Grid;
using System.Windows.Forms.VisualStyles;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.Input.Enums;
using Syncfusion.WinForms.DataGrid.Enums;
using System.Globalization;
using Syncfusion.WinForms.ListView;
using Syncfusion.WinForms.ListView.Enums;

namespace ColumnTypes
{
    public partial class Form1 : Form
    {
        OrderInfoCollection orderInfo;

        public Form1()
        {
            InitializeComponent();
            orderInfo = new OrderInfoCollection();
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalDigits = 0;
            nfi.NumberGroupSizes = new int[] { };
            this.sfDataGrid1.DataSource = orderInfo.OrdersListDetails;
            this.sfDataGrid1.Columns.Add(new GridNumericColumn() { MappingName = "OrderID", HeaderText = "Order ID", NumberFormatInfo = nfi });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "CustomerID", HeaderText = "Customer ID" });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ContactNumber", HeaderText = "Contact Number" });
            NumberFormatInfo numberFormat = Application.CurrentCulture.NumberFormat.Clone() as NumberFormatInfo;
            numberFormat.CurrencyDecimalDigits = 0;
            numberFormat.CurrencyGroupSizes = new int[] { };

            this.sfDataGrid1.Columns.Add(new GridNumericColumn()
            {
                MappingName = "UnitPrice",
                HeaderText = "Unit Price",
                FormatMode = FormatMode.Currency,
                NumberFormatInfo = numberFormat
            });

            numberFormat = Application.CurrentCulture.NumberFormat.Clone() as NumberFormatInfo;
            numberFormat.NumberDecimalDigits = 0;
            numberFormat.NumberGroupSizes = new int[] { };
            this.sfDataGrid1.Columns.Add(new GridNumericColumn()
            {
                HeaderText = "Quantity",
                MappingName = "Quantity",
                FormatMode = FormatMode.Numeric,
                NumberFormatInfo = numberFormat
            });

            this.sfDataGrid1.Columns.Add(new GridNumericColumn() { MappingName = "Discount", HeaderText = "Discount", FormatMode = FormatMode.Percent });
            this.sfDataGrid1.Columns.Add(new GridDateTimeColumn() { MappingName = "OrderDate", HeaderText = "Order Date", FilterMode = ColumnFilter.DisplayText });
            this.sfDataGrid1.Columns.Add(new GridCheckBoxColumn() { MappingName = "IsClosed", HeaderText = "Is Closed" });
            this.sfDataGrid1.Columns.Add(new GridCheckBoxColumn() { MappingName = "ClosedStatus", HeaderText = "Closed Status" });

            this.sfDataGrid1.CellCheckBoxClick += sfDataGrid1_CellCheckBoxClick;

            this.sfDataGrid1.CurrentCellActivating += sfDataGrid1_CurrentCellActivating;

        }

        void sfDataGrid1_CurrentCellActivating(object sender, CurrentCellActivatingEventArgs e)
        {
            if (e.DataColumn.GridColumn.MappingName == "ClosedStatus")
                e.Cancel = true;
        }

        void sfDataGrid1_CellCheckBoxClick(object sender, CellCheckBoxClickEventArgs e)
        {

            if (e.Column.MappingName == "ClosedStatus")
                e.Cancel = true;

            if (e.Column.MappingName == "IsClosed")
            {
                (e.Record as OrderInfo).ClosedStatus = e.NewValue == CheckState.Checked;
            }
        }
    }
}
