using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TaskDataGridItem
    {
        public int TASK_ID { get; set; }
        public string ASSIGNED_TO { get; set; }
        public string ASSIGNED_BY { get; set; }
        public string TASK_TITLE { get; set; }
        public string TASK_DETAILS { get; set; }
        public DateTime ISSUE_DATE { get; set; }
        public DateTime DUE_DATE { get; set; }
        public bool SEND_EMAIL { get; set; }
    }
}
