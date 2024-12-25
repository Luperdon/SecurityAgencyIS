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
    public partial class Documents : Form
    {
        DBManage dbManage;
        public Documents()
        {
            InitializeComponent();
            dbManage = new DBManage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string queryText = textBox1.Text.Trim();

            if (!queryText.StartsWith("Select", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Ошибка: запрос должен начинаться с 'Select'.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dbManage.QueryTool(queryText, dataGridView1);
        }

        public static void ExportToCsv(DataGridView dataGridView)
        {
            try
            {
                // Открываем диалог для выбора папки
                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    folderBrowserDialog.Description = "Выберите папку для сохранения файла";

                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Запрашиваем имя файла у пользователя
                        string fileName = PromptForFileName();
                        if (string.IsNullOrEmpty(fileName))
                        {
                            MessageBox.Show("Имя файла не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Создаем полный путь к файлу
                        string filePath = Path.Combine(folderBrowserDialog.SelectedPath, fileName + ".csv");

                        // Проверяем, не существует ли уже файл
                        if (File.Exists(filePath))
                        {
                            DialogResult overwrite = MessageBox.Show(
                                "Файл с таким именем уже существует. Перезаписать?",
                                "Подтверждение",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning);

                            if (overwrite != DialogResult.Yes)
                                return;
                        }

                        // Экспортируем данные в файл
                        using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
                        {
                            // Экспорт заголовков
                            for (int i = 0; i < dataGridView.Columns.Count; i++)
                            {
                                sw.Write(dataGridView.Columns[i].HeaderText);
                                if (i < dataGridView.Columns.Count - 1)
                                    sw.Write(",");
                            }
                            sw.WriteLine();

                            // Экспорт строк
                            foreach (DataGridViewRow row in dataGridView.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                                    {
                                        sw.Write(row.Cells[i].Value?.ToString());
                                        if (i < dataGridView.Columns.Count - 1)
                                            sw.Write(",");
                                    }
                                    sw.WriteLine();
                                }
                            }
                        }

                        MessageBox.Show($"Данные успешно экспортированы в файл: {filePath}", "Экспорт завершен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод для запроса имени файла у пользователя
        private static string PromptForFileName()
        {
            using (Form inputForm = new Form())
            {
                inputForm.Text = "Введите имя файла";
                inputForm.Width = 400;
                inputForm.Height = 150;
                inputForm.StartPosition = FormStartPosition.CenterScreen;

                Label label = new Label() { Left = 20, Top = 20, Text = "Имя файла:", Width = 350 };
                TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 350 };
                Button buttonOk = new Button() { Text = "OK", Left = 280, Width = 90, Top = 80, DialogResult = DialogResult.OK };

                inputForm.Controls.Add(label);
                inputForm.Controls.Add(textBox);
                inputForm.Controls.Add(buttonOk);
                inputForm.AcceptButton = buttonOk;

                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    return textBox.Text.Trim();
                }
            }
            return null;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ExportToCsv(dataGridView1);
        }
    }
}
