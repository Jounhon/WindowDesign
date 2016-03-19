using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ordering_System
{
    public partial class POS : Form
    {
        public POS()
        {
            InitializeComponent();
            InitializeGroupBox();
            InitializeDataGridView();
            Globals.form = this;
        }

        PosCustomerSideModel POS_CSM = new PosCustomerSideModel();

        private void InitializeGroupBox()
        {
            string[] names ={"大麥克","雙層牛肉吉事堡","四盎司牛肉堡餐","雙層四盎司牛肉堡餐","1955 美式培根牛肉堡","麥香魚餐"
            ,"麥香鷄餐","麥克鷄塊餐(六塊)","麥克鷄塊餐(九塊)","勁辣鷄腿堡餐","麥脆鷄餐(二塊)","板烤鷄腿堡餐","快樂兒童餐","悲傷兒童餐","快樂成人餐"};

            for (var index = 0; index < names.Length; index++)
            {
                POS_CSM.addMeal(names[index], (index + 99).ToString(), index);
            }
            changeButtons();
        }
        private void removeButtons()
        {
            for (var index = (POS_CSM.page.currentPage - 1) * 9; index < (POS_CSM.page.currentPage - 1) * 9 + 9; index++)
            {
                if (index >= POS_CSM.mealList.Count) break;
                MealTableLayoutPanel.Controls.Remove(POS_CSM.getMeal(index));
            }
        }
        private void changeButtons()
        {
            if (POS_CSM.page.currentPage.Equals(POS_CSM.MaxPage())) nextButton.Enabled = false;
            else nextButton.Enabled = true;
            if (POS_CSM.page.currentPage.Equals(1)) preButton.Enabled = false;
            else preButton.Enabled = true;
            for (var index = (POS_CSM.page.currentPage - 1) * 9; index < (POS_CSM.page.currentPage - 1) * 9 + 9; index++)
            {
                if (index >= POS_CSM.mealList.Count) break;
                int colIndex = index / 3 - (POS_CSM.page.currentPage - 1) * 3;
                int rowIndex = index % 3;
                MealTableLayoutPanel.Controls.Add(POS_CSM.getMeal(index), rowIndex, colIndex);
            };
            pageLabel.Text = "page: " + POS_CSM.page.currentPage.ToString() + " / " + POS_CSM.MaxPage().ToString();
        }
        private void InitializeDataGridView()
        {
            recordDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            recordDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            recordDataGridView.Name = "recordDGV";
            recordDataGridView.ReadOnly = true;
            recordDataGridView.RowHeadersVisible = false;
            recordDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            string[] headerText = { "Meal Name", "Unit Price", "Qty", "Subtotal" };

            recordDataGridView.ColumnCount = headerText.Length;
            for (var counter = 0; counter < headerText.Length; counter++)
            {
                recordDataGridView.Columns[counter].Name = headerText[counter];
            }
            foreach (Order item in POS_CSM.orderList)
            {
                recordDataGridView.Rows.Add(item);
            }
        }
        public void updateRecordGDV(Meal data)
        {
            POS_CSM.addOrder(data);
            recordDataGridView.Rows.Clear();
            foreach (Order item in POS_CSM.orderList)
            {
                recordDataGridView.Rows.Add(item.name,item.price,item.qty,item.total);
            }
            TotalLabel.Text = "Total : " + POS_CSM.countTotal() + " NTD";
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            removeButtons();
            POS_CSM.page.nextPage(POS_CSM.MaxPage());
            changeButtons();
        }

        private void preButton_Click(object sender, EventArgs e)
        {
            removeButtons();
            POS_CSM.page.prePage();
            changeButtons();
        }
    }
    class Globals
    {
        public static POS form;
    }
    public class PosCustomerSideModel
    {
        public List<Meal> mealList = new List<Meal>();
        public List<Order> orderList = new List<Order>();
        public Page page = new Page();
        public void addMeal(string name,string price,int index){
            Meal data = new Meal() { name = name, price = price };
            data.Text = data.ToString();
            data.Dock = DockStyle.Fill;
            data.Name = index.ToString();
            data.Font = new Font(data.Font.FontFamily, 12);
            data.Click += new EventHandler(button_click);
            mealList.Add(data);
        }
        public void addOrder(Meal data)
        {
            if (orderList.Count.Equals(0))
            {
                Order new_item = new Order() { name = data.name, price = data.price, qty = "1", total = data.price };
                orderList.Add(new_item);
            }
            else
            {
                Boolean Noitem = true;
                foreach (Order item in orderList)
                {
                    if (item.name.Equals(data.name))
                    {
                        item.qty = (int.Parse(item.qty) + 1).ToString();
                        item.total = (int.Parse(item.qty) * int.Parse(item.price)).ToString();
                        Noitem = false;
                        break;
                    }
                }
                if (Noitem)
                {
                    Order new_item = new Order() { name = data.name, price = data.price, qty = "1", total = data.price };
                    orderList.Add(new_item);
                }
            }
        }
        public string countTotal()
        {
            int total = 0;
            foreach (Order item in orderList)
            {
                total += int.Parse(item.total);
            }
            return total.ToString();
        }
        public void button_click(object sender, EventArgs e)
        {
            int btn_Id = int.Parse(((Button)sender).Name);
            Meal data = mealList[btn_Id];
            Globals.form.updateRecordGDV(data);
        }
        public Meal getMeal(int index)
        {
            return mealList[index];
        }
        public int MaxPage()
        {
            return Convert.ToInt16(Math.Ceiling(Convert.ToDouble(mealList.Count) / 9));
        }
    }
    public class Meal : Button
    {
        public string name { get; set; }
        public string price { get; set; }
        public override string ToString()
        {
            return name + "\n" + price + " NTD";
        }
    }
    public class Order
    {
        public string name { get; set; }
        public string price { get; set; }
        public string qty { get; set; }
        public string total { get; set; }
    }
    public class Page
    {
        public int currentPage = 1;
        public void prePage()
        {
            if (currentPage - 1 > 0) currentPage -= 1;
        }
        public void nextPage(int maxPage)
        {
            if (currentPage + 1 <= maxPage) currentPage += 1;
        }
    }
}
