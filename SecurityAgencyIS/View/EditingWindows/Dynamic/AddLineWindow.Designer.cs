namespace SecurityAgencyIS.View.EditingWindows
{
    partial class AddLineWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddValuesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddValuesButton
            // 
            this.AddValuesButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddValuesButton.Location = new System.Drawing.Point(263, 380);
            this.AddValuesButton.Name = "AddValuesButton";
            this.AddValuesButton.Size = new System.Drawing.Size(235, 58);
            this.AddValuesButton.TabIndex = 0;
            this.AddValuesButton.Text = "Добавить";
            this.AddValuesButton.UseVisualStyleBackColor = true;
            this.AddValuesButton.Click += new System.EventHandler(this.AddValuesButton_Click);
            // 
            // AddLineWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddValuesButton);
            this.Name = "AddLineWindow";
            this.Text = "EmployeeAdd";
            this.ResumeLayout(false);

        }

        #endregion

        private Button AddValuesButton;
    }
}