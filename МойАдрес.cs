

namespace WPF_резюме
{
    /// <summary>
    /// адрес проживания
    /// </summary>
    internal class МойАдрес
    {
        /// <summary>
        /// адрес проживания
        /// </summary>
        /// <param name="Страна">страна проживания</param>
        /// <param name="Город">город проживания</param>
        public МойАдрес() { }
        /// <summary>
        /// адрес проживания
        /// </summary>
        /// <param name="Страна">страна проживания</param>
        /// <param name="Город">город проживания</param>
        public МойАдрес(string Страна, string Город) { this.Страна = Страна; this.Город = Город; }
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
