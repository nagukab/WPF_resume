using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
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

namespace WPF_резюме
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        МоиДанные моиДанные = new МоиДанные("Боронин", "Михаил", "Юрьевич", new DateTime(1986, 11, 17));
        МойАдрес мойАдрес = new МойАдрес { Страна = "Россия", Город = "г. Красноярск" };
        МоиКонтакты моиКонтакты = new МоиКонтакты { Телефон = "8-923-28-64-711", Почта = "xbakugan09@mail.ru", СоцСеть = "https://vk.com/a_vriant" };
        bool isLoaded = false;
        public MainWindow()
        {
            InitializeComponent();
            textbox_ФИО.Text = моиДанные.МоеФИО();
            textbox_датаРождения.Text = моиДанные.ДатаРождения.ToString("yyyy-MM-dd");
            ЗаполнитьАдрес();
            ЗаполнитьКонтакты();
            isLoaded = true;
        }

        #region _________________________________________________________МЕТОДЫ

        void ЗаполнитьАдрес()
        {
            if (мойАдрес.Страна != String.Empty && мойАдрес.Страна != null || мойАдрес.Город != String.Empty && мойАдрес.Город != null)
            {
                textbox_адрес.Text = $"{мойАдрес.Страна} {мойАдрес.Город}";
            }
        }
        void ЗаполнитьКонтакты()
        {
            if (моиКонтакты.Телефон != String.Empty && моиКонтакты.Телефон != null) { textbox_телефон.Text = моиКонтакты.Телефон; }
            else { textbox_телефон.Text = "нет данных"; }

            if (моиКонтакты.Почта != String.Empty && моиКонтакты.Почта != null) { textbox_почта.Text = моиКонтакты.Почта; }
            else { textbox_почта.Text = "нет данных"; }

            if (моиКонтакты.СоцСеть != String.Empty && моиКонтакты.СоцСеть != null) { textbox_соцсеть.Text = моиКонтакты.СоцСеть; }
            else { textbox_соцсеть.Text = "нет данных"; }

        }

        /// <summary>
        /// вопспроизводит звук ошибки
        /// </summary>
        void ЗвукОшибки() { using (MemoryStream звукОшибки = new MemoryStream(Properties.Resources.Errorwav)) new SoundPlayer(звукОшибки).Play(); }

        #endregion методы

        #region _________________________________________________________СОБЫТИЯ
        /// <summary>
        /// событие попытки изменения текста в контактах
        /// </summary>
        private void textbox_Контакты_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isLoaded) { ЗаполнитьАдрес(); ЗаполнитьКонтакты(); ЗвукОшибки(); }
        }
        #endregion события

    }
}
