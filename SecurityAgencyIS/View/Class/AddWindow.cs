using SecurityAgencyIS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurityAgencyIS.View.Class
{
    public partial class AddWindow : Form
    {
        private List<TextBox> textBoxesList = new List<TextBox>();
        private DBManage dbManage;
        private string tablename;
        public AddWindow(string tablename)
        {
            this.tablename = tablename;
            dbManage = new DBManage();
            string jsonFilePath = "C:\\Users\\ilcat\\source\\repos\\SecurityAgencyIS\\SecurityAgencyIS\\View\\EditingWindows\\Voorhees.json";
            string jsonContent = File.ReadAllText(jsonFilePath);
            dynamic tables = JsonConvert.DeserializeObject(jsonContent);
            this.Text = tablename;
            //string[] defaults;
            int i = 0;
            foreach (var table in tables)
            {
                if (table.table_name == tablename)
                {
                    foreach (var column in table.columns)
                    {
                        Label label = new Label();
                        label.Text = column.lname;
                        label.Location = new System.Drawing.Point(20, 20 + i * 40);
                        label.AutoSize = true;
                        label.Font = new Font("Haettenschweiler", 12F);
                        label.Show();
                        this.Controls.Add(label);
                        TextBox textBox = new TextBox();
                        //textBox.Text = defaults[i];
                        textBox.Location = new System.Drawing.Point(150, 20 + i * 40);
                        textBox.Width = 200;
                        i++;
                        this.Controls.Add(textBox);
                        textBoxesList.Add(textBox);
                    }
                }
            }
            Button saveButton = new Button
            {
                Text = "Сохранить",
                Location = new Point(150, 20 + i * 40),
                Width = 100
            };
            saveButton.BackColor = Color.FromArgb(64, 64, 64);
            saveButton.Font = new Font("Haettenschweiler", 14F);
            saveButton.Size = new Size(177, 81);
            saveButton.TabIndex = 2;
            saveButton.Text = "Подтвердить";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += SaveButton_Click;
            this.Controls.Add(saveButton);
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string[] data = { };
            Array.Resize(ref data, textBoxesList.Count);
            for (int i = 0; i < textBoxesList.Count; i++)
            {
                string value = textBoxesList[i].Text;
                data[i] = value;
            }
            dbManage.Add(data, tablename);
        }

    }
}
