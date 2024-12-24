using SecurityAgencyIS.Models;
using SecurityAgencyIS.View.Interface;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Media;
using SecurityAgencyIS.View.Class;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SecurityAgencyIS.Presenter
{
    public class MainWindowPresenter
    {
            IMainWindow _mainWindow { get; set; }
            public string currentTable { get; set; }
        public MainWindowPresenter(IMainWindow mainWindow)
        {
                _mainWindow = mainWindow;
                _mainWindow.TableMenuEmployee += ShowEmployeeTable;
                _mainWindow.TableMenuEvents += ShowEventsTable;
                _mainWindow.TableMenuCities += ShowCitiesTable;
                _mainWindow.TableMenuStreets += ShowStreetsTable;
                _mainWindow.TableMenuContracts += ShowContractsTable;
                _mainWindow.TableMenuIndividualEntity += ShowIndividualEntityTable;
                _mainWindow.TableMenuLegalEntity += ShowLegalEntityTable;
                _mainWindow.TableMenuOwners += ShowOwnersTable;
                _mainWindow.TableMenuJobs += ShowJobsTable;
                _mainWindow.TableMenuObjects += ShowObjectsTable;
                _mainWindow.TableMenuPayments += ShowPaymentsTable;
                _mainWindow.TableMenuSchedule += ShowScheduleTable;
                _mainWindow.TableMenuSpecialMeans += ShowSpecialMeansTable;
                _mainWindow.TableMenuWeapon += ShowWeaponTable;
                _mainWindow.TableMenuWeaponBrand += ShowWeaponBrandTable;
                _mainWindow.TableMenuUsers += ShowUsersTable;
                _mainWindow.AddButt += AddButton;
                _mainWindow.ChangeButt += ChangeButton;
                _mainWindow.DeleteButt += DeleteButton;
                _mainWindow.FindButt += FindButton;
                _mainWindow.AboutTheProgram += AboutTheProgramButton;
        }

        public void AddButton(object args, EventArgs e)
        {
            if (currentTable == null)
            {
                MessageBox.Show("Выберите сначала таблицу!");
            }
            else
            {
            AddWindow addForm = new AddWindow(currentTable);
            addForm.Show();
            }
        }


        public void ChangeButton(object args, EventArgs e)
        {
                if (currentTable == null)
                {
                    MessageBox.Show("Выберите сначала таблицу!");
                }
                else
                {
                    ChangeWindow changeWindow = new ChangeWindow(currentTable);
                    changeWindow.Show();
                }
        }

        public void DeleteButton(object args, EventArgs e)
        {
            string deleteFindId = _mainWindow.deleteFindId;
            DBManage dBManage = new DBManage();
            if (currentTable == null)
            {
                MessageBox.Show("Выберите сначала таблицу!");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(deleteFindId))
                {
                    MessageBox.Show("Эта строчка не может быть пустой при удалении чего-либо.", "Ошибка");
                }
                else
                {
                    if (deleteFindId is int)
                    {
                    dBManage.Delete(currentTable, Convert.ToInt32(deleteFindId));
                    }
                    else
                    {
                        MessageBox.Show("Эта строчка при удалении может принимать только целочисленные значения.", "Ошибка");
                    }
                }
            }
        }

        public void FindButton(object args, EventArgs e)
        {
            string deleteFindId = _mainWindow.deleteFindId;
            DBManage dBManage = new DBManage();
            if (currentTable == null)
            {
                MessageBox.Show("Выберите сначала таблицу!");
            }
            else
            {
                //dBManage.Find(findId, currentTable, deleteFindId);
            }
        }

        //public void AddLineButton(object args, EventArgs e)
        //{
        //    DBManage dataBase = new DBManage();
        //    NpgsqlConnection conn = new NpgsqlConnection(dataBase.connectionString);
        //    conn.Open();

        //    string tableName = currentTable;
        //    string query = @"
        //        SELECT COUNT(*)
        //        FROM information_schema.columns
        //        WHERE table_name = '" + currentTable + "'";

        //    NpgsqlCommand command = new NpgsqlCommand(query, conn);

        //    long columnCount = (long)command.ExecuteScalar();
        //    MessageBox.Show($"Количество столбцов в таблице {currentTable} это {columnCount}");
        //    AddLineWindow addLineWindow = new AddLineWindow();

        //    List<string> columnNames = GetColumnNames(currentTable);

        //    CreateTextBoxesForTable(addLineWindow, (int)columnCount, columnNames);
        //    addLineWindow.ShowDialog();
        //}

        //public void InsertRowIntoTable(AddLineWindow addLineWindow)
        //{
        //    Dictionary<string, string> columnValues = new Dictionary<string, string>();
        //    foreach (Control control in addLineWindow.Controls)
        //    {
        //        if (control is TextBox textBox && textBox.Tag is string columnName)
        //        {
        //            columnValues[columnName] = textBox.Text;
        //        }
        //    }

        //    if (columnValues.Count == 0)
        //    {
        //        MessageBox.Show("Нет данных для вставки.");
        //        return;
        //    }

        //    string tableName = currentTable;
        //    string columns = string.Join(", ", columnValues.Keys);
        //    string parameters = string.Join(", ", columnValues.Keys.Select(k => $"@{k}"));

        //    string query = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";

        //    NpgsqlConnection conn = new NpgsqlConnection(new DBManage().connectionString);

        //    conn.Open();
        //    NpgsqlCommand command = new NpgsqlCommand(query, conn);

        //    foreach (var pair in columnValues)
        //    {
        //        object value = string.IsNullOrEmpty(pair.Value) ? DBNull.Value : pair.Value;
        //        command.Parameters.AddWithValue($"@{pair.Key}", value);
        //    }

        //    //command.ExecuteNonQuery();
        //    MessageBox.Show($"SQL-запрос: {query}");
        //}
        //public void CreateTextBoxesForTable(AddLineWindow addLineWindow, int columnCount, List<string> columnNames)
        //{
        //    foreach (var control in addLineWindow.Controls.OfType<TextBox>().ToList())
        //    {
        //        addLineWindow.Controls.Remove(control);
        //    }
        //    foreach (var control in addLineWindow.Controls.OfType<Label>().ToList())
        //    {
        //        addLineWindow.Controls.Remove(control);
        //    }

        //    for (int i = 0; i < columnCount; i++)
        //    {
        //        int column = i / 4;
        //        int row = i % 4;

        //        Label label = new Label();
        //        label.Text = columnNames[i];
        //        label.Name = $"label{i}";
        //        label.Location = new Point(100 + column * 150, 10 + row * 60);
        //        label.AutoSize = true;
        //        addLineWindow.Controls.Add(label);


        //        TextBox textBox = new TextBox();
        //        textBox.Name = $"textBox{i}";
        //        textBox.Tag = columnNames[i];
        //        textBox.Location = new Point(100 + column * 150, 30 + row * 60);
        //        addLineWindow.Controls.Add(textBox);
        //    }
        //}
        //public List<string> GetColumnNames(string tableName)
        //{
        //    List<string> columnNames = new List<string>();
        //    DBManage dataBase = new DBManage();
        //    NpgsqlConnection conn = new NpgsqlConnection(dataBase.connectionString);

        //    conn.Open();
        //    string query = @"
        //        SELECT column_name
        //        FROM information_schema.columns
        //        WHERE table_name = @tableName
        //        ORDER BY ordinal_position";

        //    NpgsqlCommand command = new NpgsqlCommand(query, conn);

        //    command.Parameters.AddWithValue("@tableName", tableName);
        //    NpgsqlDataReader reader = command.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        columnNames.Add(reader["column_name"].ToString());
        //    }
        //    return columnNames;
        //}
        public void ShowEmployeeTable(object args, EventArgs e)
        {
            ShowTables showTables = new ShowTables();
            showTables.EmployeeTable(_mainWindow.MainDataGridView);
            currentTable = "employee";
        }
        public void ShowEventsTable(object args, EventArgs e)
        {
            ShowTables showTables = new ShowTables();
            showTables.EventsTable(_mainWindow.MainDataGridView);
            currentTable = "events";
        }
        public void ShowCitiesTable(object args, EventArgs e)
        {
            ShowTables showTables = new ShowTables();
            showTables.CitiesTable(_mainWindow.MainDataGridView);
            currentTable = "city";
        }
        public void ShowStreetsTable(object args, EventArgs e)
        {
            ShowTables showTables = new ShowTables();
            showTables.StreetsTable(_mainWindow.MainDataGridView);
            currentTable = "street";
        }
        public void ShowContractsTable(object args, EventArgs e)
        {
            ShowTables showTables = new ShowTables();
            showTables.ContractsTable(_mainWindow.MainDataGridView);
            currentTable = "contracts";
        }
        public void ShowIndividualEntityTable(object args, EventArgs e)
        {
            ShowTables showTables = new ShowTables();
            showTables.IndividualEntityTable(_mainWindow.MainDataGridView);
            currentTable = "individualentity";
        }
        public void ShowLegalEntityTable(object args, EventArgs e)
        {
            ShowTables showTables = new ShowTables();
            showTables.LegalEntityTable(_mainWindow.MainDataGridView);
            currentTable = "legalentity";
        }
        public void ShowOwnersTable(object args, EventArgs e)
        {
            ShowTables showTables = new ShowTables();
            showTables.OwnersTable(_mainWindow.MainDataGridView);
            currentTable = "owners";
        }
        public void ShowJobsTable(object args, EventArgs e)
        {
            ShowTables showTables = new ShowTables();
            showTables.JobsTable(_mainWindow.MainDataGridView);
            currentTable = "job";
        }
        public void ShowObjectsTable(object args, EventArgs e)
        {
            ShowTables showTables = new ShowTables();
            showTables.ObjectsTable(_mainWindow.MainDataGridView);
            currentTable = "objects";
        }
        public void ShowPaymentsTable(object args, EventArgs e)
        {
            ShowTables showTables = new ShowTables();
            showTables.PaymentsTable(_mainWindow.MainDataGridView);
            currentTable = "payment";
        }
        public void ShowScheduleTable(object args, EventArgs e)
        {
            ShowTables showTables = new ShowTables();
            showTables.ScheduleTable(_mainWindow.MainDataGridView);
            currentTable = "schedule";
        }
        public void ShowSpecialMeansTable(object args, EventArgs e)
        {
            ShowTables showTables = new ShowTables();
            showTables.SpecialMeansTable(_mainWindow.MainDataGridView);
            currentTable = "specialmeans";
        }
        public void ShowWeaponTable(object args, EventArgs e)
        {
            ShowTables showTables = new ShowTables();
            showTables.WeaponTable(_mainWindow.MainDataGridView);
            currentTable = "weapon";
        }
        public void ShowWeaponBrandTable(object args, EventArgs e)
        {
            ShowTables showTables = new ShowTables();
            showTables.WeaponBrandTable(_mainWindow.MainDataGridView);
            currentTable = "weaponbrand";
        }
        public void ShowUsersTable(object args, EventArgs e)
        {
            ShowTables showTables = new ShowTables();
            showTables.UsersTable(_mainWindow.MainDataGridView);
            currentTable = "users";
        }
        public void AboutTheProgramButton(object args, EventArgs e)
        {
            MessageBox.Show("Программа была разработана студентом НГТУ НЭТИ Соболевым И. О. Группа АВТ-214.", "О программе");
            SoundPlayer simpleSound = new SoundPlayer(@"d:\Dev\AboutTheProgram.wav");
            simpleSound.Play();
        }
    }
}
