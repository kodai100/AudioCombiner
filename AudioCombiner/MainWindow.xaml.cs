using Microsoft.Win32;
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


namespace AudioCombiner
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
        }

        void OnClick1(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FilterIndex = 1;
            openFileDialog.Filter = "Audio File(.mp3)|*.mp3";
            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                ApplicationData data = this.DataContext as ApplicationData;
                data.IntroFilePath = openFileDialog.FileName;
            }
        }

        void OnClick2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FilterIndex = 1;
            openFileDialog.Filter = "Audio File(.mp3)|*.mp3";
            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                ApplicationData data = this.DataContext as ApplicationData;
                data.OutroFilePath = openFileDialog.FileName;
            }
        }

        void FileDrop(object sender, DragEventArgs e)
        {
            ApplicationData data = this.DataContext as ApplicationData;

            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];

            if (files != null)
            {
                foreach (var s in files)
                {
                    
                    if (System.IO.Path.GetExtension(s) == ".mp3")
                    {
                        data.AudioFilePathes.Add(s);
                    }
                }
                    
            }
        }

        void OnClick3(object sender, RoutedEventArgs e)
        {

            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                ApplicationData data = this.DataContext as ApplicationData;
                data.OutputDirectoryPath = dialog.SelectedPath;
            }

        }

        void OnClear(object sender, RoutedEventArgs e)
        {

            ApplicationData data = this.DataContext as ApplicationData;
            data.AudioFilePathes.Clear();
        }

        void GenerateButton(object sender, RoutedEventArgs e)
        {

            ApplicationData data = this.DataContext as ApplicationData;

            if (!System.IO.File.Exists(data.IntroFilePath))
            {
                MessageBox.Show("Please set correct intro file path");
            }

            if (!System.IO.File.Exists(data.OutroFilePath))
            {
                MessageBox.Show("Please set correct outro file path");
            }

            if (!System.IO.Directory.Exists(data.OutputDirectoryPath))
            {
                MessageBox.Show("Please set correct output directory path");
            }


            if(data.AudioFilePathes.Count == 0)
            {
                MessageBox.Show("Please select sound files");
            }


            foreach (var file in data.AudioFilePathes)
            {
                string[] combineTarget = new string[] { data.IntroFilePath, file, data.OutroFilePath };

                AudioProcess.CreateMashup(combineTarget, data.OutputDirectoryPath, System.IO.Path.GetFileNameWithoutExtension(file));
            }



        }
    }
}
