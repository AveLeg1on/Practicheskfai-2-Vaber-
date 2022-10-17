using System;
using System.Collections.Generic;
using System.Linq;
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
using Lib_11;
using Libmas;
using Microsoft.Win32;

namespace Vaber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] mas;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*)|*.*| Текстовые файлы |*.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";
            
                if (open.ShowDialog() == true)
                {
                  mas=ClassForProgram.Openmas(open.FileName, mas);
                  grider.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
                  txt2.Text = "Ответ: " + ClassP.ElemntMas(mas);


                }
            


        }

        private void Save_Click(object sender, RoutedEventArgs e)
        { SaveFileDialog save= new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы |*.*| Текстовые файлы |*.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";
           
            
                if (save.ShowDialog() == true)
                {
                    ClassForProgram.SMass(mas, save.FileName);
                }
            

        }

        private void Info(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: Денисов Олег Андреевич\n Задание:. Ввести n целых чисел(>0 или <0). Найти разницу чисел. Результат вывести на экран.\r\n", "FAQ", MessageBoxButton.OKCancel, MessageBoxImage.None);
        }

        private void Txt1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt1.Text != "")
            {
                if (int.TryParse(txt1.Text, out int value))
                {
                    mas = new int[value];
                    grider.ItemsSource = VisualArray.ToDataTable(ClassForProgram.ZMass(mas, value)).DefaultView;
                    txt2.Text = "Ответ: " + ClassP.ElemntMas(mas);

                }
                else
                {
                    txt1.Text = null;
                }


            }

        }
    }
}
