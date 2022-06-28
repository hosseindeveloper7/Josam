using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6.Models
{
    public class TaskInfo
    {
        private DateTime _dateTime; // Datetime variable to save date and time
        private string _description; // string variable to save a description for a task
        private PriorityType _priority; // Enum variable to save a type of priority

        /// <summary>
        /// Constructor with 3 parameter for the class TaskInfo
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="description"></param>
        /// <param name="priority"></param>
        public TaskInfo(DateTime dateTime, string description, PriorityType priority)
        {
            _dateTime = dateTime;
            _description = description;
            _priority = priority;
        }

        /// <summary>
        /// Constructor without parameter
        /// </summary>
        public TaskInfo()
        {

        }

        /// <summary>
        /// convert priority type to string
        /// </summary>
        /// <returns>string</returns>
        public string GetPriorityString()
        {
            return _priority.ToString();
        }

        /// <summary>
        /// Convert time to string
        /// </summary>
        /// <returns>string</returns>
        public string GetTimeString()
        {
            return _dateTime.ToString("HH:mm");
            //return _dateTime.ToShortTimeString();
            
        }

        /// <summary>
        /// Convert date to string
        /// </summary>
        /// <returns>string</returns>
        public string GetDateString()
        {
            return _dateTime.ToString("yyyy-MM-dd");
            //return _dateTime.ToShortDateString();
        }

        /// <summary>
        /// Convert the object to string
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return $"{GetDateString(),-15}" +
                   $"{GetTimeString(),-17}" +
                   $"{GetPriorityString(),-30}" +
                   $"{_description}";
        }

        /// <summary>
        /// Allow to get and set the variable Description
        /// </summary>
        public string Description
        {
            get { return _description; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _description = value;
            }
        }

        /// <summary>
        /// Allow to set and get date time
        /// </summary>
        public DateTime DateTime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }

        /// <summary>
        /// Allow to set and get the priority type
        /// </summary>
        public PriorityType Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
    }
}
