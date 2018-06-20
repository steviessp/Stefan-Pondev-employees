namespace LongestPeriod
{
    partial class LongestPeriod
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
            this.btn_LoadData = new System.Windows.Forms.Button();
            this.dgv_Employees = new System.Windows.Forms.DataGridView();
            this.EmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_LongestPeriod = new System.Windows.Forms.Button();
            this.dgv_TeamMates = new System.Windows.Forms.DataGridView();
            this.EmployeeID_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeID_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaysWorked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_dgv_TeamMates = new System.Windows.Forms.Label();
            this.lbl_dgv_Employees = new System.Windows.Forms.Label();
            this.btn_Clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Employees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TeamMates)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_LoadData
            // 
            this.btn_LoadData.Location = new System.Drawing.Point(13, 13);
            this.btn_LoadData.Name = "btn_LoadData";
            this.btn_LoadData.Size = new System.Drawing.Size(75, 25);
            this.btn_LoadData.TabIndex = 0;
            this.btn_LoadData.Text = "Load Data";
            this.btn_LoadData.UseVisualStyleBackColor = true;
            this.btn_LoadData.Click += new System.EventHandler(this.btn_LoadData_Click);
            // 
            // dgv_Employees
            // 
            this.dgv_Employees.AllowUserToDeleteRows = false;
            this.dgv_Employees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Employees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Employees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmpID,
            this.ProjectID,
            this.DateFrom,
            this.DateTo});
            this.dgv_Employees.Location = new System.Drawing.Point(13, 42);
            this.dgv_Employees.Name = "dgv_Employees";
            this.dgv_Employees.ReadOnly = true;
            this.dgv_Employees.Size = new System.Drawing.Size(759, 236);
            this.dgv_Employees.TabIndex = 1;
            // 
            // EmpID
            // 
            this.EmpID.HeaderText = "Employee ID";
            this.EmpID.Name = "EmpID";
            this.EmpID.ReadOnly = true;
            // 
            // ProjectID
            // 
            this.ProjectID.HeaderText = "Project ID";
            this.ProjectID.Name = "ProjectID";
            this.ProjectID.ReadOnly = true;
            // 
            // DateFrom
            // 
            this.DateFrom.HeaderText = "Date From";
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.ReadOnly = true;
            // 
            // DateTo
            // 
            this.DateTo.HeaderText = "Date To";
            this.DateTo.Name = "DateTo";
            this.DateTo.ReadOnly = true;
            // 
            // btn_LongestPeriod
            // 
            this.btn_LongestPeriod.Enabled = false;
            this.btn_LongestPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_LongestPeriod.Location = new System.Drawing.Point(12, 284);
            this.btn_LongestPeriod.Name = "btn_LongestPeriod";
            this.btn_LongestPeriod.Size = new System.Drawing.Size(141, 25);
            this.btn_LongestPeriod.TabIndex = 2;
            this.btn_LongestPeriod.Text = "Find Longest Period";
            this.btn_LongestPeriod.UseVisualStyleBackColor = true;
            this.btn_LongestPeriod.Click += new System.EventHandler(this.btn_LongestPeriod_Click);
            // 
            // dgv_TeamMates
            // 
            this.dgv_TeamMates.AllowUserToDeleteRows = false;
            this.dgv_TeamMates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_TeamMates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TeamMates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeID_1,
            this.EmployeeID_2,
            this.ProcID,
            this.DaysWorked});
            this.dgv_TeamMates.Location = new System.Drawing.Point(13, 315);
            this.dgv_TeamMates.Name = "dgv_TeamMates";
            this.dgv_TeamMates.ReadOnly = true;
            this.dgv_TeamMates.Size = new System.Drawing.Size(759, 213);
            this.dgv_TeamMates.TabIndex = 3;
            // 
            // EmployeeID_1
            // 
            this.EmployeeID_1.HeaderText = "EmployeeID 1";
            this.EmployeeID_1.Name = "EmployeeID_1";
            this.EmployeeID_1.ReadOnly = true;
            // 
            // EmployeeID_2
            // 
            this.EmployeeID_2.HeaderText = "EmployeeID 2";
            this.EmployeeID_2.Name = "EmployeeID_2";
            this.EmployeeID_2.ReadOnly = true;
            // 
            // ProcID
            // 
            this.ProcID.HeaderText = "Project ID";
            this.ProcID.Name = "ProcID";
            this.ProcID.ReadOnly = true;
            // 
            // DaysWorked
            // 
            this.DaysWorked.HeaderText = "Days worked";
            this.DaysWorked.Name = "DaysWorked";
            this.DaysWorked.ReadOnly = true;
            // 
            // lbl_dgv_TeamMates
            // 
            this.lbl_dgv_TeamMates.AutoSize = true;
            this.lbl_dgv_TeamMates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_dgv_TeamMates.Location = new System.Drawing.Point(234, 290);
            this.lbl_dgv_TeamMates.Name = "lbl_dgv_TeamMates";
            this.lbl_dgv_TeamMates.Size = new System.Drawing.Size(276, 13);
            this.lbl_dgv_TeamMates.TabIndex = 4;
            this.lbl_dgv_TeamMates.Text = "Teammates with longest period on same project";
            // 
            // lbl_dgv_Employees
            // 
            this.lbl_dgv_Employees.AutoSize = true;
            this.lbl_dgv_Employees.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_dgv_Employees.Location = new System.Drawing.Point(325, 19);
            this.lbl_dgv_Employees.Name = "lbl_dgv_Employees";
            this.lbl_dgv_Employees.Size = new System.Drawing.Size(105, 13);
            this.lbl_dgv_Employees.TabIndex = 5;
            this.lbl_dgv_Employees.Text = "List of employees";
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(697, 534);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 25);
            this.btn_Clear.TabIndex = 6;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // LongestPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.lbl_dgv_Employees);
            this.Controls.Add(this.lbl_dgv_TeamMates);
            this.Controls.Add(this.dgv_TeamMates);
            this.Controls.Add(this.btn_LongestPeriod);
            this.Controls.Add(this.dgv_Employees);
            this.Controls.Add(this.btn_LoadData);
            this.Name = "LongestPeriod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Longest Period";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LongestPeriod_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Employees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TeamMates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_LoadData;
        private System.Windows.Forms.DataGridView dgv_Employees;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTo;
        private System.Windows.Forms.Button btn_LongestPeriod;
        private System.Windows.Forms.DataGridView dgv_TeamMates;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaysWorked;
        private System.Windows.Forms.Label lbl_dgv_TeamMates;
        private System.Windows.Forms.Label lbl_dgv_Employees;
        private System.Windows.Forms.Button btn_Clear;
    }
}

