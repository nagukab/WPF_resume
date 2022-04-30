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
    internal class МойАдрес
    {
        /// <summary>
        /// страна проживания
        /// </summary>
        public string Страна { get { return страна; } set { страна = value; } }
        private string страна;

        /// <summary>
        /// город проживания
        /// </summary>
        public string Город { get { return город; } set { город = value; } }
        private string город;
    }
}
