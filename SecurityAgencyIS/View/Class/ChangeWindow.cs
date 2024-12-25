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
            string jsonFilePath = "C:\\Users\\ilcat\\source\\repos\\SecurityAgencyIS\\SecurityAgencyIS\\View\\EditingWindows\\Voorhees.json";
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
                    MessageBox.Show($"Таблица: {tablename}, Колонки: {table.columns}");

                }
            }
            Button saveButton = new Button
            {
                Text = "Сохранить",
                Location = new Point(150, 20 + i * 40),
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
                string[] data = new string[textBoxesList.Count];

                // Проверка первого поля как ID
                if (string.IsNullOrWhiteSpace(textBoxesList[0].Text) || !int.TryParse(textBoxesList[0].Text, out int intResult))
                {
                    throw new Exception($"Поле ID должно быть заполнено и содержать только целое число.");
                }

                // Заполнение массива данными из TextBox
                for (int i = 0; i < textBoxesList.Count; i++)
                {
                    string value = textBoxesList[i].Text?.Trim();
                    //if (string.IsNullOrWhiteSpace(value))
                    //{
                    //    throw new Exception($"Поле {i + 1} не заполнено. Пожалуйста, заполните все поля.");
                    //}
                    data[i] = value;
                }

                // Логирование данных перед обновлением
                MessageBox.Show($"Данные для обновления: {string.Join(", ", data)}");

                // Вызов метода Update
                dbManage.Update(tablename, data);

                // Успешное сообщение
                MessageBox.Show("Данные успешно сохранены!");
            }
            catch (Exception ex)
            {
                // Сообщение об ошибке
                MessageBox.Show($"Неверный запрос: {ex.Message}");
            }
        }
    }
}