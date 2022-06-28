using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment6.Models;

namespace Assignment6.Services
{
    public class TaskManager
    {
        private List<TaskInfo> _taskList; // declaration of a list with TaskInfo objects as items

        /// <summary>
        /// Constructor for the TaskManager class
        /// </summary>
        public TaskManager()
        {
            _taskList = new List<TaskInfo>();
        }


        /// <summary>
        /// Adds the object task to the list
        /// </summary>
        /// <param name="task"></param>
        /// <returns>bool</returns>
        public bool AddTask(TaskInfo task)
        {
            bool success = false;

            if (task != null)
            {
                _taskList.Add(task);
                success = true;
            }
            return success;
        }


        /// <summary>
        /// Adds every items in a list to the string array
        /// </summary>
        /// <returns>string[]</returns>
        public string[] GetTasksStringArray()
        {
            string[] taskStringArray = new string[_taskList.Count];

            int i = 0;
            foreach (TaskInfo taskInfo in _taskList)
            {
                taskStringArray[i] = taskInfo.ToString();
                i++;
            }
            return taskStringArray;
        }

        /// <summary>
        /// Changes the object taskInfo in the list
        /// </summary>
        /// <param name="taskInfo"></param>
        /// <param name="index"></param>
        /// <returns>bool</returns>
        public bool ChangeTask(TaskInfo taskInfo, int index)
        {
            bool success = false;

            if (index >= 0 && index < _taskList.Count)
            {
                success = true;
                _taskList[index] = taskInfo;
            }
            return success;
        }


        /// <summary>
        /// Gives the object with index index from the list
        /// </summary>
        /// <param name="index"></param>
        /// <returns>TaskInfo</returns>
        public TaskInfo GetTaskToChange(int index)
        {
            if (!(index >= 0 && index < _taskList.Count))
                return null;

            return _taskList[index];
        }


        /// <summary>
        /// Deletes an object from the list
        /// </summary>
        /// <param name="index"></param>
        /// <returns>bool</returns>
        public bool DeleteTask(int index)
        {
            bool success = false;

            if (index >= 0 && index < _taskList.Count)
            {
                _taskList.RemoveAt(index);
                success = true;
            }
            return success;
        }


        //to clear the list
        public void ClearList()
        {
            _taskList.Clear();
        }
    }
}
