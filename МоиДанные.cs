using System;

namespace WPF_резюме
{
    /// <summary>
    /// мои личные данны (ФИО, дата рождения)
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

        /// <summary>
        /// эти поля обязательно заполнить        /// 
        /// </summary>
        /// <param name="фамилия">фамилия обазательно !</param>
        /// <param name="имя">имя обазательно !</param>
        /// <param name="отчество">отчество обазательно !</param>
        /// <param name="датаРождения">датаРождения обазательно !</param>
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
