using Newtonsoft.Json;
using SecurityAgencyIS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurityAgencyIS.View.Class
{
    public partial class ChangeWindow : Form
    {
        private string tablename;
        DBManage dbManage;
        private List<TextBox> textBoxesList = new List<TextBox>();
        public ChangeWindow(string tablename)
        {
            this.tablename = tablename;
            dbManage = new DBManage();
            string jsonFilePath = "C:\\Users\\serov\\source\\repos\\building_organizations\\building_organizations\\Entity\\Stetham.json";
            string jsonContent = File.ReadAllText(jsonFilePath);
            dynamic tables = JsonConvert.DeserializeObject(jsonContent);
            this.Text = tablename;
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
                        label.Font = new Font("Impact", 12F);
                        label.Show();
                        this.Controls.Add(label);
                        TextBox textBox = new TextBox();
                        textBox.Text = "";
                        textBox.Location = new System.Drawing.Point(200, 20 + i * 40);
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
                Location = new System.Drawing.Point(150, 20 + i * 40),
                Width = 100
            };
            saveButton.BackColor = Color.FromArgb(255, 128, 128);
            saveButton.Font = new Font("Impact", 14F);
            saveButton.Size = new Size(177, 81);
            saveButton.TabIndex = 2;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += SaveButton_Click;
            this.Controls.Add(saveButton);
            InitializeComponent();
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string[] data = { };
                Array.Resize(ref data, textBoxesList.Count);
                if (!int.TryParse(textBoxesList[0].Text, out int intResult))
                    throw new Exception($"Cannot convert '{textBoxesList[0].Text}' to integer. ID!!!");
                for (int i = 0; i < textBoxesList.Count; i++)
                {
                    string value = textBoxesList[i].Text;
                    data[i] = value;
                }
                dbManage.Update(tablename, data);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неверный запрос:{ex.Message}");
            }
            finally
            {
                MessageBox.Show($"Данные успешно сохранены!");
            }
        }
    }
}