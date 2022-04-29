using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
//using Microsoft.EntityFrameworkCore;

namespace TestTaskBGL
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbStatus.Text = "Ready";
        }

        private void ClearInput_Click(object sender, RoutedEventArgs e)
        {
            this.tBoxCN.Text = null;
            this.tBoxCId.Text = null;
            this.tBoxDepN.Text = null;
            this.tBoxDepId.Text = null;
            this.tBoxPosN.Text = null;
            this.tBoxPosId.Text = null;
            this.tBoxSurName.Text = null;
            this.tBoxName.Text = null;
            this.tBoxPatronymic.Text = null;
            this.tBoxAddress.Text = null;
            this.tBoxPhone.Text = null;
        }

        private void ClearOutput_Click(object sender, RoutedEventArgs e)
        {
            this.dataComp.ItemsSource = null;
            this.dataDep.ItemsSource = null;
            this.dataPos.ItemsSource = null;
            this.dataEmp.ItemsSource = null;
            this.dataResult.ItemsSource = null;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Owner = this;
            about.ShowDialog();
        }

        private void AddCompany_Click(object sender, RoutedEventArgs e)
        {
            using(test_task_bgldbContext db = new test_task_bgldbContext())
            {
                if (tBoxCN.Text.Length > 0)
                {
                    var newCompany = new Company
                    {
                        CompanyName = tBoxCN.Text
                    };
                    db.Companies.Add(newCompany);
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Fill in the empty field(s)");
                }
            }
        }

        private void DeleteCompany_Click(object sender, RoutedEventArgs e)
        {
            using (test_task_bgldbContext db = new test_task_bgldbContext())
            {
                Company company = (Company)dataComp.SelectedItem;
                db.Companies.Remove(company);
                db.SaveChanges();
            }
        }

        private void OutputCompany_Click(object sender, RoutedEventArgs e)
        {
            tabItem1.Focus();
            using (test_task_bgldbContext db = new test_task_bgldbContext())
            {
                dataComp.ItemsSource = db.Companies.ToList();
            }
        }

        private void UpdateCompany_Click(object sender, RoutedEventArgs e)
        {
            using (test_task_bgldbContext db = new test_task_bgldbContext())
            {
                Company company = (Company)dataComp.SelectedItem;
                db.Companies.Update(company);
                db.SaveChanges();
            }
        }

        private void AddDepartment_Click(object sender, RoutedEventArgs e)
        {
            using (test_task_bgldbContext db = new test_task_bgldbContext())
            {
                if (tBoxDepN.Text.Length > 0)
                {
                    string inputCId = tBoxCId.Text;
                    string pattern = @"\d";
                    if (Regex.IsMatch(inputCId, pattern))
                    {
                        var newDepartment = new Department
                        {
                            CompanyId = Convert.ToInt32(inputCId),
                            DepartmentName = tBoxDepN.Text
                        };
                        db.Departments.Add(newDepartment);
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show($"This is not a valid ID: {inputCId}");
                    }
                }
                else
                {
                    MessageBox.Show("Fill in the empty field(s)");
                }
            }
        }

        private void DeleteDepartment_Click(object sender, RoutedEventArgs e)
        {
            using (test_task_bgldbContext db = new test_task_bgldbContext())
            {
                Department department = (Department)dataDep.SelectedItem;
                db.Departments.Remove(department);
                db.SaveChanges();
            }
        }

        private void OutputDepartment_Click(object sender, RoutedEventArgs e)
        {
            tabItem2.Focus();
            using (test_task_bgldbContext db = new test_task_bgldbContext())
            {
                dataDep.ItemsSource = db.Departments.ToList();
            }
        }

        private void UpdateDepartment_Click(object sender, RoutedEventArgs e)
        {
            using (test_task_bgldbContext db = new test_task_bgldbContext())
            {
                Department department = (Department)dataDep.SelectedItem;
                db.Departments.Update(department);
                db.SaveChanges();
            }
        }

        private void AddPosition_Click(object sender, RoutedEventArgs e)
        {
            using (test_task_bgldbContext db = new test_task_bgldbContext())
            {
                if (tBoxPosN.Text.Length > 0)
                {
                    string inputDId = tBoxDepId.Text;
                    string pattern = @"\d";
                    if (Regex.IsMatch(inputDId, pattern))
                    {
                        var newPosition = new Position
                        {
                            DepartmentId = Convert.ToInt32(inputDId),
                            PositionName = tBoxPosN.Text
                        };
                        db.Positions.Add(newPosition);
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show($"This is not a valid ID: {inputDId}");
                    }
                }
                else
                {
                    MessageBox.Show("Fill in the empty field(s)");
                }
            }
        }

        private void Deleteposition_Click(object sender, RoutedEventArgs e)
        {
            using (test_task_bgldbContext db = new test_task_bgldbContext())
            {
                Position position = (Position)dataPos.SelectedItem;
                db.Positions.Remove(position);
                db.SaveChanges();
            }
        }

        private void OutputPosition_Click(object sender, RoutedEventArgs e)
        {
            tabItem3.Focus();
            using (test_task_bgldbContext db = new test_task_bgldbContext())
            {
                dataPos.ItemsSource = db.Positions.ToList();
            }
        }

        private void UpdatePosition_Click(object sender, RoutedEventArgs e)
        {
            using (test_task_bgldbContext db = new test_task_bgldbContext())
            {
                Position position = (Position)dataPos.SelectedItem;
                db.Positions.Update(position);
                db.SaveChanges();
            }
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            using (test_task_bgldbContext db = new test_task_bgldbContext())
            {
                if (tBoxSurName.Text.Length > 0 & tBoxName.Text.Length > 0 & tBoxPatronymic.Text.Length > 0 & tBoxAddress.Text.Length > 0 & tBoxPhone.Text.Length > 0)
                {
                    string inputPId = tBoxPosId.Text;
                    string pattern = @"\d";
                    if (Regex.IsMatch(inputPId, pattern))
                    {
                        var newEmployee = new Employee
                        {
                            PositionId = Convert.ToInt32(inputPId),
                            EmpSurname = tBoxSurName.Text,
                            EmpName = tBoxName.Text,
                            EmpPatronymic = tBoxPatronymic.Text,
                            Address = tBoxAddress.Text,
                            Phone = tBoxPhone.Text
                        };
                        db.Employees.Add(newEmployee);
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show($"This is not a valid ID: {inputPId}");
                    }
                }
                else
                {
                    MessageBox.Show("Fill in the empty field(s)");
                }
            }
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            using (test_task_bgldbContext db = new test_task_bgldbContext())
            {
                Employee employee = (Employee)dataEmp.SelectedItem;
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
        }

        private void OutputEmployee_Click(object sender, RoutedEventArgs e)
        {
            tabItem4.Focus();
            using (test_task_bgldbContext db = new test_task_bgldbContext())
            {
                dataEmp.ItemsSource = db.Employees.ToList();
            }
        }

        private void UpdateEmployee_Click(object sender, RoutedEventArgs e)
        {
            using (test_task_bgldbContext db = new test_task_bgldbContext())
            {
                Employee employee = (Employee)dataEmp.SelectedItem;
                db.Employees.Update(employee);
                db.SaveChanges();
            }
        }

        private void ListEmpDep_Click(object sender, RoutedEventArgs e)
        {
            tabItem5.Focus();
            using (test_task_bgldbContext db = new test_task_bgldbContext())
            {
                var listEmpDep = from c in db.Companies
                                 join d in db.Departments on c.CompanyId equals d.CompanyId
                                 join p in db.Positions on d.DepartmentId equals p.DepartmentId
                                 join emp in db.Employees on p.PositionId equals emp.PositionId
                                 select new 
                                 {
                                    Company = c.CompanyName,
                                    Department = d.DepartmentName,
                                    Position = p.PositionName,
                                    Surname = emp.EmpSurname,
                                    Name = emp.EmpName,
                                    Patronymic = emp.EmpPatronymic
                                 };
                dataResult.ItemsSource = listEmpDep.ToList();
            }
        }

        private void GeneralList_Click(object sender, RoutedEventArgs e)
        {
            tabItem5.Focus();
            using (test_task_bgldbContext db = new test_task_bgldbContext())
            {
                var genListEmp = from c in db.Companies
                                 join d in db.Departments on c.CompanyId equals d.CompanyId
                                 join p in db.Positions on d.DepartmentId equals p.DepartmentId
                                 join emp in db.Employees on p.PositionId equals emp.PositionId
                                 select new
                                 {
                                     Company = c.CompanyName,
                                     Surname = emp.EmpSurname,
                                     Name = emp.EmpName,
                                     Patronymic = emp.EmpPatronymic
                                 };
                dataResult.ItemsSource = genListEmp.ToList();
            }
        }

        private void ExportCSV_Click(object sender, RoutedEventArgs e)
        {
            if (dataComp.ItemsSource != null & dataDep.ItemsSource != null & dataPos.ItemsSource != null & dataEmp.ItemsSource != null & dataResult.ItemsSource != null)
            {
                this.dataComp.SelectAllCells();
                this.dataComp.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, this.dataComp);
                this.dataComp.UnselectAllCells();
                String result1 = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);

                this.dataDep.SelectAllCells();
                this.dataDep.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, this.dataDep);
                this.dataDep.UnselectAllCells();
                String result2 = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);

                this.dataPos.SelectAllCells();
                this.dataPos.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, this.dataPos);
                this.dataPos.UnselectAllCells();
                String result3 = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);

                this.dataEmp.SelectAllCells();
                this.dataEmp.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, this.dataEmp);
                this.dataEmp.UnselectAllCells();
                String result4 = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);

                this.dataResult.SelectAllCells();
                this.dataResult.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, this.dataResult);
                this.dataResult.UnselectAllCells();
                String result5 = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
                try
                {
                    StreamWriter sw = new StreamWriter("ExportData.csv", false, System.Text.Encoding.UTF8);
                    sw.WriteLine(result1);
                    sw.WriteLine(result2);
                    sw.WriteLine(result3);
                    sw.WriteLine(result4);
                    sw.WriteLine(result5);
                    sw.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
