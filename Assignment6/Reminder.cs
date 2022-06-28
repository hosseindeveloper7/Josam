using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment6.Models;
using Assignment6.Services;

namespace Assignment6
{
    public partial class Reminder : Form
    {

        //declaration for the TaskManager class
        TaskManager taskManager = new TaskManager();

        public Reminder()
        {
            InitializeComponent();
            InitializeGUI();
        }


        //method to set the combo box, datetime picker and text box with the defualt values.
        //the text box will be empty
        private void InitializeGUI()
        {
            cmbPriority.Items.AddRange(Enum.GetNames(typeof(PriorityType)));
            cmbPriority.SelectedIndex = (int)PriorityType.Normal;
            dateTimePicker1.Value = DateTime.Now;
            tbxDescription.Text = string.Empty;
        }


        //method to read all data from user
        private TaskInfo ReadInput()
        {
            TaskInfo taskInfo = new TaskInfo();

            taskInfo.Description = ReadDescription();
            taskInfo.DateTime = ReadDateTime();
            taskInfo.Priority = ReadPriority();

            return taskInfo;
        }


        //read date and time from DateTimePicker
        private DateTime ReadDateTime()
        {
            return dateTimePicker1.Value;
        }


        //read description from text box
        private string ReadDescription()
        {
            return tbxDescription.Text;
        }


        //read priority type from combo box
        private PriorityType ReadPriority()
        {
            PriorityType priority = PriorityType.Normal;
            priority = (PriorityType)cmbPriority.SelectedIndex;

            return priority;
        }


        //give message to the user
        private void GiveMessage(string v)
        {
            MessageBox.Show(v, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        //to update the form components after every action
        private void UpdateGUI()
        {
            listBox.Items.Clear();
            listBox.Items.AddRange(taskManager.GetTasksStringArray());

            tbxDescription.Text = string.Empty;
            cmbPriority.SelectedIndex = (int)PriorityType.Normal;
            dateTimePicker1.Value = DateTime.Now;

            btnChange.Enabled = false;
            btnDelete.Enabled = false;

        }


        //to create a new file (new page)
        private void newCtrlNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewFile();
        }


        //to clear the list box and the list of tasks
        private void CreateNewFile()
        {
            listBox.Items.Clear();
            tbxDescription.Text = string.Empty;
            taskManager.ClearList();
        }


        //to add a task to the list and then to the list box
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbxDescription.Text))
            {
                TaskInfo taskInfo = ReadInput();
                if (taskManager.AddTask(taskInfo))
                    UpdateGUI();
            }
            else
            {
                GiveMessage("Write a description fot the task!");
            }
        }


        //to change the information av a task on the list box
        private void btnChange_Click_1(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;

            if (index >= 0)
            {
                if (!string.IsNullOrWhiteSpace(tbxDescription.Text))
                {
                    TaskInfo taskInfo = ReadInput();
                    taskManager.ChangeTask(taskInfo, index);
                    UpdateGUI();
                }
                else
                {
                    GiveMessage("Write a description fot the task you want to change!");
                }
            }
            else
            {
                if (listBox.Items.Count == 0)
                    GiveMessage("There is no task in the list.");
                else
                    GiveMessage("Select a task!");
            }
        }


        //to delete an item (task) from the list box
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;

            if (index >= 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Sure to delete??", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    taskManager.DeleteTask(index);
                    UpdateGUI();
                }
            }
            else
            {
                if (listBox.Items.Count == 0)
                    GiveMessage("There is no task in the list.");

                else
                    GiveMessage("Select a task!");
            }
        }


        //to select an item (task) from the list box
        private void listBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex < 0)
                return;

            TaskInfo taskInfo = taskManager.GetTaskToChange(listBox.SelectedIndex);
            tbxDescription.Text = taskInfo.Description;
            dateTimePicker1.Value = taskInfo.DateTime;
            cmbPriority.SelectedIndex = (int)taskInfo.Priority;
            btnChange.Enabled = true;
            btnDelete.Enabled = true;
        }


        //shows the current time
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }


        //to exit the program
        private void exitAltF4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Sure to close the program??", "Confirmation"
                , MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
            {
                Application.Exit();
            }
        }


        //to show tooltip on date time picker box (mouse hover)
        private void dateTimePicker1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Click to open calender for date, write in time here.", dateTimePicker1);
        }


        //to show tooltip on combobox (mouse hover)
        private void cmbPriority_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Click to select a priority for your task.", cmbPriority);
        }


        //to show information about the app
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 myAboutBox = new AboutBox1();
            myAboutBox.ShowDialog();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
