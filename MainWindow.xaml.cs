using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    public partial class MainWindow : Window
    {
        РЕЗЮМЕ резюме;
        Timer таймер = new Timer();
        bool isLoaded = false;
        int отсчет = 1;
        public MainWindow()
        {
            InitializeComponent();


            резюме = new РЕЗЮМЕ(this, "Боронин", "Михаил", "Юрьевич", new DateTime(1986, 11, 17));
            резюме = new РЕЗЮМЕ(ГлавноеОкно: this, фамилия: "Боронин", имя: "Михаил", отчество: "Юрьевич", датаРождения: new DateTime(1986, 11, 17)); //todo подробный вариант удалить
            textbox_ФИО.Text = резюме.моиДанные.МоеФИО();
            textbox_датаРождения.Text = резюме.моиДанные.ДатаРождения.ToString("yyyy-MM-dd");


            резюме.мойАдрес.Город = "г. Красноярск";
            резюме.мойАдрес.Страна = "Россия";
            ЗаполнитьАдрес(резюме.мойАдрес);                                        //заполнить текстбокс инфой адреса

            резюме.моеОбразование.Образование = "Среднее специальное";
            резюме.моеОбразование.УчебноеЗавадение = "Красноярский автотранспортный техникум";
            резюме.моеОбразование.Специальность = "Автомеханик";
            ЗаполнитьОбразование(резюме.моеОбразование);                                         //заполнить текстбокс инфой образовании

            резюме.моиКонтакты.Телефон = "8-923-28-64-711";
            резюме.моиКонтакты.Почта = "xbakugan09@mail.ru";
            резюме.моиКонтакты.СоцСеть = "https://vk.com/a_vriant";
            ЗаполнитьКонтакты(резюме.моиКонтакты);                                     //заполнить текстбокс инфой контактов

            резюме.моиДополнения.ОбоМне = Properties.Resources.info;
            ЗаполнитьТекстБокс(textbox_обоМне, резюме.моиДополнения.ОбоМне);                      //заполнить текстбокс инфой дополнительно

            таймер.Elapsed += Таймер_Elapsed; таймер.Interval = 3000; таймер.Start(); // таймер для переключения фоток
            isLoaded = true;
        }
        #region _________________________________________________________МЕТОДЫ

        /// <summary>
        /// принимает МойАдрес, проверяет свойства и вызывает заполнение текстбокса
        /// </summary>
        /// <param name="value"></param>
        void ЗаполнитьАдрес(МойАдрес value)
        {
            if (value.Страна != String.Empty && value.Страна != null || value.Город != String.Empty && value.Город != null)
            { ЗаполнитьТекстБокс(textbox_адрес, $"{value.Страна} {value.Город}"); }
            else { ЗаполнитьТекстБокс(textbox_адрес, "нет данных"); }
        }
        /// <summary>
        /// принимает МоеОбразование, проверяет свойства и вызывает заполнение текстбокса
        /// </summary>
        /// <param name="value"></param>
        void ЗаполнитьОбразование(МоеОбразование value)
        {
            if (value.Образование != String.Empty && value.Образование != null) { ЗаполнитьТекстБокс(textbox_образование, value.Образование); }
            else { ЗаполнитьТекстБокс(textbox_образование, "нет данных"); }

            if (value.УчебноеЗавадение != String.Empty && value.УчебноеЗавадение != null) { ЗаполнитьТекстБокс(textbox_учебноеЗаведение, value.УчебноеЗавадение); }
            else { ЗаполнитьТекстБокс(textbox_учебноеЗаведение, "нет данных"); }

            if (value.Специальность != String.Empty && value.Специальность != null) { ЗаполнитьТекстБокс(textbox_специальность, value.Специальность); }
            else { ЗаполнитьТекстБокс(textbox_специальность, "нет данных"); }
        }

        /// <summary>
        /// принимает МоиКонтакты, проверяет свойства и вызывает заполнение текстбокса
        /// </summary>
        /// <param name="value"></param>
        void ЗаполнитьКонтакты(МоиКонтакты value)
        {
            if (value.Телефон != String.Empty && value.Телефон != null) { ЗаполнитьТекстБокс(textbox_телефон, value.Телефон); }
            else { ЗаполнитьТекстБокс(textbox_телефон, "нет данных"); }

            if (value.Почта != String.Empty && value.Почта != null) { ЗаполнитьТекстБокс(textbox_почта, value.Почта); }
            else { ЗаполнитьТекстБокс(textbox_почта, "нет данных"); }

            if (value.СоцСеть != String.Empty && value.СоцСеть != null) { ЗаполнитьТекстБокс(textbox_соцсеть, value.СоцСеть); }
            else { ЗаполнитьТекстБокс(textbox_соцсеть, "нет данных"); }

        }

        /// <summary>
        /// заполняет принятный тексбокс принятой строкой с помощью цикла с задержкой
        /// </summary>
        /// <param name="текстБокс">принимаемый текстбокс</param>
        /// <param name="строка">принимаемая строка</param>
        async void ЗаполнитьТекстБокс(TextBox текстБокс, string строка)
        {
            if (текстБокс.IsReadOnly == true) // при загрузке текстбоксы только для чтения, заходит сюда и заполняет их
            {
                int задержка = Convert.ToInt32(Math.Floor(5000 / (decimal)строка?.Length)) - 1;  // задержка зависит от длинны входящей строки
                текстБокс.Text = String.Empty;
                for (int i = 0; i < строка?.Length; i++)
                {
                    текстБокс.Text += строка[i].ToString();
                    double процент = 0.4; // процент итераций, которые буду задерживать
                    double делитель = Math.Ceiling(строка.Length / (строка.Length * процент)); // делитель зависит от длинны строки и заданного процента
                    // чем больше процент, тем меньше делитель и значит чаще будет срабатывать задержка (при проценте равном 100, делитель будет округлен до 2, а значит каждая 2ая итерация будет задержена)
                    if (задержка > 100 || (задержка < 100 && i % делитель == 0))
                    {                                    // если на делитель делится без остатка, то делать задержку
                        await Task.Delay(задержка);
                    }
                    else { continue; }
                }
                текстБокс.IsReadOnly = false; // когда заполнились разрешает редактировать текстбоксы
            }
            else { текстБокс.Text = строка; } // но при редактировании сразу заменяет на старый текст
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
            if (isLoaded && (sender as TextBox).IsReadOnly == false) // когда попытка изменения происходит после заполнения текстбоксов
            {
                ЗаполнитьАдрес(резюме.мойАдрес); ЗаполнитьОбразование(резюме.моеОбразование); ЗаполнитьКонтакты(резюме.моиКонтакты); ЗвукОшибки();
            }

            if ((sender as TextBox).IsReadOnly == true && (sender as TextBox).Name == textbox_обоМне.Name && резюме.моиДополнения.ОбоМне != null) // пока тектсбокс textbox_обоМне заполняется, разрешает изменять прогрессбар
            { // когда изменение происходит после инициализации, до включения возможности редактировать текстбокс
                progressBar_обоМне.Maximum = резюме.моиДополнения.ОбоМне.Length;
                progressBar_обоМне.Value = (sender as TextBox).Text.Length; // выставить изменить прогресс бара
                if ((sender as TextBox).Text.Length == резюме.моиДополнения.ОбоМне.Length) // когда длинна совпадет, проиграть звук
                { using (MemoryStream звук = new MemoryStream(Properties.Resources.nHarpwav)) new SoundPlayer(звук).Play(); }
            }
        }

        /// <summary>
        /// событие срабатывания таймера
        /// </summary>
        private void Таймер_Elapsed(object sender, ElapsedEventArgs e)
        {
            таймер.Interval = 3000; // устанавливает основноме время для интервала таймера
            if (отсчет < 5) { отсчет++; }
            else { отсчет = 1; }
            Dispatcher.Invoke(() => { slider_фото.Value = отсчет; });
        }
        /// <summary>
        /// событие изменения значения слайдера
        /// </summary>       
        private void slider_фото_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (isLoaded)
            {
                ResourceManager ресурс = Properties.Resources.ResourceManager;
                Bitmap bm;
                switch (slider_фото.Value)
                {
                    case 1: bm = (Bitmap)ресурс.GetObject("foto1"); break;
                    case 2: bm = (Bitmap)ресурс.GetObject("foto2"); break;
                    case 3: bm = (Bitmap)ресурс.GetObject("foto3"); break;
                    case 4: bm = (Bitmap)ресурс.GetObject("foto4"); break;
                    case 5: bm = (Bitmap)ресурс.GetObject("foto5"); break;
                    default: bm = (Bitmap)ресурс.GetObject("foto1"); break;
                }
                BitmapSource bit = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bm.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                image_foto1.Source = bit;
            }
        }

        /// <summary>
        /// событие воздействия на слайдер мышкой
        /// </summary>
        private void slider_фото_GotMouseCapture(object sender, MouseEventArgs e)
        {
            таймер.Interval = 10000; // увеличивает временно интервал у таймера, чтоб фотка не сменилась
            using (MemoryStream звук = new MemoryStream(Properties.Resources.AutoCastButtonClickwav)) new SoundPlayer(звук).Play();
        }

        #endregion события

    }
}
