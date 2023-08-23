using PROG6212Task1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

namespace PROG6212Task1WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> listOutput = new List<string>(); //***MIGHT HAVE TO CHANGE TO OBJECT***
        //Starting data , does not matter if its in a text file 
        List<ModuleDetails> testData = new List<ModuleDetails>();
        public MainWindow()
        {
            InitializeComponent();
            ViewList();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {   //to check that all fields have been filled before being added
                if (txtModuleCode.Text.Length==0 || txtModuleName.Text.Length==0 || txtCredits.Text.Length==0 || txtClassHours.Text.Length==0 || txtWeeks.Text.Length==0 || txtStartDate.Text.Length==0)
                {
                    MessageBox.Show("Please fill in all fields!", "Empty Fields Error");
                }
                else
                {
                    testData.Add(new ModuleDetails(txtModuleCode.Text,
                                                   txtModuleName.Text,
                                                   Convert.ToInt32(txtCredits.Text),
                                                   Convert.ToInt32(txtClassHours.Text),
                                                   Convert.ToInt32(txtWeeks.Text),
                                                   txtStartDate.Text));
                }
                MessageBox.Show("User has been added successfully", "Add User");

            }
            catch (Exception)
            {
                MessageBox.Show("An error has occured please try again", "error");
            }

            txtModuleCode.Clear();
            txtModuleName.Clear();
            txtCredits.Clear();
            txtClassHours.Clear();
            txtWeeks.Clear();
            txtStartDate.Clear();

            UpdateData();
            ViewList();
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e) 
        {
            try
            {
                string strModuleCode = txtSearch.Text;              
                ModuleDetails[] Search = testData.Where(x => x.ModuleCode1==strModuleCode).ToArray();

                ViewList(Search);
            }
            catch (Exception ex)
            {
                ViewList();
            }
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int Selected = lstOutput.SelectedIndex;
            testData[Selected].ModuleCode1 = txtName.Text;
            testData[Selected].ModuleName1 = Convert.ToInt32(txtID.Text);
        }
        public void ViewList()
        {
            listOutput.Clear(); //Clears the List

            List<ModuleDetails> Sortme = testData.OrderBy(e => e.ModuleCode1).ToList(); //Orders List by Module Code
            testData = Sortme;

            foreach (ModuleDetails ModuleDetails in Sortme) //**MIGHT HAVE TO CHANGE THE SECOND MODULES SLIGHTLY
            {
                String strOutput = "Module Code: " + ModuleDetails.ModuleCode1 + "\n" +
                                   "Module Name: " + ModuleDetails.ModuleName1 + "\n" +
                                   "Module Credits: " + ModuleDetails.ICredits + "\n" +
                                   "Class hours per week: " + ModuleDetails.IClassHours + "\n" +
                                   "Number of weeks in the Semester: " + ModuleDetails.IWeeks + "\n" +
                                   "Start date for the first week of the semester: " + ModuleDetails.StartDate1;
                listOutput.Add(strOutput); //Adds to the array
            }

            lstOutput.ItemsSource = null;
            lstOutput.ItemsSource = listOutput;
        }
        public void ViewList(ModuleDetails[] inputData)
        {
            listOutput.Clear();
            List<ModuleDetails> Sortme = inputData.OrderBy(e => e.ModuleCode1).ToList(); //Orders the list by Module Code
            testData = Sortme;
            foreach (ModuleDetails ModuleDetails in Sortme)
            {
                String strOutput = "Module Code: " + ModuleDetails.ModuleCode1 + "\n" +
                                  "Module Name: " + ModuleDetails.ModuleName1 + "\n" +
                                  "Module Credits: " + ModuleDetails.ICredits + "\n" +
                                  "Class hours per week: " + ModuleDetails.IClassHours + "\n" +
                                  "Number of weeks in the Semester: " + ModuleDetails.IWeeks + "\n" +
                                  "Start date for the first week of the semester: " + ModuleDetails.StartDate1;
                listOutput.Add(strOutput);
            }

            lstOutput.ItemsSource = null;
            lstOutput.ItemsSource = listOutput;
        }

        private void ReadData()
        {
            String TextFile = "ModuleDetail.txt";

            if (File.Exists(TextFile))
            {
                testData.Clear();
                // Read file using StreamReader. Reads file line by line  
                using (StreamReader file = new StreamReader(TextFile))
                {
                    string ln;

                    while ((ln = file.ReadLine()) != null)
                    {
                        String strModuleCode = ln;
                        String strModuleName = file.ReadLine();
                        int intCredits = file.Read();
                        int intClassHours = file.Read();
                        int intWeeks = file.Read();
                        String strStartDate = file.ReadLine();

                        testData.Add(new ModuleDetails(strModuleCode, strModuleName,
                                    Convert.ToInt32(intCredits), Convert.ToInt32(intClassHours),
                                    Convert.ToInt32(intWeeks), strStartDate));
                    }
                    file.Close();
                }
            }
            else
            {
                List<ModuleDetails> AddData = new List<ModuleDetails> //Adding data
                {
                    new ModuleDetails("PROG6212","Programming 2A", 15, 150, 10, "25/07/2022" ) ,
                    new ModuleDetails("DATA6222","Database Intermediate", 10, 100, 5, "25/07/2022" ) ,
                    new ModuleDetails("HCIN6222","Human Computer Interaction", 10, 100, 5, "25/07/2022" )
                };

                using (StreamWriter sw = File.AppendText(@TextFile))
                {
                    foreach (ModuleDetails ModuleDetails in AddData)
                    {
                        sw.WriteLine(ModuleDetails.ModuleCode1);
                        sw.WriteLine(ModuleDetails.ModuleName1);
                        sw.WriteLine(ModuleDetails.ICredits);
                        sw.WriteLine(ModuleDetails.IClassHours);
                        sw.WriteLine(ModuleDetails.IWeeks);
                        sw.WriteLine(ModuleDetails.StartDate1);
                    }
                    sw.Close();
                }
                ReadData();
            }
        }
        private void UpdateData()
        {
            String TextFile = "ModuleDetail.txt";
            File.Delete(TextFile);
            using (StreamWriter sw = File.AppendText(@TextFile))
            {
                foreach (ModuleDetails ModuleDetails in testData)
                {
                    sw.WriteLine(ModuleDetails.ModuleCode1);
                    sw.WriteLine(ModuleDetails.ModuleName1);
                    sw.WriteLine(ModuleDetails.ICredits);
                    sw.WriteLine(ModuleDetails.IClassHours);
                    sw.WriteLine(ModuleDetails.IWeeks);
                    sw.WriteLine(ModuleDetails.StartDate1);
                }
            }
            ReadData();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lstOutput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int Selected = lstOutput.SelectedIndex;
            String strModuleCode = testData[Selected].ModuleCode1;
            String strModuleName = testData[Selected].ModuleName1+ "";
            int intCredits = testData[Selected].ICredits;
            int intClassHours = testData[Selected].IClassHours;
            int intWeeks = testData[Selected].IWeeks;
            String strStartDate = testData[Selected].StartDate1;

            //once you click on a specific entry on the listbox it will put the data back into the textbox
            txtModuleCode.Text = strModuleCode;
            txtModuleName.Text = strModuleName;
            txtCredits.Text = intCredits+"";
            txtClassHours.Text = intClassHours+"";
            txtWeeks.Text = intWeeks+"";
            txtStartDate.Text = strStartDate;

        }
    }
}
