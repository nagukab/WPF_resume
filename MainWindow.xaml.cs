﻿using System;
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
            //ЗаполнитьТекстБокс(textbox_ФИО, моиДанные.МоеФИО());
            textbox_датаРождения.Text = моиДанные.ДатаРождения.ToString("yyyy-MM-dd");
           // ЗаполнитьТекстБокс(textbox_датаРождения, моиДанные.ДатаРождения.ToString("yyyy-MM-dd"));
            ЗаполнитьАдрес();
            ЗаполнитьОбразование();
            ЗаполнитьКонтакты();
            моиДополнения.ОбоМне = Properties.Resources.info;
            ЗаполнитьТекстБокс(textbox_обоМне, моиДополнения.ОбоМне);
            isLoaded = true;
            таймер.Elapsed += Таймер_Elapsed; таймер.Interval = 3000; таймер.Start();
        }
        #region _________________________________________________________МЕТОДЫ

        void ЗаполнитьАдрес()
        {
            if (мойАдрес.Страна != String.Empty && мойАдрес.Страна != null || мойАдрес.Город != String.Empty && мойАдрес.Город != null)
            {
                ЗаполнитьТекстБокс(textbox_адрес, $"{мойАдрес.Страна} {мойАдрес.Город}");
            }
            else { ЗаполнитьТекстБокс(textbox_адрес, "нет данных"); }
        }
        void ЗаполнитьОбразование()
        {
            if (моеОбразование.Образование != String.Empty && моеОбразование.Образование != null) { ЗаполнитьТекстБокс(textbox_образование, моеОбразование.Образование); }
            else { ЗаполнитьТекстБокс(textbox_образование, "нет данных"); }

            if (моеОбразование.УчебноеЗавадение != String.Empty && моеОбразование.УчебноеЗавадение != null) { ЗаполнитьТекстБокс(textbox_учебноеЗаведение, моеОбразование.УчебноеЗавадение); }
            else { ЗаполнитьТекстБокс(textbox_учебноеЗаведение, "нет данных"); }

            if (моеОбразование.Специальность != String.Empty && моеОбразование.Образование != null) { ЗаполнитьТекстБокс(textbox_специальность, моеОбразование.Специальность); }
            else { ЗаполнитьТекстБокс(textbox_специальность, "нет данных"); }
        }
        void ЗаполнитьКонтакты()
        {
            if (моиКонтакты.Телефон != String.Empty && моиКонтакты.Телефон != null) { ЗаполнитьТекстБокс(textbox_телефон, моиКонтакты.Телефон); }
            else { ЗаполнитьТекстБокс(textbox_телефон, "нет данных"); }

            if (моиКонтакты.Почта != String.Empty && моиКонтакты.Почта != null) { ЗаполнитьТекстБокс(textbox_почта, моиКонтакты.Почта); }
            else { ЗаполнитьТекстБокс(textbox_почта, "нет данных"); }

            if (моиКонтакты.СоцСеть != String.Empty && моиКонтакты.СоцСеть != null) { ЗаполнитьТекстБокс(textbox_соцсеть, моиКонтакты.СоцСеть); }
            else { ЗаполнитьТекстБокс(textbox_соцсеть, "нет данных"); }

        }

        /// <summary>
        /// заполняет тексбокс с помощью цикла с задержкой
        /// </summary>
        /// <param name="текстБокс">принимаемый текстбокс</param>
        /// <param name="строка">принимаемая строка</param>
        async void ЗаполнитьТекстБокс(TextBox текстБокс, string строка)
        {
            if (текстБокс.IsReadOnly == true) // при загрузке текстбоксы только для чтения, заходит сюда и заполняет их
            {
                int задержка = Convert.ToInt32(Math.Floor(5000 / (decimal)строка.Length)) - 1;  // задержка зависит от длинны входящей строки
                текстБокс.Text = String.Empty;
                for (int i = 0; i < строка.Length; i++)
                {
                    текстБокс.Text += строка[i].ToString();
                    await Task.Delay(задержка);
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
            if (isLoaded && (sender as TextBox).IsReadOnly == false)
            {
                ЗаполнитьАдрес(); ЗаполнитьОбразование(); ЗаполнитьКонтакты(); ЗвукОшибки();
            }
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
