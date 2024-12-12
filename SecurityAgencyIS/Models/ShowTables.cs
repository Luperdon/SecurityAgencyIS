using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace SecurityAgencyIS.Models
{
    public class ShowTables
    {
        string connectionString = "Server=localhost;Port=5432;Database=SecurityAgencyDB;User id=postgres;Password=1234;";
        public void EmployeeTable(DataGridView dataGridView1)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM employee";
            NpgsqlDataReader dataReader = command.ExecuteReader();

                DataTable data = new DataTable();
                data.Load(dataReader);
                dataGridView1.DataSource = data;
   

            command.Dispose();
            conn.Close();
        }
        public void EventsTable(DataGridView dataGridView1)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM events";
            NpgsqlDataReader dataReader = command.ExecuteReader();
            
                DataTable data = new DataTable();
                data.Load(dataReader);
                dataGridView1.DataSource = data;

            command.Dispose();
            conn.Close();
        }
        public void CitiesTable(DataGridView dataGridView1)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM city";
            NpgsqlDataReader dataReader = command.ExecuteReader();

            DataTable data = new DataTable();
            data.Load(dataReader);
            dataGridView1.DataSource = data;

            command.Dispose();
            conn.Close();
        }
        public void StreetsTable(DataGridView dataGridView1)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM street";
            NpgsqlDataReader dataReader = command.ExecuteReader();

            DataTable data = new DataTable();
            data.Load(dataReader);
            dataGridView1.DataSource = data;

            command.Dispose();
            conn.Close();
        }
        public void ContractsTable(DataGridView dataGridView1)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM contracts";
            NpgsqlDataReader dataReader = command.ExecuteReader();

            DataTable data = new DataTable();
            data.Load(dataReader);
            dataGridView1.DataSource = data;

            command.Dispose();
            conn.Close();
        }
        public void IndividualEntityTable(DataGridView dataGridView1)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM individualentity";
            NpgsqlDataReader dataReader = command.ExecuteReader();

            DataTable data = new DataTable();
            data.Load(dataReader);
            dataGridView1.DataSource = data;

            command.Dispose();
            conn.Close();
        }
        public void LegalEntityTable(DataGridView dataGridView1)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM legalentity";
            NpgsqlDataReader dataReader = command.ExecuteReader();

            DataTable data = new DataTable();
            data.Load(dataReader);
            dataGridView1.DataSource = data;

            command.Dispose();
            conn.Close();
        }
        public void OwnersTable(DataGridView dataGridView1)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM owners";
            NpgsqlDataReader dataReader = command.ExecuteReader();

            DataTable data = new DataTable();
            data.Load(dataReader);
            dataGridView1.DataSource = data;

            command.Dispose();
            conn.Close();
        }
        public void JobsTable(DataGridView dataGridView1)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM job";
            NpgsqlDataReader dataReader = command.ExecuteReader();

            DataTable data = new DataTable();
            data.Load(dataReader);
            dataGridView1.DataSource = data;

            command.Dispose();
            conn.Close();
        }
        public void ObjectsTable(DataGridView dataGridView1)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM objects";
            NpgsqlDataReader dataReader = command.ExecuteReader();

            DataTable data = new DataTable();
            data.Load(dataReader);
            dataGridView1.DataSource = data;

            command.Dispose();
            conn.Close();
        }
        public void PaymentsTable(DataGridView dataGridView1)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM payment";
            NpgsqlDataReader dataReader = command.ExecuteReader();

            DataTable data = new DataTable();
            data.Load(dataReader);
            dataGridView1.DataSource = data;

            command.Dispose();
            conn.Close();
        }
        public void ScheduleTable(DataGridView dataGridView1)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM schedule";
            NpgsqlDataReader dataReader = command.ExecuteReader();

            DataTable data = new DataTable();
            data.Load(dataReader);
            dataGridView1.DataSource = data;

            command.Dispose();
            conn.Close();
        }
        public void SpecialMeansTable(DataGridView dataGridView1)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM specialmeans";
            NpgsqlDataReader dataReader = command.ExecuteReader();

            DataTable data = new DataTable();
            data.Load(dataReader);
            dataGridView1.DataSource = data;

            command.Dispose();
            conn.Close();
        }
        public void WeaponTable(DataGridView dataGridView1)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM weapon";
            NpgsqlDataReader dataReader = command.ExecuteReader();

            DataTable data = new DataTable();
            data.Load(dataReader);
            dataGridView1.DataSource = data;

            command.Dispose();
            conn.Close();
        }
        public void WeaponBrandTable(DataGridView dataGridView1)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM weaponbrand";
            NpgsqlDataReader dataReader = command.ExecuteReader();

            DataTable data = new DataTable();
            data.Load(dataReader);
            dataGridView1.DataSource = data;

            command.Dispose();
            conn.Close();
        }
        public void UsersTable(DataGridView dataGridView1)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);

            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM users";
            NpgsqlDataReader dataReader = command.ExecuteReader();

            DataTable data = new DataTable();
            data.Load(dataReader);
            dataGridView1.DataSource = data;

            command.Dispose();
            conn.Close();
        }
    }
}
