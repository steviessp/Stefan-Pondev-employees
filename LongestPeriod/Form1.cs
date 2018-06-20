using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LongestPeriod
{
    public partial class LongestPeriod : Form
    {
        OpenFileDialog openFileDialog;

        public struct Employee
        {
            uint _empID { get; }
            uint _projectID { get; }
            DateTime _dateFrom { get; }
            DateTime _dateTo { get; }
            double _daysOnProject { get; }

            public Employee(uint empID, uint projectID, DateTime dateFrom, DateTime dateTo)
            {
                _empID = empID;
                _projectID = projectID;
                _dateFrom = dateFrom;
                _dateTo = dateTo;

                _daysOnProject = (_dateTo - _dateFrom).TotalDays;
            }

            public uint EmpID
            {
                get { return _empID; }
            }

            public uint ProjectID
            {
                get { return _projectID; }
            }

            public DateTime DateFrom
            {
                get { return _dateFrom; }
            }

            public DateTime DateTo
            {
                get { return _dateTo; }
            }

            public double DaysOnProject

            {
                get { return _daysOnProject; }
            }
        }

        List<Employee> employees;

        public LongestPeriod()
        {
            InitializeComponent();
        }

        private void btn_LoadData_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();           
            openFileDialog.Filter = "txt files (*.txt)|*.txt|CSV files (*.csv)|*.csv";           
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                employees = new List<Employee>();

                try
                {
                    System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog.FileName);
                    string newline;
                    dgv_Employees.ColumnCount = 4;
                    dgv_Employees.Columns[0].Name = "EmpID";
                    dgv_Employees.Columns[1].Name = "ProjectID";
                    dgv_Employees.Columns[2].Name = "DateFrom";
                    dgv_Employees.Columns[3].Name = "DateTo";


                    while ((newline = file.ReadLine()) != null)
                    {
                        try
                        {
                            Employee anEmployee;
                            string[] values = newline.Split(',');
                            uint eID = Convert.ToUInt32(values[0]);
                            uint pID = Convert.ToUInt32(values[1]);
                            DateTime dFrom = DateTime.Parse(values[2]);
                            DateTime dTo = ((values[3].Trim() == "NULL") || (values[3].Trim() == "null")) ? DateTime.Now : DateTime.Parse(values[3]);
                            if ((eID != 0) && (pID != 0) && (dFrom != null) && (dTo != null))
                            {
                                anEmployee = new Employee(eID, pID, dFrom, dTo);
                                employees.Add(anEmployee);
                            }
                            dgv_Employees.Rows.Add(eID, pID, dFrom, dTo);
                        }
                        catch (System.FormatException formatEx)
                        {
                            MessageBox.Show(this, formatEx.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                        catch (System.OverflowException overFlowEx)
                        {
                            MessageBox.Show(this, overFlowEx.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                    }

                    file.Close();
                    btn_LoadData.Enabled = false;
                    btn_LongestPeriod.Enabled = true;
                }
                catch (OutOfMemoryException omEx) { MessageBox.Show(this, omEx.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                catch (System.IO.IOException ioEx) { MessageBox.Show(this, ioEx.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btn_LongestPeriod_Click(object sender, EventArgs e)
        {
            var projects = employees
                .GroupBy(pr => pr.ProjectID)                
                .Select(g => g.First());

            foreach (Employee prj_emp in projects)
            {

                var team = employees
                    .Where(prid => prid.ProjectID == prj_emp.ProjectID)
                    .OrderByDescending(dP => dP.DaysOnProject)
                    .Take(2);

                if (team.Count() > 1)
                {
                    dgv_TeamMates.Rows.Add(team.First().EmpID, team.Last().EmpID, team.First().ProjectID, Convert.ToUInt32(team.Last().DaysOnProject));
                }
            }           
            dgv_TeamMates.Sort(dgv_TeamMates.Columns["DaysWorked"], ListSortDirection.Descending);             
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            dgv_Employees.Rows.Clear();
            dgv_Employees.Refresh(); 
            dgv_TeamMates.Rows.Clear();
            dgv_TeamMates.Refresh();
            btn_LoadData.Enabled = true;
            btn_LongestPeriod.Enabled = false; 
        }

       
        private void LongestPeriod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, "Confirm exit?", "CONFIRM", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                e.Cancel = true;
        }
    }
}
