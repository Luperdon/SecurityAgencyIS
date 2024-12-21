namespace SecurityAgencyIS
{
    partial class MainWindow 
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private DataGridView DataGridView1;
        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.спраToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuEvents = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuCities = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuStreets = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuContracts = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuIndividualEntity = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuLegalEntity = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuOwners = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuJobs = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuObjects = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuPayments = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuSpecialMeans = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuWeapon = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuWeaponBrand = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.разноеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutTheProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.консольToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddLineButton = new System.Windows.Forms.Button();
            this.ChangeButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SearchButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(12, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(1022, 344);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuStrip1.Font = new System.Drawing.Font("Haettenschweiler", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.спраToolStripMenuItem,
            this.справочникToolStripMenuItem,
            this.разноеToolStripMenuItem,
            this.AboutTheProgramToolStripMenuItem,
            this.консольToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1046, 34);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // спраToolStripMenuItem
            // 
            this.спраToolStripMenuItem.BackColor = System.Drawing.Color.Goldenrod;
            this.спраToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.спраToolStripMenuItem.Name = "спраToolStripMenuItem";
            this.спраToolStripMenuItem.Size = new System.Drawing.Size(125, 30);
            this.спраToolStripMenuItem.Text = "Документы";
            // 
            // справочникToolStripMenuItem
            // 
            this.справочникToolStripMenuItem.BackColor = System.Drawing.Color.Goldenrod;
            this.справочникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMenuEmployee,
            this.StripMenuEvents,
            this.StripMenuCities,
            this.StripMenuStreets,
            this.StripMenuContracts,
            this.StripMenuIndividualEntity,
            this.StripMenuLegalEntity,
            this.StripMenuOwners,
            this.StripMenuJobs,
            this.StripMenuObjects,
            this.StripMenuPayments,
            this.StripMenuSchedule,
            this.StripMenuSpecialMeans,
            this.StripMenuWeapon,
            this.StripMenuWeaponBrand,
            this.StripMenuUsers});
            this.справочникToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.справочникToolStripMenuItem.Name = "справочникToolStripMenuItem";
            this.справочникToolStripMenuItem.Size = new System.Drawing.Size(118, 30);
            this.справочникToolStripMenuItem.Text = "Справочник";
            // 
            // StripMenuEmployee
            // 
            this.StripMenuEmployee.Name = "StripMenuEmployee";
            this.StripMenuEmployee.Size = new System.Drawing.Size(258, 30);
            this.StripMenuEmployee.Text = "Сотрудники";
            this.StripMenuEmployee.Click += new System.EventHandler(this.StripMenuEmployee_Click);
            // 
            // StripMenuEvents
            // 
            this.StripMenuEvents.Name = "StripMenuEvents";
            this.StripMenuEvents.Size = new System.Drawing.Size(258, 30);
            this.StripMenuEvents.Text = "Мероприятия";
            this.StripMenuEvents.Click += new System.EventHandler(this.StripMenuEvents_Click);
            // 
            // StripMenuCities
            // 
            this.StripMenuCities.Name = "StripMenuCities";
            this.StripMenuCities.Size = new System.Drawing.Size(258, 30);
            this.StripMenuCities.Text = "Города";
            this.StripMenuCities.Click += new System.EventHandler(this.StripMenuCities_Click);
            // 
            // StripMenuStreets
            // 
            this.StripMenuStreets.Name = "StripMenuStreets";
            this.StripMenuStreets.Size = new System.Drawing.Size(258, 30);
            this.StripMenuStreets.Text = "Улицы";
            this.StripMenuStreets.Click += new System.EventHandler(this.StripMenuStreets_Click);
            // 
            // StripMenuContracts
            // 
            this.StripMenuContracts.Name = "StripMenuContracts";
            this.StripMenuContracts.Size = new System.Drawing.Size(258, 30);
            this.StripMenuContracts.Text = "Договоры";
            this.StripMenuContracts.Click += new System.EventHandler(this.StripMenuContracts_Click);
            // 
            // StripMenuIndividualEntity
            // 
            this.StripMenuIndividualEntity.Name = "StripMenuIndividualEntity";
            this.StripMenuIndividualEntity.Size = new System.Drawing.Size(258, 30);
            this.StripMenuIndividualEntity.Text = "Физические лица";
            this.StripMenuIndividualEntity.Click += new System.EventHandler(this.StripMenuIndividualEntity_Click);
            // 
            // StripMenuLegalEntity
            // 
            this.StripMenuLegalEntity.Name = "StripMenuLegalEntity";
            this.StripMenuLegalEntity.Size = new System.Drawing.Size(258, 30);
            this.StripMenuLegalEntity.Text = "Юридические лица";
            this.StripMenuLegalEntity.Click += new System.EventHandler(this.StripMenuLegalEntity_Click);
            // 
            // StripMenuOwners
            // 
            this.StripMenuOwners.Name = "StripMenuOwners";
            this.StripMenuOwners.Size = new System.Drawing.Size(258, 30);
            this.StripMenuOwners.Text = "Владельцы";
            this.StripMenuOwners.Click += new System.EventHandler(this.StripMenuOwners_Click);
            // 
            // StripMenuJobs
            // 
            this.StripMenuJobs.Name = "StripMenuJobs";
            this.StripMenuJobs.Size = new System.Drawing.Size(258, 30);
            this.StripMenuJobs.Text = "Должности";
            this.StripMenuJobs.Click += new System.EventHandler(this.StripMenuJobs_Click);
            // 
            // StripMenuObjects
            // 
            this.StripMenuObjects.Name = "StripMenuObjects";
            this.StripMenuObjects.Size = new System.Drawing.Size(258, 30);
            this.StripMenuObjects.Text = "Объекты";
            this.StripMenuObjects.Click += new System.EventHandler(this.StripMenuObjects_Click);
            // 
            // StripMenuPayments
            // 
            this.StripMenuPayments.Name = "StripMenuPayments";
            this.StripMenuPayments.Size = new System.Drawing.Size(258, 30);
            this.StripMenuPayments.Text = "Платежи";
            this.StripMenuPayments.Click += new System.EventHandler(this.StripMenuPayments_Click);
            // 
            // StripMenuSchedule
            // 
            this.StripMenuSchedule.Name = "StripMenuSchedule";
            this.StripMenuSchedule.Size = new System.Drawing.Size(258, 30);
            this.StripMenuSchedule.Text = "Графики";
            this.StripMenuSchedule.Click += new System.EventHandler(this.StripMenuSchedule_Click);
            // 
            // StripMenuSpecialMeans
            // 
            this.StripMenuSpecialMeans.Name = "StripMenuSpecialMeans";
            this.StripMenuSpecialMeans.Size = new System.Drawing.Size(258, 30);
            this.StripMenuSpecialMeans.Text = "Спец.средства";
            this.StripMenuSpecialMeans.Click += new System.EventHandler(this.StripMenuSpecialMeans_Click);
            // 
            // StripMenuWeapon
            // 
            this.StripMenuWeapon.Name = "StripMenuWeapon";
            this.StripMenuWeapon.Size = new System.Drawing.Size(258, 30);
            this.StripMenuWeapon.Text = "Оружие";
            this.StripMenuWeapon.Click += new System.EventHandler(this.StripMenuWeapon_Click);
            // 
            // StripMenuWeaponBrand
            // 
            this.StripMenuWeaponBrand.Name = "StripMenuWeaponBrand";
            this.StripMenuWeaponBrand.Size = new System.Drawing.Size(258, 30);
            this.StripMenuWeaponBrand.Text = "Марка оружия";
            this.StripMenuWeaponBrand.Click += new System.EventHandler(this.StripMenuWeaponBrand_Click);
            // 
            // StripMenuUsers
            // 
            this.StripMenuUsers.Name = "StripMenuUsers";
            this.StripMenuUsers.Size = new System.Drawing.Size(258, 30);
            this.StripMenuUsers.Text = "Пользователи";
            this.StripMenuUsers.Click += new System.EventHandler(this.StripMenuUsers_Click);
            // 
            // разноеToolStripMenuItem
            // 
            this.разноеToolStripMenuItem.BackColor = System.Drawing.Color.Goldenrod;
            this.разноеToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.разноеToolStripMenuItem.Name = "разноеToolStripMenuItem";
            this.разноеToolStripMenuItem.Size = new System.Drawing.Size(80, 30);
            this.разноеToolStripMenuItem.Text = "Разное";
            // 
            // AboutTheProgramToolStripMenuItem
            // 
            this.AboutTheProgramToolStripMenuItem.BackColor = System.Drawing.Color.Goldenrod;
            this.AboutTheProgramToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.AboutTheProgramToolStripMenuItem.Name = "AboutTheProgramToolStripMenuItem";
            this.AboutTheProgramToolStripMenuItem.Size = new System.Drawing.Size(129, 30);
            this.AboutTheProgramToolStripMenuItem.Text = "О программе";
            this.AboutTheProgramToolStripMenuItem.Click += new System.EventHandler(this.AboutTheProgramToolStripMenuItem_Click);
            // 
            // консольToolStripMenuItem
            // 
            this.консольToolStripMenuItem.BackColor = System.Drawing.Color.Goldenrod;
            this.консольToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.консольToolStripMenuItem.Name = "консольToolStripMenuItem";
            this.консольToolStripMenuItem.Size = new System.Drawing.Size(92, 30);
            this.консольToolStripMenuItem.Text = "Консоль";
            // 
            // AddLineButton
            // 
            this.AddLineButton.BackColor = System.Drawing.Color.Goldenrod;
            this.AddLineButton.Font = new System.Drawing.Font("Haettenschweiler", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddLineButton.ForeColor = System.Drawing.SystemColors.Control;
            this.AddLineButton.Location = new System.Drawing.Point(12, 446);
            this.AddLineButton.Name = "AddLineButton";
            this.AddLineButton.Size = new System.Drawing.Size(159, 66);
            this.AddLineButton.TabIndex = 2;
            this.AddLineButton.Text = "Добавить";
            this.AddLineButton.UseVisualStyleBackColor = false;
            this.AddLineButton.Click += new System.EventHandler(this.AddLineButton_Click);
            // 
            // ChangeButton
            // 
            this.ChangeButton.BackColor = System.Drawing.Color.Goldenrod;
            this.ChangeButton.Font = new System.Drawing.Font("Haettenschweiler", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChangeButton.ForeColor = System.Drawing.SystemColors.Control;
            this.ChangeButton.Location = new System.Drawing.Point(203, 446);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(159, 66);
            this.ChangeButton.TabIndex = 3;
            this.ChangeButton.Text = "Изменить";
            this.ChangeButton.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.SearchButton);
            this.panel1.Controls.Add(this.DeleteButton);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1046, 570);
            this.panel1.TabIndex = 4;
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.Goldenrod;
            this.SearchButton.Font = new System.Drawing.Font("Haettenschweiler", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SearchButton.ForeColor = System.Drawing.SystemColors.Control;
            this.SearchButton.Location = new System.Drawing.Point(579, 446);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(159, 66);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.Text = "Найти";
            this.SearchButton.UseVisualStyleBackColor = false;
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.Goldenrod;
            this.DeleteButton.Font = new System.Drawing.Font("Haettenschweiler", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DeleteButton.ForeColor = System.Drawing.SystemColors.Control;
            this.DeleteButton.Location = new System.Drawing.Point(393, 446);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(159, 66);
            this.DeleteButton.TabIndex = 0;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 555);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ChangeButton);
            this.Controls.Add(this.AddLineButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Охранное агентство";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem спраToolStripMenuItem;
        private ToolStripMenuItem справочникToolStripMenuItem;
        private ToolStripMenuItem разноеToolStripMenuItem;
        private ToolStripMenuItem AboutTheProgramToolStripMenuItem;
        private ToolStripMenuItem консольToolStripMenuItem;
        private ToolStripMenuItem StripMenuEmployee;
        private ToolStripMenuItem StripMenuEvents;
        private ToolStripMenuItem StripMenuCities;
        private ToolStripMenuItem StripMenuStreets;
        private ToolStripMenuItem StripMenuContracts;
        private ToolStripMenuItem StripMenuIndividualEntity;
        private ToolStripMenuItem StripMenuLegalEntity;
        private ToolStripMenuItem StripMenuOwners;
        private ToolStripMenuItem StripMenuJobs;
        private ToolStripMenuItem StripMenuObjects;
        private ToolStripMenuItem StripMenuPayments;
        private ToolStripMenuItem StripMenuSchedule;
        private ToolStripMenuItem StripMenuSpecialMeans;
        private ToolStripMenuItem StripMenuWeapon;
        private ToolStripMenuItem StripMenuWeaponBrand;
        private ToolStripMenuItem StripMenuUsers;
        private Button AddLineButton;
        private Button ChangeButton;
        private Panel panel1;
        private Button SearchButton;
        private Button DeleteButton;
    }
}