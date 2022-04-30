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
        Timer таймер = new Timer();
        МоиДанные моиДанные = new МоиДанные("Боронин", "Михаил", "Юрьевич", new DateTime(1986, 11, 17));
        МойАдрес мойАдрес = new МойАдрес() { Страна = "Россия", Город = "г. Красноярск" };
        МоеОбразование моеОбразование = new МоеОбразование() { Образование = "Среднее специальное", УчебноеЗавадение = "Красноярский автотранспортный техникум", Специальность = "Автомеханик" };
        МоиКонтакты моиКонтакты = new МоиКонтакты { Телефон = "8-923-28-64-711", Почта = "xbakugan09@mail.ru", СоцСеть = "https://vk.com/a_vriant" };
        МоиДополнения моиДополнения = new МоиДополнения();
        bool isLoaded = false;
        int отсчет = 1;
        public MainWindow()
        {
            InitializeComponent();
            textbox_ФИО.Text = моиДанные.МоеФИО();
            textbox_датаРождения.Text = моиДанные.ДатаРождения.ToString("yyyy-MM-dd");
            ЗаполнитьАдрес();
            ЗаполнитьОбразование();
            ЗаполнитьКонтакты();
            моиДополнения.ОбоМне = Properties.Resources.info;
            textbox_обоМне.Text = моиДополнения.ОбоМне;
            isLoaded = true;
            таймер.Elapsed += Таймер_Elapsed; таймер.Interval = 3000; таймер.Start();
        }



        #region _________________________________________________________МЕТОДЫ

        void ЗаполнитьАдрес()
        {
            if (мойАдрес.Страна != String.Empty && мойАдрес.Страна != null || мойАдрес.Город != String.Empty && мойАдрес.Город != null)
            {
                textbox_адрес.Text = $"{мойАдрес.Страна} {мойАдрес.Город}";
            }
            else { textbox_адрес.Text = "нет данных"; }
        }
        void ЗаполнитьОбразование()
        {
            if (моеОбразование.Образование != String.Empty && моеОбразование.Образование != null) { textbox_образование.Text = моеОбразование.Образование; }
            else { textbox_образование.Text = "нет данных"; }

            if (моеОбразование.УчебноеЗавадение != String.Empty && моеОбразование.УчебноеЗавадение != null) { textbox_учебноеЗаведение.Text = моеОбразование.УчебноеЗавадение; }
            else { textbox_учебноеЗаведение.Text = "нет данных"; }

            if (моеОбразование.Специальность != String.Empty && моеОбразование.Образование != null) { textbox_специальность.Text = моеОбразование.Специальность; }
            else { textbox_специальность.Text = "нет данных"; }
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
            if (isLoaded) { ЗаполнитьАдрес(); ЗаполнитьОбразование(); ЗаполнитьКонтакты(); ЗвукОшибки(); }
        }

        /// <summary>
        /// событие срабатывания таймера
        /// </summary>
        private void Таймер_Elapsed(object sender, ElapsedEventArgs e)
        {
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
                switch (slider_фото.Value)
                {
                    case 1:
                        Bitmap bm = (Bitmap)ресурс.GetObject("foto1");
                        BitmapSource bit = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bm.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                        image_foto1.Source = bit;
                        break;
                    case 2:
                        bm = (Bitmap)ресурс.GetObject("foto2");
                        bit = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bm.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                        image_foto1.Source = bit;
                        break;
                    case 3:
                        bm = (Bitmap)ресурс.GetObject("foto3");
                        bit = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bm.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                        image_foto1.Source = bit;
                        break;
                    case 4:
                        bm = (Bitmap)ресурс.GetObject("foto4");
                        bit = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bm.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                        image_foto1.Source = bit;
                        break;

                    case 5:
                        bm = (Bitmap)ресурс.GetObject("foto5");
                        bit = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bm.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                        image_foto1.Source = bit;
                        break;

                    default:
                        bm = (Bitmap)ресурс.GetObject("foto1");
                        bit = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bm.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                        image_foto1.Source = bit;
                        break;
                }
            }
        }

        #endregion события
    }
}
