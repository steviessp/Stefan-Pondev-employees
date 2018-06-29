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
            uint _id { get; }
            uint _empID { get; }
            uint _projectID { get; }
            DateTime _dateFrom { get; }
            DateTime _dateTo { get; }
            double _daysOnProject { get; }

            public Employee(uint id, uint empID, uint projectID, DateTime dateFrom, DateTime dateTo)
            {
                _id = id;
                _empID = empID;
                _projectID = projectID;
                _dateFrom = dateFrom;
                _dateTo = dateTo;

                _daysOnProject = (_dateTo - _dateFrom).TotalDays;
            }

            public uint ID
            {
                get { return _id; }
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

        public struct Team
        {
            uint _id { get; set; }
            uint _empID1 { get; set; }
            uint _empID2 { get; set; }
            uint _projectID { get; set; }
            public double _daysOnProject { get; set; }

            public uint ID
            {
                get { return _id; }
                set { _id = value; }
            }

            public uint EmpID1
            {
                get { return _empID1; }
                set { _empID1 = value; }
            }

            public uint EmpID2
            {
                get { return _empID2; }
                set { _empID2 = value; }
            }

            public uint ProjectID
            {
                get { return _projectID; }
                set { _projectID = value; }
            }

            public double DaysOnProject

            {
                get { return _daysOnProject; }
                set { _daysOnProject = value; }
            }

            public void SumDays(double days)
            {
                _daysOnProject += days;
            }
        }

        List<Employee> employees;
        List<Team> workTeams;

        public LongestPeriod()
        {
            InitializeComponent();
        }

        private void btn_LoadData_Click(object sender, EventArgs e)
        {
            uint index = 0;
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
                                anEmployee = new Employee(index, eID, pID, dFrom, dTo);
                                employees.Add(anEmployee);
                                dgv_Employees.Rows.Add(eID, pID, dFrom, dTo);
                                index++;
                            }
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

        private double GetOverLapping(Employee emp1, Employee emp2)
        {
            DateTime dateTo, dateFrom;
            dateTo = (emp1.DateTo.CompareTo(emp2.DateTo) <= 0) ? emp1.DateTo : emp2.DateTo;
            dateFrom = (emp1.DateFrom.CompareTo(emp2.DateFrom) >= 0) ? emp1.DateFrom : emp2.DateFrom;

            return (dateTo.CompareTo(dateFrom) > 0) ? (dateTo - dateFrom).TotalDays : 0;
        }

        private void btn_LongestPeriod_Click(object sender, EventArgs e)
        {
            var teamMates = new List<Employee>();
            workTeams = new List<Team>();
            var longestWorkTeams = new List<Team>();
            Team workTeam;
            uint workTeamIndex = 0;
            int listIndex = 0;

            dgv_TeamMates.Rows.Clear();
            dgv_TeamMates.Refresh();
            dgv_LongestPeriod.Rows.Clear();
            dgv_LongestPeriod.Refresh();
            btn_LongestPeriod.Enabled = false;

            //Get teams by project and overlapping date
            foreach (Employee emp in employees)
            {
                foreach (Employee emp2 in employees.Where(id => id.ID > emp.ID))
                {
                    if (emp.EmpID != emp2.EmpID &&
                        emp.ProjectID == emp2.ProjectID)
                    {
                        double overlapping = GetOverLapping(emp, emp2);
                        if (overlapping > 0)
                        {
                            Team newTeam = new Team()
                            {
                                EmpID1 = emp.EmpID <= emp2.EmpID ? emp.EmpID : emp2.EmpID,
                                EmpID2 = emp2.EmpID >= emp.EmpID ? emp2.EmpID : emp.EmpID,
                                ProjectID = emp.ProjectID,
                                DaysOnProject = overlapping
                            };

                            listIndex = workTeams.FindIndex(w => w.EmpID1 == newTeam.EmpID1 &&
                                    w.EmpID2 == newTeam.EmpID2 &&
                                    w.ProjectID == newTeam.ProjectID);

                            if (listIndex < 0)
                            {
                                newTeam.ID = workTeamIndex;
                                workTeams.Add(newTeam);
                                workTeamIndex++;
                            }
                            else
                            {
                                workTeam = workTeams[listIndex];
                                workTeam.SumDays(newTeam.DaysOnProject);
                                workTeams[listIndex] = workTeam;
                            }
                        }
                    }
                }
            }
            workTeamIndex = 0;
            //Get Longest work team summing the periods of equal couple
            foreach (Team tm in workTeams)
            {
                if (longestWorkTeams.FindIndex(w => w.EmpID1 == tm.EmpID1 &&
                                w.EmpID2 == tm.EmpID2) < 0)
                {
                    foreach (Team tm2 in workTeams.Where(id => id.ID > tm.ID))
                    {
                        if (tm.EmpID1 == tm2.EmpID1 &&
                            tm.EmpID2 == tm2.EmpID2)
                        {
                            Team newTeam = new Team()
                            {
                                EmpID1 = tm.EmpID1,
                                EmpID2 = tm.EmpID2,
                                DaysOnProject = tm2.DaysOnProject
                            };

                            listIndex = longestWorkTeams.FindIndex(w => w.EmpID1 == newTeam.EmpID1 &&
                                    w.EmpID2 == newTeam.EmpID2);

                            if (listIndex < 0)
                            {
                                newTeam.ID = workTeamIndex;
                                newTeam.SumDays(tm.DaysOnProject);
                                longestWorkTeams.Add(newTeam);
                                workTeamIndex++;
                            }
                            else
                            {
                                workTeam = longestWorkTeams[listIndex];
                                workTeam.SumDays(newTeam.DaysOnProject);
                                longestWorkTeams[listIndex] = workTeam;
                            }
                        }
                    }
                    listIndex = longestWorkTeams.FindIndex(w => w.EmpID1 == tm.EmpID1 &&
                                    w.EmpID2 == tm.EmpID2);
                    if (listIndex < 0)
                    {
                        Team newTeam = new Team()
                        {
                            EmpID1 = tm.EmpID1,
                            EmpID2 = tm.EmpID2,
                            DaysOnProject = tm.DaysOnProject
                        };
                        newTeam.ID = workTeamIndex;
                        longestWorkTeams.Add(newTeam);
                        workTeamIndex++;
                    }
                }
            }

            foreach (Team aTeam in workTeams.OrderByDescending(o => o.DaysOnProject))
                dgv_TeamMates.Rows.Add(aTeam.EmpID1, aTeam.EmpID2, aTeam.ProjectID, Convert.ToUInt32(aTeam.DaysOnProject));

            foreach (Team theTeam in longestWorkTeams.OrderByDescending(o => o.DaysOnProject).Take(1))
                dgv_LongestPeriod.Rows.Add(theTeam.EmpID1, theTeam.EmpID2, Convert.ToUInt32(theTeam.DaysOnProject)); 
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            dgv_Employees.Rows.Clear();
            dgv_Employees.Refresh();
            dgv_TeamMates.Rows.Clear();
            dgv_TeamMates.Refresh();
            dgv_LongestPeriod.Rows.Clear();
            dgv_LongestPeriod.Refresh();
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
