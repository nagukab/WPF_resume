using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_резюме
{
    /// <summary>
    /// мои личные данны
    /// </summary>
    internal class МоиДанные
    {
        readonly private string фамилия,имя,отчество;
        /// <summary>
        /// моя фамилия
        /// </summary>
        public string Фамилия { get { return фамилия; } }

        /// <summary>
        /// мое имя
        /// </summary>
        public string Имя { get { return имя; } }        

        /// <summary>
        /// мое отчество
        /// </summary>
        public string Отчество { get { return отчество; } }       

        /// <summary>
        /// моя дата рождения
        /// </summary>
        public DateTime ДатаРождения { get { return датаРождения; } }
        readonly private DateTime датаРождения;

        public МоиДанные(string фамилия, string имя, string отчество, DateTime датаРождения)
        {
            this.фамилия = фамилия;
            this.имя = имя;
            this.отчество = отчество;
            this.датаРождения = датаРождения;
        }

        public string МоеФИО() { return $"{фамилия} {имя} {отчество}"; }
    }
}
