using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_резюме
{
    /// 
    /// адрес проживания
    /// </summary>
    internal class МоеОбразование
    {
        /// <summary>
        /// образование:
        /// </summary>
        public string Образование { get { return образование; } set { образование = value; } }
        private string образование;

        /// <summary>
        /// учебное заведение:
        /// </summary>
        public string УчебноеЗавадение { get { return учебноеЗавадение; } set { учебноеЗавадение = value; } }
        private string учебноеЗавадение;

        /// <summary>
        /// специальность:
        /// </summary>
        public string Специальность { get { return спациальность; } set { спациальность = value; } }
        private string спациальность;
    }
}
